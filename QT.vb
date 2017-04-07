Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules
Imports System.Text.RegularExpressions


Namespace SO

    <Serializable()> _
    <DB(TableName:="pbs_SO_QT_{XXX}")>
    Public Class QT
        Inherits Csla.BusinessBase(Of QT)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            'Select Case e.PropertyName

            '    Case "OrderType"
            '        If Not Me.GetOrderTypeInfo.ManualRef Then
            '            Me._orderNo = POH.AutoReference
            '        End If

            '    Case "OrderDate"
            '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

            '    Case "SuppCode"
            '        For Each line In Lines
            '            line._suppCode = Me.SuppCode
            '        Next

            '    Case "ConvCode"
            '        If String.IsNullOrEmpty(Me.ConvCode) Then
            '            _convRate.Float = 0
            '        Else
            '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
            '            If conv IsNot Nothing Then
            '                _convRate.Float = conv.DefaultRate
            '            End If
            '        End If

            '    Case Else

            'End Select

            pbs.BO.Rules.CalculationRules.Calculator(sender, e)
        End Sub
#End Region

#Region " Business Properties and Methods "
        Friend _DTB As String = String.Empty


        Private _recType As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        <CellInfo(GroupName:="", Tips:="")>
        <Rule(Required:=True)>
        Public ReadOnly Property RecType() As String
            Get
                Return _recType
            End Get
        End Property

        Friend _transRef As String = String.Empty
        <System.ComponentModel.DataObjectField(True, False)> _
        <CellInfo(GroupName:="", Tips:="")>
        <Rule(Required:=True)>
        Public ReadOnly Property TransRef() As String
            Get
                Return _transRef
            End Get
        End Property


        Private _headerId As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property HeaderId() As String
            Get
                Return _headerId
            End Get
            Set(ByVal value As String)
                CanWriteProperty("HeaderId", True)
                If value Is Nothing Then value = String.Empty
                If Not _headerId.Equals(value) Then
                    _headerId = value
                    PropertyHasChanged("HeaderId")
                End If
            End Set
        End Property

        Private _custCode As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        <Rule(Required:=True)>
        Public Property CustCode() As String
            Get
                Return _custCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CustCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _custCode.Equals(value) Then
                    _custCode = value
                    PropertyHasChanged("CustCode")
                End If
            End Set
        End Property

        Private _transDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        <Rule(Required:=True)>
        Public Property TransDate() As String
            Get
                Return _transDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _transDate.Equals(value) Then
                    _transDate.Text = value
                    PropertyHasChanged("TransDate")
                End If
            End Set
        End Property

        Private _status As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Status", True)
                If value Is Nothing Then value = String.Empty
                If Not _status.Equals(value) Then
                    _status = value
                    PropertyHasChanged("Status")
                End If
            End Set
        End Property

        Private _transCd As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TransCd() As String
            Get
                Return _transCd
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransCd", True)
                If value Is Nothing Then value = String.Empty
                If Not _transCd.Equals(value) Then
                    _transCd = value
                    PropertyHasChanged("TransCd")
                End If
            End Set
        End Property

        Private _transCode As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TransCode() As String
            Get
                Return _transCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _transCode.Equals(value) Then
                    _transCode = value
                    PropertyHasChanged("TransCode")
                End If
            End Set
        End Property

        Private _orderNo As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property OrderNo() As String
            Get
                Return _orderNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("OrderNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _orderNo.Equals(value) Then
                    _orderNo = value
                    PropertyHasChanged("OrderNo")
                End If
            End Set
        End Property

        Private _dNoteNo As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property DNoteNo() As String
            Get
                Return _dNoteNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DNoteNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _dNoteNo.Equals(value) Then
                    _dNoteNo = value
                    PropertyHasChanged("DNoteNo")
                End If
            End Set
        End Property

        Private _delivAdd As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property DelivAdd() As String
            Get
                Return _delivAdd
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DelivAdd", True)
                If value Is Nothing Then value = String.Empty
                If Not _delivAdd.Equals(value) Then
                    _delivAdd = value
                    PropertyHasChanged("DelivAdd")
                End If
            End Set
        End Property

        Private _delivAddress As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property DelivAddress() As String
            Get
                Return _delivAddress
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DelivAddress", True)
                If value Is Nothing Then value = String.Empty
                If Not _delivAddress.Equals(value) Then
                    _delivAddress = value
                    PropertyHasChanged("DelivAddress")
                End If
            End Set
        End Property

        Private _orderDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property OrderDate() As String
            Get
                Return _orderDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("OrderDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _orderDate.Equals(value) Then
                    _orderDate.Text = value
                    PropertyHasChanged("OrderDate")
                End If
            End Set
        End Property

        Private _ackDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property AckDate() As String
            Get
                Return _ackDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AckDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _ackDate.Equals(value) Then
                    _ackDate.Text = value
                    PropertyHasChanged("AckDate")
                End If
            End Set
        End Property

        Private _pickDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property PickDate() As String
            Get
                Return _pickDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PickDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _pickDate.Equals(value) Then
                    _pickDate.Text = value
                    PropertyHasChanged("PickDate")
                End If
            End Set
        End Property

        Private _delDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property DelDate() As String
            Get
                Return _delDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DelDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _delDate.Equals(value) Then
                    _delDate.Text = value
                    PropertyHasChanged("DelDate")
                End If
            End Set
        End Property

        Private _invDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property InvDate() As String
            Get
                Return _invDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _invDate.Equals(value) Then
                    _invDate.Text = value
                    PropertyHasChanged("InvDate")
                End If
            End Set
        End Property

        Private _invPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(LinkCode.Period, GroupName:="", Tips:="")>
        Public Property InvPrd() As String
            Get
                Return _invPrd.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvPrd", True)
                If value Is Nothing Then value = String.Empty
                If Not _invPrd.Equals(value) Then
                    _invPrd.Text = value
                    PropertyHasChanged("InvPrd")
                End If
            End Set
        End Property

        Private _custRef As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property CustRef() As String
            Get
                Return _custRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CustRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _custRef.Equals(value) Then
                    _custRef = value
                    PropertyHasChanged("CustRef")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property ConvCode() As String
            Get
                Return _convCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _convCode.Equals(value) Then
                    _convCode = value
                    PropertyHasChanged("ConvCode")
                End If
            End Set
        End Property

        Private _comments As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Comments() As String
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Comments", True)
                If value Is Nothing Then value = String.Empty
                If Not _comments.Equals(value) Then
                    _comments = value
                    PropertyHasChanged("Comments")
                End If
            End Set
        End Property

        Private _transVal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TransVal() As String
            Get
                Return _transVal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransVal", True)
                If value Is Nothing Then value = String.Empty
                If Not _transVal.Equals(value) Then
                    _transVal.Text = value
                    PropertyHasChanged("TransVal")
                End If
            End Set
        End Property

        Private _payDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property PayDate() As String
            Get
                Return _payDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PayDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _payDate.Equals(value) Then
                    _payDate.Text = value
                    PropertyHasChanged("PayDate")
                End If
            End Set
        End Property

        Private _analAdd As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property AnalAdd() As String
            Get
                Return _analAdd
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalAdd", True)
                If value Is Nothing Then value = String.Empty
                If Not _analAdd.Equals(value) Then
                    _analAdd = value
                    PropertyHasChanged("AnalAdd")
                End If
            End Set
        End Property

        Private _linkedText As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property LinkedText() As String
            Get
                Return _linkedText
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LinkedText", True)
                If value Is Nothing Then value = String.Empty
                If Not _linkedText.Equals(value) Then
                    _linkedText = value
                    PropertyHasChanged("LinkedText")
                End If
            End Set
        End Property

        Private _analM0 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM0() As String
            Get
                Return _analM0
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM0", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM0.Equals(value) Then
                    _analM0 = value
                    PropertyHasChanged("AnalM0")
                End If
            End Set
        End Property

        Private _analM1 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM1() As String
            Get
                Return _analM1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM1", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM1.Equals(value) Then
                    _analM1 = value
                    PropertyHasChanged("AnalM1")
                End If
            End Set
        End Property

        Private _analM2 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM2() As String
            Get
                Return _analM2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM2", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM2.Equals(value) Then
                    _analM2 = value
                    PropertyHasChanged("AnalM2")
                End If
            End Set
        End Property

        Private _analM3 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM3() As String
            Get
                Return _analM3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM3", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM3.Equals(value) Then
                    _analM3 = value
                    PropertyHasChanged("AnalM3")
                End If
            End Set
        End Property

        Private _analM4 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM4() As String
            Get
                Return _analM4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM4", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM4.Equals(value) Then
                    _analM4 = value
                    PropertyHasChanged("AnalM4")
                End If
            End Set
        End Property

        Private _analM5 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM5() As String
            Get
                Return _analM5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM5", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM5.Equals(value) Then
                    _analM5 = value
                    PropertyHasChanged("AnalM5")
                End If
            End Set
        End Property

        Private _analM6 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM6() As String
            Get
                Return _analM6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM6", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM6.Equals(value) Then
                    _analM6 = value
                    PropertyHasChanged("AnalM6")
                End If
            End Set
        End Property

        Private _analM7 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM7() As String
            Get
                Return _analM7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM7", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM7.Equals(value) Then
                    _analM7 = value
                    PropertyHasChanged("AnalM7")
                End If
            End Set
        End Property

        Private _analM8 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM8() As String
            Get
                Return _analM8
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM8", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM8.Equals(value) Then
                    _analM8 = value
                    PropertyHasChanged("AnalM8")
                End If
            End Set
        End Property

        Private _analM9 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property AnalM9() As String
            Get
                Return _analM9
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AnalM9", True)
                If value Is Nothing Then value = String.Empty
                If Not _analM9.Equals(value) Then
                    _analM9 = value
                    PropertyHasChanged("AnalM9")
                End If
            End Set
        End Property

        Private _quoteConvert As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property QuoteConvert() As String
            Get
                Return _quoteConvert
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QuoteConvert", True)
                If value Is Nothing Then value = String.Empty
                If Not _quoteConvert.Equals(value) Then
                    _quoteConvert = value
                    PropertyHasChanged("QuoteConvert")
                End If
            End Set
        End Property

        Private _quotePrint As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property QuotePrint() As String
            Get
                Return _quotePrint
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QuotePrint", True)
                If value Is Nothing Then value = String.Empty
                If Not _quotePrint.Equals(value) Then
                    _quotePrint = value
                    PropertyHasChanged("QuotePrint")
                End If
            End Set
        End Property

        Private _quoteExpiryDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property QuoteExpiryDate() As String
            Get
                Return _quoteExpiryDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QuoteExpiryDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _quoteExpiryDate.Equals(value) Then
                    _quoteExpiryDate.Text = value
                    PropertyHasChanged("QuoteExpiryDate")
                End If
            End Set
        End Property

        Private _periodQuoted As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(LinkCode.Period, GroupName:="", Tips:="")>
        Public Property PeriodQuoted() As String
            Get
                Return _periodQuoted.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PeriodQuoted", True)
                If value Is Nothing Then value = String.Empty
                If Not _periodQuoted.Equals(value) Then
                    _periodQuoted.Text = value
                    PropertyHasChanged("PeriodQuoted")
                End If
            End Set
        End Property

        Private _quotationRef As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property QuotationRef() As String
            Get
                Return _quotationRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QuotationRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _quotationRef.Equals(value) Then
                    _quotationRef = value
                    PropertyHasChanged("QuotationRef")
                End If
            End Set
        End Property

        Private _dateQuoted As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property DateQuoted() As String
            Get
                Return _dateQuoted.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DateQuoted", True)
                If value Is Nothing Then value = String.Empty
                If Not _dateQuoted.Equals(value) Then
                    _dateQuoted.Text = value
                    PropertyHasChanged("DateQuoted")
                End If
            End Set
        End Property

        Private _voidStatus As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property VoidStatus() As String
            Get
                Return _voidStatus
            End Get
            Set(ByVal value As String)
                CanWriteProperty("VoidStatus", True)
                If value Is Nothing Then value = String.Empty
                If Not _voidStatus.Equals(value) Then
                    _voidStatus = value
                    PropertyHasChanged("VoidStatus")
                End If
            End Set
        End Property

        Private _exCustCode1 As String = String.Empty
        <CellInfo(GroupName:="Extended Code")>
        Public Property ExCustCode1() As String
            Get
                Return _exCustCode1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExCustCode1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exCustCode1.Equals(value) Then
                    _exCustCode1 = value
                    PropertyHasChanged("ExCustCode1")
                End If
            End Set
        End Property

        Private _exCustCode2 As String = String.Empty
        <CellInfo(GroupName:="Extended Code")>
        Public Property ExCustCode2() As String
            Get
                Return _exCustCode2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExCustCode2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exCustCode2.Equals(value) Then
                    _exCustCode2 = value
                    PropertyHasChanged("ExCustCode2")
                End If
            End Set
        End Property

        Private _exText1 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText1() As String
            Get
                Return _exText1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText1.Equals(value) Then
                    _exText1 = value
                    PropertyHasChanged("ExText1")
                End If
            End Set
        End Property

        Private _exText2 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText2() As String
            Get
                Return _exText2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText2.Equals(value) Then
                    _exText2 = value
                    PropertyHasChanged("ExText2")
                End If
            End Set
        End Property

        Private _exText3 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText3() As String
            Get
                Return _exText3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText3.Equals(value) Then
                    _exText3 = value
                    PropertyHasChanged("ExText3")
                End If
            End Set
        End Property

        Private _exText4 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText4() As String
            Get
                Return _exText4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText4.Equals(value) Then
                    _exText4 = value
                    PropertyHasChanged("ExText4")
                End If
            End Set
        End Property

        Private _exText5 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText5() As String
            Get
                Return _exText5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText5.Equals(value) Then
                    _exText5 = value
                    PropertyHasChanged("ExText5")
                End If
            End Set
        End Property

        Private _exText6 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText6() As String
            Get
                Return _exText6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText6", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText6.Equals(value) Then
                    _exText6 = value
                    PropertyHasChanged("ExText6")
                End If
            End Set
        End Property

        Private _exText7 As String = String.Empty
        <CellInfo(GroupName:="ExtText")>
        Public Property ExText7() As String
            Get
                Return _exText7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExText7", True)
                If value Is Nothing Then value = String.Empty
                If Not _exText7.Equals(value) Then
                    _exText7 = value
                    PropertyHasChanged("ExText7")
                End If
            End Set
        End Property

        Private _exVal1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="ExtVal")>
        Public Property ExVal1() As String
            Get
                Return _exVal1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal1.Equals(value) Then
                    _exVal1.Text = value
                    PropertyHasChanged("ExVal1")
                End If
            End Set
        End Property

        Private _exVal2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="ExtVal")>
        Public Property ExVal2() As String
            Get
                Return _exVal2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal2.Equals(value) Then
                    _exVal2.Text = value
                    PropertyHasChanged("ExVal2")
                End If
            End Set
        End Property

        Private _exVal3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="ExtVal")>
        Public Property ExVal3() As String
            Get
                Return _exVal3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal3.Equals(value) Then
                    _exVal3.Text = value
                    PropertyHasChanged("ExVal3")
                End If
            End Set
        End Property

        Private _exVal4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="ExtVal")>
        Public Property ExVal4() As String
            Get
                Return _exVal4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal4.Equals(value) Then
                    _exVal4.Text = value
                    PropertyHasChanged("ExVal4")
                End If
            End Set
        End Property

        Private _exVal5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="ExtVal")>
        Public Property ExVal5() As String
            Get
                Return _exVal5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExVal5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exVal5.Equals(value) Then
                    _exVal5.Text = value
                    PropertyHasChanged("ExVal5")
                End If
            End Set
        End Property

        Private _exDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="ExtDate")>
        Public Property ExDate1() As String
            Get
                Return _exDate1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate1", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate1.Equals(value) Then
                    _exDate1.Text = value
                    PropertyHasChanged("ExDate1")
                End If
            End Set
        End Property

        Private _exDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="ExtDate")>
        Public Property ExDate2() As String
            Get
                Return _exDate2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate2", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate2.Equals(value) Then
                    _exDate2.Text = value
                    PropertyHasChanged("ExDate2")
                End If
            End Set
        End Property

        Private _exDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="ExtDate")>
        Public Property ExDate3() As String
            Get
                Return _exDate3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate3", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate3.Equals(value) Then
                    _exDate3.Text = value
                    PropertyHasChanged("ExDate3")
                End If
            End Set
        End Property

        Private _exDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="ExtDate")>
        Public Property ExDate4() As String
            Get
                Return _exDate4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate4", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate4.Equals(value) Then
                    _exDate4.Text = value
                    PropertyHasChanged("ExDate4")
                End If
            End Set
        End Property

        Private _exDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="ExtDate")>
        Public Property ExDate5() As String
            Get
                Return _exDate5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExDate5", True)
                If value Is Nothing Then value = String.Empty
                If Not _exDate5.Equals(value) Then
                    _exDate5.Text = value
                    PropertyHasChanged("ExDate5")
                End If
            End Set
        End Property

        Private _quoteBy As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property QuoteBy() As String
            Get
                Return _quoteBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QuoteBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _quoteBy.Equals(value) Then
                    _quoteBy = value
                    PropertyHasChanged("QuoteBy")
                End If
            End Set
        End Property

        Private _soBy As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property SoBy() As String
            Get
                Return _soBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SoBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _soBy.Equals(value) Then
                    _soBy = value
                    PropertyHasChanged("SoBy")
                End If
            End Set
        End Property

        Private _isInterface As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property IsInterface() As String
            Get
                Return _isInterface
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IsInterface", True)
                If value Is Nothing Then value = String.Empty
                If Not _isInterface.Equals(value) Then
                    _isInterface = value
                    PropertyHasChanged("IsInterface")
                End If
            End Set
        End Property

        Private _locked As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Locked() As String
            Get
                Return _locked
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Locked", True)
                If value Is Nothing Then value = String.Empty
                If Not _locked.Equals(value) Then
                    _locked = value
                    PropertyHasChanged("Locked")
                End If
            End Set
        End Property

        Private _lockedBy As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property LockedBy() As String
            Get
                Return _lockedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LockedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _lockedBy.Equals(value) Then
                    _lockedBy = value
                    PropertyHasChanged("LockedBy")
                End If
            End Set
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        Private _udatedBy As String = String.Empty
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property UdatedBy() As String
            Get
                Return _udatedBy
            End Get
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return String.Format("{0}:{1}", _recType.Trim, _transRef.Trim)
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            Dim pRecType As String = Regex.Match(ID, pbsRegex.AlphaNumericExt).Value
            Dim pTransRef As String = Regex.Match(ID, pbsRegex.AlphaNumericExt).NextMatch.Value
            If _recType.Trim < pRecType Then Return -1
            If _recType.Trim > pRecType Then Return 1
            If _transRef.Trim < pTransRef Then Return -1
            If _transRef.Trim > pTransRef Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of QT)._fieldList
                If _field.Required Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
                End If
                If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
                End If
                '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
                If CATMAPInfoList.ContainsCode(_field) Then
                    ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                    'Else
                    '    Select Case _field.FieldName
                    '        Case "LocType"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                    '        Case "Status"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                    '    End Select
                End If
            Next
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankQT() As QT
            Return New QT
        End Function

        Public Shared Function NewQT(ByVal pRecType As String, ByVal pTransRef As String) As QT
            If KeyDuplicated(pRecType, pTransRef) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("QT")))
            Return DataPortal.Create(Of QT)(New Criteria(pRecType, pTransRef))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As QT
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            'Dim pRecType As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).Value.Trim
            'Dim pTransRef As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).NextMatch.Value.Trim

            Dim pRecType As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value
            Dim pTransRef As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value

            Return NewQT(pRecType, pTransRef)
        End Function

        Public Shared Function GetQT(ByVal pRecType As String, ByVal pTransRef As String) As QT
            Return DataPortal.Fetch(Of QT)(New Criteria(pRecType, pTransRef))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As QT
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            'Dim pRecType As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).Value.Trim
            'Dim pTransRef As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).NextMatch.Value.Trim

            Dim pRecType As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value
            Dim pTransRef As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value

            Return GetQT(pRecType, pTransRef)
        End Function

        Public Shared Sub DeleteQT(ByVal pRecType As String, ByVal pTransRef As String)
            DataPortal.Delete(New Criteria(pRecType, pTransRef))
        End Sub

        Public Overrides Function Save() As QT
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("QT")))

            Me.ApplyEdit()
            QTInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneQT(ByVal pRecType As String, ByVal pTransRef As String) As QT

            If QT.KeyDuplicated(pRecType, pTransRef) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningQT As QT = MyBase.Clone
            cloningQT._recType = pRecType
            cloningQT._transRef = pTransRef
            cloningQT._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningQT.MarkNew()
            cloningQT.ApplyEdit()

            cloningQT.ValidationRules.CheckRules()

            Return cloningQT
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _recType As String = String.Empty
            Public _transRef As String = String.Empty

            Public Sub New(ByVal pRecType As String, ByVal pTransRef As String)
                _recType = pRecType
                _transRef = pTransRef

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _recType = criteria._recType
            _transRef = criteria._transRef

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_SO_QT_<%= _DTB %> WHERE REC_TYPE= '<%= criteria._recType %>' AND TRANS_REF= '<%= criteria._transRef %>' 
                                              SELECT * FROM pbs_SO_QTD_<%= _DTB %> WHERE TRANS_REF= '<%= criteria._transRef %>'
                                    </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If

                        If dr.NextResult Then
                            _details = QTDs.GetQTDs(dr, Me)
                            MarkOld()
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _recType = dr.GetString("REC_TYPE").TrimEnd
            _transRef = dr.GetString("TRANS_REF").TrimEnd
            _headerId = dr.GetString("HEADER_ID").TrimEnd
            _custCode = dr.GetString("CUST_CODE").TrimEnd
            _transDate.Text = dr.GetInt32("TRANS_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _transCd = dr.GetString("TRANS_CD").TrimEnd
            _transCode = dr.GetString("TRANS_CODE").TrimEnd
            _orderNo = dr.GetString("ORDER_NO").TrimEnd
            _dNoteNo = dr.GetString("D_NOTE_NO").TrimEnd
            _delivAdd = dr.GetString("DELIV_ADD").TrimEnd
            _delivAddress = dr.GetString("DELIV_ADDRESS").TrimEnd
            _orderDate.Text = dr.GetInt32("ORDER_DATE")
            _ackDate.Text = dr.GetInt32("ACK_DATE")
            _pickDate.Text = dr.GetInt32("PICK_DATE")
            _delDate.Text = dr.GetInt32("DEL_DATE")
            _invDate.Text = dr.GetInt32("INV_DATE")
            _invPrd.Text = dr.GetInt32("INV_PRD")
            _custRef = dr.GetString("CUST_REF").TrimEnd
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _comments = dr.GetString("COMMENTS").TrimEnd
            _transVal.Text = dr.GetDecimal("TRANS_VAL")
            _payDate.Text = dr.GetInt32("PAY_DATE")
            _analAdd = dr.GetString("ANAL_ADD").TrimEnd
            _linkedText = dr.GetString("LINKED_TEXT").TrimEnd
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
            _isInterface = dr.GetString("IS_INTERFACE").TrimEnd
            _locked = dr.GetString("LOCKED").TrimEnd
            _lockedBy = dr.GetString("LOCKED_BY").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _udatedBy = dr.GetString("UDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_SO_QT_{0}_InsertUpdate", _DTB)

                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using

                    Details.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)
            cm.Parameters.AddWithValue("@REC_TYPE", _recType.Trim)
            cm.Parameters.AddWithValue("@TRANS_REF", _transRef.Trim)
            cm.Parameters.AddWithValue("@HEADER_ID", _headerId.Trim)
            cm.Parameters.AddWithValue("@CUST_CODE", _custCode.Trim)
            cm.Parameters.AddWithValue("@TRANS_DATE", _transDate.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@TRANS_CD", _transCd.Trim)
            cm.Parameters.AddWithValue("@TRANS_CODE", _transCode.Trim)
            cm.Parameters.AddWithValue("@ORDER_NO", _orderNo.Trim)
            cm.Parameters.AddWithValue("@D_NOTE_NO", _dNoteNo.Trim)
            cm.Parameters.AddWithValue("@DELIV_ADD", _delivAdd.Trim)
            cm.Parameters.AddWithValue("@DELIV_ADDRESS", _delivAddress.Trim)
            cm.Parameters.AddWithValue("@ORDER_DATE", _orderDate.DBValue)
            cm.Parameters.AddWithValue("@ACK_DATE", _ackDate.DBValue)
            cm.Parameters.AddWithValue("@PICK_DATE", _pickDate.DBValue)
            cm.Parameters.AddWithValue("@DEL_DATE", _delDate.DBValue)
            cm.Parameters.AddWithValue("@INV_DATE", _invDate.DBValue)
            cm.Parameters.AddWithValue("@INV_PRD", _invPrd.DBValue)
            cm.Parameters.AddWithValue("@CUST_REF", _custRef.Trim)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@COMMENTS", _comments.Trim)
            cm.Parameters.AddWithValue("@TRANS_VAL", _transVal.DBValue)
            cm.Parameters.AddWithValue("@PAY_DATE", _payDate.DBValue)
            cm.Parameters.AddWithValue("@ANAL_ADD", _analAdd.Trim)
            cm.Parameters.AddWithValue("@LINKED_TEXT", _linkedText.Trim)
            cm.Parameters.AddWithValue("@ANAL_M0", _analM0.Trim)
            cm.Parameters.AddWithValue("@ANAL_M1", _analM1.Trim)
            cm.Parameters.AddWithValue("@ANAL_M2", _analM2.Trim)
            cm.Parameters.AddWithValue("@ANAL_M3", _analM3.Trim)
            cm.Parameters.AddWithValue("@ANAL_M4", _analM4.Trim)
            cm.Parameters.AddWithValue("@ANAL_M5", _analM5.Trim)
            cm.Parameters.AddWithValue("@ANAL_M6", _analM6.Trim)
            cm.Parameters.AddWithValue("@ANAL_M7", _analM7.Trim)
            cm.Parameters.AddWithValue("@ANAL_M8", _analM8.Trim)
            cm.Parameters.AddWithValue("@ANAL_M9", _analM9.Trim)
            cm.Parameters.AddWithValue("@QUOTE_CONVERT", _quoteConvert.Trim)
            cm.Parameters.AddWithValue("@QUOTE_PRINT", _quotePrint.Trim)
            cm.Parameters.AddWithValue("@QUOTE_EXPIRY_DATE", _quoteExpiryDate.DBValue)
            cm.Parameters.AddWithValue("@PERIOD_QUOTED", _periodQuoted.DBValue)
            cm.Parameters.AddWithValue("@QUOTATION_REF", _quotationRef.Trim)
            cm.Parameters.AddWithValue("@DATE_QUOTED", _dateQuoted.DBValue)
            cm.Parameters.AddWithValue("@VOID_STATUS", _voidStatus.Trim)
            cm.Parameters.AddWithValue("@EX_CUST_CODE1", _exCustCode1.Trim)
            cm.Parameters.AddWithValue("@EX_CUST_CODE2", _exCustCode2.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT1", _exText1.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT2", _exText2.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT3", _exText3.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT4", _exText4.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT5", _exText5.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT6", _exText6.Trim)
            cm.Parameters.AddWithValue("@EX_TEXT7", _exText7.Trim)
            cm.Parameters.AddWithValue("@EX_VAL1", _exVal1.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL2", _exVal2.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL3", _exVal3.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL4", _exVal4.DBValue)
            cm.Parameters.AddWithValue("@EX_VAL5", _exVal5.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE1", _exDate1.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE2", _exDate2.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE3", _exDate3.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE4", _exDate4.DBValue)
            cm.Parameters.AddWithValue("@EX_DATE5", _exDate5.DBValue)
            cm.Parameters.AddWithValue("@QUOTE_BY", _quoteBy.Trim)
            cm.Parameters.AddWithValue("@SO_BY", _soBy.Trim)
            cm.Parameters.AddWithValue("@IS_INTERFACE", _isInterface.Trim)
            cm.Parameters.AddWithValue("@LOCKED", _locked.Trim)
            cm.Parameters.AddWithValue("@LOCKED_BY", _lockedBy.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            DataPortal_Insert()
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_recType, _transRef))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_SO_QT_<%= _DTB %> WHERE REC_TYPE= '<%= criteria._recType %>' AND TRANS_REF= '<%= criteria._transRef %>' </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        QTInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal ID As String) As Boolean
            Return QTInfoList.ContainsID(ID)
        End Function

        Public Shared Function KeyDuplicated(ByVal pRecType As String, ByVal pTransRef As String) As Boolean
            Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_SO_QT_<%= Context.CurrentBECode %> WHERE REC_TYPE= '<%= pRecType %>' AND TRANS_REF= '<%= pTransRef %>'</SqlText>.Value.Trim
            Return SQLCommander.GetScalarInteger(SqlText) > 0
        End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Dim theRecType = Regex.Match(id, pbsRegex.AlphaNumericExt2).Value
            Dim theTransRef = Regex.Match(id, pbsRegex.AlphaNumericExt2).NextMatch.Value
            Return CloneQT(theRecType, theTransRef)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(QT).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(QT).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return QTInfoList.GetQTInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _recType)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace