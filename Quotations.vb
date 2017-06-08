Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports pbs.BO.Script
Imports pbs.BO
Imports pbs.BO.Mail
Imports FlexCel.XlsAdapter

Namespace SO
    Public Class Quotations
        Implements IQueryBO
        Implements ISupportScripts

        Private _qtProfile As String = String.Empty
        Dim _selectedQT As New List(Of QTInfo)
#Region "IQueryBO"

        Private _period As SmartPeriod = New SmartPeriod("T")

        Public Sub AddQueryFilters(pDic As Dictionary(Of String, String)) Implements IQueryBO.AddQueryFilters

        End Sub

        Public ReadOnly Property ChildrenType As Type Implements IQueryBO.ChildrenType
            Get
                Return GetType(QTInfo)
            End Get
        End Property

        Public Function GetBOList() As IList Implements IQueryBO.GetBOList
            Dim list = (From lst In QTInfoList.GetQTInfoList Where lst.PeriodQuoted = _period.ToString).ToList
            Return list
            'Return QTInfoList.GetQTInfoList
        End Function

        Public Function GetBOListStatus() As String Implements IQueryBO.GetBOListStatus
            Return "{LineNo}"
        End Function

        Public Function GetDoubleClickCommand() As String Implements IQueryBO.GetDoubleClickCommand
            Return String.Format("pbs.BO.SO.QT?LineNo=[LineNo]&$Action=View")
        End Function

        Public Function GetMyQD() As SQLBuilder.QD Implements IQueryBO.GetMyQD

        End Function

        Public Function GetMyTitle() As String Implements IQueryBO.GetMyTitle
            Return String.Format("Quotations(SO) at period {0}", _period.Text)
        End Function

        Public Function GetSelectCommand() As String Implements IQueryBO.GetSelectCommand

        End Function

        Public Function GetSelectionChangedCommand() As String Implements IQueryBO.GetSelectionChangedCommand

        End Function

        Public Function GetVariables() As Dictionary(Of String, String) Implements IQueryBO.GetVariables

        End Function

        Public Sub InvalidateCacheList() Implements IQueryBO.InvalidateCacheList

        End Sub

        Public Sub SetParameters(pDic As Dictionary(Of String, String)) Implements IQueryBO.SetParameters

        End Sub

        Public Function Syntax() As String Implements IQueryBO.Syntax
            Return <syntax>pbs.BO.SO.Quotations?PeriodQuoted=...</syntax>.Value
        End Function

        Public Sub UpdateCurrentLine(pLine As Object) Implements IQueryBO.UpdateCurrentLine

        End Sub

        Public Sub UpdateQD(pQD As SQLBuilder.QD) Implements IQueryBO.UpdateQD

        End Sub

        Public Sub UpdateSelectedLines(pLines As IEnumerable) Implements IQueryBO.UpdateSelectedLines
            _selectedQT.Clear()
            For Each itm In pLines
                _selectedQT.Add(itm)
            Next
        End Sub

        Public Sub ZReset() Implements IQueryBO.ZReset

        End Sub

        Public Function CanExecute(cmd As String) As Boolean? Implements Helper.Interfaces.ISupportCommandAuthorization.CanExecute

        End Function

#End Region

#Region "ISupportScripts"
        'Previous button
        Private Function PreviousItem_Imp() As UITasks
            Dim ret = New UITasks(Me)

            ret.IconName = "Prev"
            ret.AddCallMethod(1, "PreviousItem")
            ret.RefreshUIWhenFinish = True

            Return ret
        End Function
        Private Sub PreviousItem()
            _period.Period -= 1
        End Sub

        'Next button
        Private Function NextItem_Imp() As UITasks
            Dim ret = New UITasks(Me)

            ret.IconName = "Next"
            ret.AddCallMethod(1, "NextItem")
            ret.RefreshUIWhenFinish = True

            Return ret
        End Function
        Private Sub NextItem()
            _period.Period += 1
        End Sub

        'Filter button
        Private Function SelectPeriod_Imp() As UITasks
            Dim ret = New UITasks(Me)

            ret.IconName = "Find/Find"
            ret.AddCallMethod(1, "SelectPeriod")
            ret.RefreshUIWhenFinish = True

            Return ret
        End Function
        Private Sub SelectPeriod()
            Dim newPeriod = pbs.Helper.UIServices.ValueSelectorService.SelectValue(LinkCode.Period, ResStr(ResStrConst.SelectItemText("Period")), String.Empty)

            If Not String.IsNullOrEmpty(newPeriod) Then
                _period.Text = newPeriod
            End If

        End Sub

        'Create button
        Private Function Create_Imp() As UITasks
            Dim ret = New UITasks(Me)
            ret.AddCallMethod(1, "Create")
            ret.RefreshUIWhenFinish = True
            Return ret
        End Function

        Private Sub Create()
            Dim cmd = New pbsCmdArgs("pbs.BO.SO.QT?$Action=Create")
            pbs.Helper.UIServices.RunURLService.Run(cmd)
        End Sub


        'Email button
        Private Function SendEmail_Imp() As UITasks
            Dim ret = New UITasks(Me)
            ret.IconName = "Mail"
            ret.AddCallMethod(1, "SendEmail")

            Return ret
        End Function
        'Private Sub SendEmail()

        '    Dim logMsg = New List(Of String)

        '    For Each itm In _selectedQT

        '        Dim msg As Mail.MSGO = Nothing

        '        If itm.MessageId > 0 AndAlso itm.Status = "Sent" Then
        '            logMsg.Add(String.Format("Quotations for customer {0}.{1} at period {2} have already sent", itm.CustCode, pbs.BO.CRM.CUSInfoList.GetCUSInfo(itm.CustCode), itm.PeriodQuoted))

        '        ElseIf itm.MessageId > 0 AndAlso itm.Status = "Sending" Then
        '            logMsg.Add(String.Format("Quotations {0} is sending by another process", itm.TransRef))

        '        ElseIf itm.MessageId > 0 Then
        '            msg = Mail.MSGO.GetMSGO(itm.MessageId)

        '        Else
        '            msg = itm.BuilMSGO

        '            If msg.MsgId > 0 Then
        '                Dim _qt = QT.GetQT(itm.LineNo)
        '                _qt.MessageId = msg.MsgId
        '                _qt.Status = "Approved"
        '                '_qt.MarAsDirty()                                                           'can't find this method
        '                If _qt.IsSavable Then _qt = _qt.Save
        '            End If
        '        End If

        '        If msg IsNot Nothing Then
        '            'Notify user if mail has been sent


        '            'sent mail if it hasn't been sent yet
        '            SendGridMailService.SendMSGO(msg)

        '            msg._msgStatus = "Sent"
        '            msg._sentDate = Now
        '            msg.MarkAsDirty()

        '            msg.Save()
        '            logMsg.Add("Email has been sent")

        '        End If

        '    Next



        'End Sub

        'SaleOder button
        Private Function SaleOrder_Imp() As UITasks
            Dim ret = New UITasks(Me)
            ret.IconName = "Sales"
            ret.AddCallMethod(1, "SaleOrder")

            Return ret
        End Function
        Private Sub SaleOder()
            Dim so = SOH.NewSOH(String.Empty)

            For Each itm In _selectedQT

            Next


        End Sub


        Public Function GetScriptDictionary() As Dictionary(Of String, UITasks) Implements ISupportScripts.GetScriptDictionary
            Dim ret = New Dictionary(Of String, UITasks)

            ret.Add("SaleOder", SaleOrder_Imp)
            ret.Add("Mail", SendEmail_Imp)
            ret.Add("Next", NextItem_Imp)
            ret.Add("Filter", SelectPeriod_Imp)
            ret.Add("Previous", PreviousItem_Imp)
            ret.Add("Create", Create_Imp)
            Return ret
        End Function
#End Region

    End Class
End Namespace

