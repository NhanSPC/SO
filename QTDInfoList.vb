
Imports Csla
Imports Csla.Data
Imports System.Xml
Imports pbs.Helper
Imports System.Data.SqlClient

Namespace SO

    <Serializable()> _
    Public Class QTDInfoList
        Inherits Csla.ReadOnlyListBase(Of QTDInfoList, QTDInfo)

#Region " Transfer and Report Function "

        Public Shared Function TransferOut(ByVal Code_From As String, ByVal Code_To As String, ByVal FileName As String) As Integer
            Dim _dt As New DataTable(GetType(QTD).ToString)
            Dim oa As New ObjectAdapter()

            For Each info As QTDInfo In QTDInfoList.GetQTDInfoList
                If info.Code >= Code_From AndAlso info.Code <= Code_To Then
                    oa.Fill(_dt, QTD.GetBO(info.ToString))
                End If
            Next
            Try
                _dt.Columns.Remove("IsNew")
                _dt.Columns.Remove("IsValid")
                _dt.Columns.Remove("IsSavable")
                _dt.Columns.Remove("IsDeleted")
                _dt.Columns.Remove("IsDirty")
                _dt.Columns.Remove("BrokenRulesCollection")
            Catch ex As Exception
            End Try

            For Each col As DataColumn In _dt.Columns
                col.ColumnMapping = MappingType.Attribute
            Next

            _dt.WriteXml(FileName)

            Return _dt.Rows.Count

        End Function

        Public Shared Function GetMyReportDataset() As List(Of DataTable)
            QTDInfoList.InvalidateCache()

            Dim thelist = QTDInfoList.GetQTDInfoList.ToList()

            Dim shr = New pbs.BO.ObjectShredder(Of QTDInfo)
            Dim dts As New List(Of DataTable)
            dts.Add(shr.Shred(thelist, Nothing, LoadOption.OverwriteChanges))

            Return dts
        End Function

#End Region

#Region " Business Properties and Methods "
        Private Shared _DTB As String = String.Empty
        Const _SUNTB As String = ""
        Private Shared _list As QTDInfoList
#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function GetQTDInfo(ByVal pTransRef As String, ByVal pTransLine As String) As QTDInfo
            Dim Info As QTDInfo = QTDInfo.EmptyQTDInfo(pTransRef, pTransLine)
            Dim ID = Info.ToString
            ContainsID(ID, Info)
            Return Info
        End Function

        'Public Shared Function GetDescription(ByVal pCode As String) As String
        '   Return GetQTDInfo(pCode).Description
        'End Function

        Public Shared Function GetQTDInfoList() As QTDInfoList
            If _list Is Nothing OrElse _DTB <> Context.CurrentBECode Then

                _DTB = Context.CurrentBECode
                _list = DataPortal.Fetch(Of QTDInfoList)(New FilterCriteria())

            End If
            Return _list
        End Function

        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        Public Shared Function ContainsCode(ByVal pTransRef As String, ByVal pTransLine As String, Optional ByRef RetInfo As QTDInfo = Nothing) As Boolean
            Dim EmptyInfo = QTDInfo.EmptyQTDInfo(pTransRef, pTransLine)
            Dim fl = From info In GetQTDInfoList() Where info.CompareTo(String.Format("{0}:{1}", pTransRef, pTransLine)) = 0            'Check this!
            For Each info As QTDInfo In fl
                RetInfo = info
                Return True
            Next
            RetInfo = EmptyInfo
        End Function

        Public Shared Function ContainsID(ByVal ID As String, Optional ByRef RetInfo As QTDInfo = Nothing) As Boolean

            Dim EmptyInfo = QTDInfo.EmptyQTDInfo()

            Dim fl = From info In GetQTDInfoList() Where info.CompareTo(ID) = 0

            For Each info As QTDInfo In fl
                RetInfo = info
                Return True
            Next

            RetInfo = EmptyInfo
        End Function

#End Region ' Factory Methods

#Region " Data Access "

#Region " Filter Criteria "

        <Serializable()> _
        Private Class FilterCriteria
            Friend _timeStamp() As Byte
            Public Sub New()
            End Sub
        End Class

#End Region
        Private Shared _lockObj As New Object

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As FilterCriteria)
            SyncLock _lockObj
                RaiseListChangedEvents = False
                IsReadOnly = False
                Using cn = New SqlClient.SqlConnection(Database.PhoebusConnection)
                    cn.Open()

                    Using cm = cn.CreateCommand()
                        cm.CommandType = CommandType.Text
                        cm.CommandText = <SqlText>SELECT * FROM pbs_SO_QTD_<%= _DTB %></SqlText>.Value.Trim

                        ' If criteria._timeStamp IsNot Nothing AndAlso criteria._timeStamp.Length > 0 Then
                        'cm.CommandText = <SqlText>SELECT * FROM pbs_SO_QTD_DEM WHERE DTB='<%= _DTB %>'</SqlText>.Value.Trim AND TIME_STAMP > @CurrentTimeStamp.Value.Trim
                        '     cm.Parameters.AddWithValue("@CurrentTimeStamp", criteria._timeStamp)
                        ' Else
                        '     cm.CommandText = <SqlText>SELECT * FROM pbs_SO_QTD_DEM WHERE DTB='<%= _DTB %>'</SqlText>.Value.Trim
                        ' End If

                        Using dr As New SafeDataReader(cm.ExecuteReader)
                            While dr.Read
                                Dim info = QTDInfo.GetQTDInfo(dr)
                                Me.Add(Info)
                            End While
                        End Using

                    End Using

                    ' 'read the current version of the list
                    ' Using cm As SqlCommand = cn.CreateSQLCommand()
                    'cm.CommandText = SELECT max(TIME_STAMP) FROM pbs_SO_QTD_DEM WHERE DTB.Value.Tri
                    '     Dim ret = cm.ExecuteScalar
                    '     If ret IsNot Nothing Then _listTimeStamp = ret
                    ' End Using

                End Using
                IsReadOnly = True
                RaiseListChangedEvents = True
            End SyncLock
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace