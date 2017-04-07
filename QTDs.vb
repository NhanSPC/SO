Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports pbs.Helper
Imports System.Text.RegularExpressions
Namespace SO

    <Serializable()> _
    Public Class QTDs
        Inherits Csla.BusinessListBase(Of QTDs, QTD)

#Region " Business Methods"
        Friend _parent As qt = Nothing

        Protected Overrides Function AddNewCore() As Object
            If _parent IsNot Nothing Then
                Dim theNewLine = QTD.NewQTDChild(_parent.TransRef)
                AddNewLine(theNewLine)
                theNewLine.CheckRules()
                Return theNewLine
            Else
                Return MyBase.AddNewCore
            End If
        End Function

        Friend Sub AddNewLine(ByVal pline As QTD)
            If pline Is Nothing Then Exit Sub

            'get the next line number
            Dim nextnumber As Integer = 1
            If Me.Count > 0 Then
                Dim allNumbers = (From line In Me Where line.TransRef = Me._parent.TransRef Select line.TransLine).ToList
                Dim var = allNumbers.Max
                nextnumber = allNumbers.Max + 1
            End If

            '_line.{LINE_NO} = String.Format("{0:00000}", nextnumber)
            pline._transLine = nextnumber

            'Populate _line with info from parent here

            Me.Add(pline)

        End Sub

#End Region
#Region " Factory Methods "

        Friend Shared Function NewQTDs(ByVal pParent As qt) As QTDs
            Return New QTDs(pParent)
        End Function

        Friend Shared Function GetQTDs(ByVal dr As SafeDataReader, ByVal parent As qt) As QTDs
            Dim ret = New QTDs(dr, parent)
            ret.MarkAsChild()
            Return ret
        End Function

        Private Sub New(ByVal parent As qt)
            _parent = parent
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As SafeDataReader, ByVal parent As qt)
            _parent = parent
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region ' Factory Methods
#Region " Data Access "

        Private Sub Fetch(ByVal dr As SafeDataReader)
            RaiseListChangedEvents = False

            Dim suppressChildValidation = True
            While dr.Read()
                Dim Line = QTD.GetChildQTD(dr)
                Me.Add(Line)
            End While

            RaiseListChangedEvents = True
        End Sub

        Friend Sub Update(ByVal cn As SqlConnection, ByVal parent As qt)
            RaiseListChangedEvents = False

            ' loop through each deleted child object
            For Each deletedChild As QTD In DeletedList
                deletedChild._DTB = parent._DTB
                deletedChild.DeleteSelf(cn)
            Next
            DeletedList.Clear()

            ' loop through each non-deleted child object
            For Each child As QTD In Me
                child._DTB = parent._DTB
                child._TransRef = parent._TransRef
                'child.OrderNo = parent.OrderNo
                If child.IsNew Then
                    child.Insert(cn)
                Else
                    child.Update(cn)
                End If
            Next

            RaiseListChangedEvents = True
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace