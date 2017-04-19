Imports System.Linq
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace SO

    <Serializable()> _
    Public Class QTInfo
        Inherits Csla.ReadOnlyBase(Of QTInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As Integer
        Public ReadOnly Property LineNo() As Integer
            Get
                Return _lineNo
            End Get
        End Property

        Private _transRef As String = String.Empty
        Public ReadOnly Property TransRef() As String
            Get
                Return _transRef
            End Get
        End Property

        Private _custCode As String = String.Empty
        Public ReadOnly Property CustCode() As String
            Get
                Return _custCode
            End Get
        End Property

        Private _transDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property TransDate() As String
            Get
                Return _transDate.DateViewFormat
            End Get
        End Property

        Private _transactionType As String = String.Empty
        Public ReadOnly Property TransactionType() As String
            Get
                Return _transactionType
            End Get
        End Property

        Private _orderNo As String = String.Empty
        Public ReadOnly Property OrderNo() As String
            Get
                Return _orderNo
            End Get
        End Property

        Private _dNoteNo As String = String.Empty
        Public ReadOnly Property DNoteNo() As String
            Get
                Return _dNoteNo
            End Get
        End Property

        Private _delivAdd As String = String.Empty
        Public ReadOnly Property DelivAdd() As String
            Get
                Return _delivAdd
            End Get
        End Property

        Private _delivAddress As String = String.Empty
        Public ReadOnly Property DelivAddress() As String
            Get
                Return _delivAddress
            End Get
        End Property

        Private _orderDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property OrderDate() As String
            Get
                Return _orderDate.DateViewFormat
            End Get
        End Property

        Private _ackDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property AckDate() As String
            Get
                Return _ackDate.DateViewFormat
            End Get
        End Property

        Private _custRef As String = String.Empty
        Public ReadOnly Property CustRef() As String
            Get
                Return _custRef
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _comments As String = String.Empty
        Public ReadOnly Property Comments() As String
            Get
                Return _comments
            End Get
        End Property

        Private _transVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property TransVal() As String
            Get
                Return _transVal.Text
            End Get
        End Property

        Private _analM0 As String = String.Empty
        Public ReadOnly Property AnalM0() As String
            Get
                Return _analM0
            End Get
        End Property

        Private _analM1 As String = String.Empty
        Public ReadOnly Property AnalM1() As String
            Get
                Return _analM1
            End Get
        End Property

        Private _analM2 As String = String.Empty
        Public ReadOnly Property AnalM2() As String
            Get
                Return _analM2
            End Get
        End Property

        Private _analM3 As String = String.Empty
        Public ReadOnly Property AnalM3() As String
            Get
                Return _analM3
            End Get
        End Property

        Private _analM4 As String = String.Empty
        Public ReadOnly Property AnalM4() As String
            Get
                Return _analM4
            End Get
        End Property

        Private _analM5 As String = String.Empty
        Public ReadOnly Property AnalM5() As String
            Get
                Return _analM5
            End Get
        End Property

        Private _analM6 As String = String.Empty
        Public ReadOnly Property AnalM6() As String
            Get
                Return _analM6
            End Get
        End Property

        Private _analM7 As String = String.Empty
        Public ReadOnly Property AnalM7() As String
            Get
                Return _analM7
            End Get
        End Property

        Private _analM8 As String = String.Empty
        Public ReadOnly Property AnalM8() As String
            Get
                Return _analM8
            End Get
        End Property

        Private _analM9 As String = String.Empty
        Public ReadOnly Property AnalM9() As String
            Get
                Return _analM9
            End Get
        End Property

        Private _quoteConvert As String = String.Empty
        Public ReadOnly Property QuoteConvert() As String
            Get
                Return _quoteConvert
            End Get
        End Property

        Private _quotePrint As String = String.Empty
        Public ReadOnly Property QuotePrint() As String
            Get
                Return _quotePrint
            End Get
        End Property

        Private _quoteExpiryDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property QuoteExpiryDate() As String
            Get
                Return _quoteExpiryDate.DateViewFormat
            End Get
        End Property

        Private _periodQuoted As SmartPeriod = New pbs.Helper.SmartPeriod()
        Public ReadOnly Property PeriodQuoted() As String
            Get
                Return _periodQuoted.Text
            End Get
        End Property

        Private _quotationRef As String = String.Empty
        Public ReadOnly Property QuotationRef() As String
            Get
                Return _quotationRef
            End Get
        End Property

        Private _dateQuoted As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property DateQuoted() As String
            Get
                Return _dateQuoted.DateViewFormat
            End Get
        End Property

        Private _voidStatus As String = String.Empty
        Public ReadOnly Property VoidStatus() As String
            Get
                Return _voidStatus
            End Get
        End Property

        Private _exCustCode1 As String = String.Empty
        Public ReadOnly Property ExCustCode1() As String
            Get
                Return _exCustCode1
            End Get
        End Property

        Private _exCustCode2 As String = String.Empty
        Public ReadOnly Property ExCustCode2() As String
            Get
                Return _exCustCode2
            End Get
        End Property

        Private _exText1 As String = String.Empty
        Public ReadOnly Property ExText1() As String
            Get
                Return _exText1
            End Get
        End Property

        Private _exText2 As String = String.Empty
        Public ReadOnly Property ExText2() As String
            Get
                Return _exText2
            End Get
        End Property

        Private _exText3 As String = String.Empty
        Public ReadOnly Property ExText3() As String
            Get
                Return _exText3
            End Get
        End Property

        Private _exText4 As String = String.Empty
        Public ReadOnly Property ExText4() As String
            Get
                Return _exText4
            End Get
        End Property

        Private _exText5 As String = String.Empty
        Public ReadOnly Property ExText5() As String
            Get
                Return _exText5
            End Get
        End Property

        Private _exText6 As String = String.Empty
        Public ReadOnly Property ExText6() As String
            Get
                Return _exText6
            End Get
        End Property

        Private _exText7 As String = String.Empty
        Public ReadOnly Property ExText7() As String
            Get
                Return _exText7
            End Get
        End Property

        Private _exVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal1() As String
            Get
                Return _exVal1.Text
            End Get
        End Property

        Private _exVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal2() As String
            Get
                Return _exVal2.Text
            End Get
        End Property

        Private _exVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal3() As String
            Get
                Return _exVal3.Text
            End Get
        End Property

        Private _exVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal4() As String
            Get
                Return _exVal4.Text
            End Get
        End Property

        Private _exVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExVal5() As String
            Get
                Return _exVal5.Text
            End Get
        End Property

        Private _exDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate1() As String
            Get
                Return _exDate1.DateViewFormat
            End Get
        End Property

        Private _exDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate2() As String
            Get
                Return _exDate2.DateViewFormat
            End Get
        End Property

        Private _exDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate3() As String
            Get
                Return _exDate3.DateViewFormat
            End Get
        End Property

        Private _exDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate4() As String
            Get
                Return _exDate4.DateViewFormat
            End Get
        End Property

        Private _exDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExDate5() As String
            Get
                Return _exDate5.DateViewFormat
            End Get
        End Property

        Private _quoteBy As String = String.Empty
        Public ReadOnly Property QuoteBy() As String
            Get
                Return _quoteBy
            End Get
        End Property

        Private _soBy As String = String.Empty
        Public ReadOnly Property SoBy() As String
            Get
                Return _soBy
            End Get
        End Property

        Private _messageId As Integer
        Public ReadOnly Property MessageId() As Integer
            Get
                Return _messageId
            End Get
        End Property

        Private _status As String = String.Empty
        Public ReadOnly Property Status() As String
            Get
                Return _status
            End Get
        End Property

        Private _isInterface As String = String.Empty
        Public ReadOnly Property IsInterface() As String
            Get
                Return _isInterface
            End Get
        End Property

        Private _locked As String = String.Empty
        Public ReadOnly Property Locked() As String
            Get
                Return _locked
            End Get
        End Property

        Private _lockedBy As String = String.Empty
        Public ReadOnly Property LockedBy() As String
            Get
                Return _lockedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
            End Get
        End Property

        Private _udatedBy As String = String.Empty
        Public ReadOnly Property UdatedBy() As String
            Get
                Return _udatedBy
            End Get
        End Property

        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As Integer = ID.Trim.ToInteger
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _transactionType
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("Transaction Type: {0}, No: {1}, date {2}", _transactionType, _transRef, _transDate)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            QTInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetQTInfo(ByVal dr As SafeDataReader) As QTInfo
            Return New QTInfo(dr)
        End Function

        Friend Shared Function EmptyQTInfo(Optional ByVal pLineNo As String = "") As QTInfo
            Dim info As QTInfo = New QTInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _transRef = dr.GetString("TRANS_REF").TrimEnd
            _custCode = dr.GetString("CUST_CODE").TrimEnd
            _transDate.Text = dr.GetInt32("TRANS_DATE")
            _transactionType = dr.GetString("TRANS_TYPE").TrimEnd
            _orderNo = dr.GetString("ORDER_NO").TrimEnd
            _dNoteNo = dr.GetString("D_NOTE_NO").TrimEnd
            _delivAdd = dr.GetString("DELIV_ADD").TrimEnd
            _delivAddress = dr.GetString("DELIV_ADDRESS").TrimEnd
            _orderDate.Text = dr.GetInt32("ORDER_DATE")
            _ackDate.Text = dr.GetInt32("ACK_DATE")
            _custRef = dr.GetString("CUST_REF").TrimEnd
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _comments = dr.GetString("COMMENTS").TrimEnd
            _transVal.Text = dr.GetDecimal("TRANS_VAL")
            _analM0 = dr.GetString("ANAL_M0").TrimEnd
            _analM1 = dr.GetString("ANAL_M1").TrimEnd
            _analM2 = dr.GetString("ANAL_M2").TrimEnd
            _analM3 = dr.GetString("ANAL_M3").TrimEnd
            _analM4 = dr.GetString("ANAL_M4").TrimEnd
            _analM5 = dr.GetString("ANAL_M5").TrimEnd
            _analM6 = dr.GetString("ANAL_M6").TrimEnd
            _analM7 = dr.GetString("ANAL_M7").TrimEnd
            _analM8 = dr.GetString("ANAL_M8").TrimEnd
            _analM9 = dr.GetString("ANAL_M9").TrimEnd
            _quoteConvert = dr.GetString("QUOTE_CONVERT").TrimEnd
            _quotePrint = dr.GetString("QUOTE_PRINT").TrimEnd
            _quoteExpiryDate.Text = dr.GetInt32("QUOTE_EXPIRY_DATE")
            _periodQuoted.Text = dr.GetInt32("PERIOD_QUOTED")
            _quotationRef = dr.GetString("QUOTATION_REF").TrimEnd
            _dateQuoted.Text = dr.GetInt32("DATE_QUOTED")
            _voidStatus = dr.GetString("VOID_STATUS").TrimEnd
            _exCustCode1 = dr.GetString("EX_CUST_CODE1").TrimEnd
            _exCustCode2 = dr.GetString("EX_CUST_CODE2").TrimEnd
            _exText1 = dr.GetString("EX_TEXT1").TrimEnd
            _exText2 = dr.GetString("EX_TEXT2").TrimEnd
            _exText3 = dr.GetString("EX_TEXT3").TrimEnd
            _exText4 = dr.GetString("EX_TEXT4").TrimEnd
            _exText5 = dr.GetString("EX_TEXT5").TrimEnd
            _exText6 = dr.GetString("EX_TEXT6").TrimEnd
            _exText7 = dr.GetString("EX_TEXT7").TrimEnd
            _exVal1.Text = dr.GetDecimal("EX_VAL1")
            _exVal2.Text = dr.GetDecimal("EX_VAL2")
            _exVal3.Text = dr.GetDecimal("EX_VAL3")
            _exVal4.Text = dr.GetDecimal("EX_VAL4")
            _exVal5.Text = dr.GetDecimal("EX_VAL5")
            _exDate1.Text = dr.GetInt32("EX_DATE1")
            _exDate2.Text = dr.GetInt32("EX_DATE2")
            _exDate3.Text = dr.GetInt32("EX_DATE3")
            _exDate4.Text = dr.GetInt32("EX_DATE4")
            _exDate5.Text = dr.GetInt32("EX_DATE5")
            _quoteBy = dr.GetString("QUOTE_BY").TrimEnd
            _soBy = dr.GetString("SO_BY").TrimEnd
            _messageId = dr.GetInt32("MESSAGE_ID")
            _status = dr.GetString("STATUS").TrimEnd
            _isInterface = dr.GetString("IS_INTERFACE").TrimEnd
            _locked = dr.GetString("LOCKED").TrimEnd
            _lockedBy = dr.GetString("LOCKED_BY").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _udatedBy = dr.GetString("UDATED_BY").TrimEnd

        End Sub

        Private Sub New()
        End Sub


#End Region ' Factory Methods

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

#Region "Usage"
        Function GetDataSet() As DataSet

            'Dim filter = New Dictionary(Of String, String)
            'filter.Add("Period", _periodQuoted.DBValue)

            Dim ds = New DataSet("Quotations")
            Dim h = QTInfoList.GetQTInfo(_lineNo)
            Dim d = (From itm In QTDInfoList.GetQTDInfoList Where itm.QtNo = _lineNo).ToList

            ds.Tables.Add(List2Table.CreateTableFromSingleObject(h, "Header"))
            ds.Tables.Add(List2Table.CreateTableFromList(d, "Detail"))

            Return ds
        End Function

#End Region

#Region "Mailing"
        Private _profile As SDInfo = Nothing
        Private Function GetQTProfile() As SDInfo
            If _profile Is Nothing Then
                _profile = SDInfoList.GetSDInfo(_transactionType)
            End If
            Return _profile
        End Function

        Friend Function BuilMSGO() As Mail.MSGO

            'Create mail body: mail body required 3 elements: tempalte, data, parameters
            Dim template = "QTTemplate"

            Dim data = GetDataSet()

            Dim params = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            params.Add("Profile", TransactionType)
            params.Add("Period", PeriodQuoted)
            params.Add("TransRef", TransRef)

            Dim theDocFile = pbs.BO.Output.ToSnapReport.CreateDocReport(template, data, params)

            'Create MSGOBuilder and add receiver, subject, body, attachment file to it
            Dim cus = pbs.BO.CRM.CUSInfoList.GetCUSInfo(CustCode)
            Dim builder = New Mail.MSGOBuilder

            'receiver
            builder._to = cus.Email

            'subject
            Dim subject = String.Format(ResStr("Quotations no: {0} in Period: {1}"), TransRef, PeriodQuoted)
            builder._subject = Nz(Description, subject)

            'mail body
            builder._bodyDocFileName = theDocFile

            'attachment file
            builder._attachmentFiles = New List(Of String)
            If Not String.IsNullOrEmpty(template) Then
                params.Add("$FileSignature", String.Format("pbs.BO.SO.QT#{0}", _lineNo))
                params.Add("$Comments", subject)

                Dim theXlsFile = FlexelReporter.CreateReport(data, template, params)
                builder._attachmentFiles.Add(theXlsFile)
            End If

            'Send, update status and save:
            'send
            Dim msg = builder.GenerateMSGO
            msg.MsgType = TransactionType
            msg._msgStatus = "Approved"

            'save
            If msg.IsSavable Then msg = msg.Save()
            Return msg

        End Function



#End Region
    End Class

End Namespace