Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace SO

    <Serializable()> _
    <DB(TableName:="pbs_SO_QTD_{XXX}")>
    Public Class QTD
        Inherits Csla.BusinessBase(Of QTD)
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


        Friend _lineNo As Integer
        <System.ComponentModel.DataObjectField(True, True)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _transRef As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        <Rule(Required:=True)>
        Public Property TransRef() As String
            Get
                Return _transRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _transRef.Equals(value) Then
                    _transRef = value
                    PropertyHasChanged("TransRef")
                End If
            End Set
        End Property

        Private _qtNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property QtNo() As String
            Get
                Return _qtNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("QtNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _qtNo.Equals(value) Then
                    _qtNo.Text = value
                    PropertyHasChanged("QtNo")
                End If
            End Set
        End Property

        Private _location As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Location", True)
                If value Is Nothing Then value = String.Empty
                If Not _location.Equals(value) Then
                    _location = value
                    PropertyHasChanged("Location")
                End If
            End Set
        End Property

        Private _itemCode As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property ItemCode() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemCode.Equals(value) Then
                    _itemCode = value
                    PropertyHasChanged("ItemCode")
                End If
            End Set
        End Property

        Private _dueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property DueDate() As String
            Get
                Return _dueDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DueDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _dueDate.Equals(value) Then
                    _dueDate.Text = value
                    PropertyHasChanged("DueDate")
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

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn() As String
            Get
                Return _descriptn
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn.Equals(value) Then
                    _descriptn = value
                    PropertyHasChanged("Descriptn")
                End If
            End Set
        End Property

        Private _saleQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property SaleQty() As String
            Get
                Return _saleQty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SaleQty", True)
                If value Is Nothing Then value = String.Empty
                If Not _saleQty.Equals(value) Then
                    _saleQty.Text = value
                    PropertyHasChanged("SaleQty")
                End If
            End Set
        End Property

        Private _unitSale As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property UnitSale() As String
            Get
                Return _unitSale
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UnitSale", True)
                If value Is Nothing Then value = String.Empty
                If Not _unitSale.Equals(value) Then
                    _unitSale = value
                    PropertyHasChanged("UnitSale")
                End If
            End Set
        End Property

        Private _stkQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property StkQty() As String
            Get
                Return _stkQty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("StkQty", True)
                If value Is Nothing Then value = String.Empty
                If Not _stkQty.Equals(value) Then
                    _stkQty.Text = value
                    PropertyHasChanged("StkQty")
                End If
            End Set
        End Property

        Private _bsp As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Bsp() As String
            Get
                Return _bsp.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Bsp", True)
                If value Is Nothing Then value = String.Empty
                If Not _bsp.Equals(value) Then
                    _bsp.Text = value
                    PropertyHasChanged("Bsp")
                End If
            End Set
        End Property

        Private _curRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property CurRate() As String
            Get
                Return _curRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CurRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _curRate.Equals(value) Then
                    _curRate.Text = value
                    PropertyHasChanged("CurRate")
                End If
            End Set
        End Property

        Private _unitPrice As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property UnitPrice() As String
            Get
                Return _unitPrice.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UnitPrice", True)
                If value Is Nothing Then value = String.Empty
                If Not _unitPrice.Equals(value) Then
                    _unitPrice.Text = value
                    PropertyHasChanged("UnitPrice")
                End If
            End Set
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value4() As String
            Get
                Return _value4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value4", True)
                If value Is Nothing Then value = String.Empty
                If Not _value4.Equals(value) Then
                    _value4.Text = value
                    PropertyHasChanged("Value4")
                End If
            End Set
        End Property

        Private _net As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Net() As String
            Get
                Return _net.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Net", True)
                If value Is Nothing Then value = String.Empty
                If Not _net.Equals(value) Then
                    _net.Text = value
                    PropertyHasChanged("Net")
                End If
            End Set
        End Property

        Private _discount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Discount() As String
            Get
                Return _discount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Discount", True)
                If value Is Nothing Then value = String.Empty
                If Not _discount.Equals(value) Then
                    _discount.Text = value
                    PropertyHasChanged("Discount")
                End If
            End Set
        End Property

        Private _shippingFee As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property ShippingFee() As String
            Get
                Return _shippingFee.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ShippingFee", True)
                If value Is Nothing Then value = String.Empty
                If Not _shippingFee.Equals(value) Then
                    _shippingFee.Text = value
                    PropertyHasChanged("ShippingFee")
                End If
            End Set
        End Property

        Private _taxableAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TaxableAmount() As String
            Get
                Return _taxableAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TaxableAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _taxableAmount.Equals(value) Then
                    _taxableAmount.Text = value
                    PropertyHasChanged("TaxableAmount")
                End If
            End Set
        End Property

        Private _taxRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TaxRate() As String
            Get
                Return _taxRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TaxRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _taxRate.Equals(value) Then
                    _taxRate.Text = value
                    PropertyHasChanged("TaxRate")
                End If
            End Set
        End Property

        Private _taxAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TaxAmount() As String
            Get
                Return _taxAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TaxAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _taxAmount.Equals(value) Then
                    _taxAmount.Text = value
                    PropertyHasChanged("TaxAmount")
                End If
            End Set
        End Property

        Private _value11 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value11() As String
            Get
                Return _value11.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value11", True)
                If value Is Nothing Then value = String.Empty
                If Not _value11.Equals(value) Then
                    _value11.Text = value
                    PropertyHasChanged("Value11")
                End If
            End Set
        End Property

        Private _value12 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value12() As String
            Get
                Return _value12.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value12", True)
                If value Is Nothing Then value = String.Empty
                If Not _value12.Equals(value) Then
                    _value12.Text = value
                    PropertyHasChanged("Value12")
                End If
            End Set
        End Property

        Private _value13 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value13() As String
            Get
                Return _value13.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value13", True)
                If value Is Nothing Then value = String.Empty
                If Not _value13.Equals(value) Then
                    _value13.Text = value
                    PropertyHasChanged("Value13")
                End If
            End Set
        End Property

        Private _value14 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value14() As String
            Get
                Return _value14.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value14", True)
                If value Is Nothing Then value = String.Empty
                If Not _value14.Equals(value) Then
                    _value14.Text = value
                    PropertyHasChanged("Value14")
                End If
            End Set
        End Property

        Private _value15 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value15() As String
            Get
                Return _value15.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value15", True)
                If value Is Nothing Then value = String.Empty
                If Not _value15.Equals(value) Then
                    _value15.Text = value
                    PropertyHasChanged("Value15")
                End If
            End Set
        End Property

        Private _value16 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value16() As String
            Get
                Return _value16.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value16", True)
                If value Is Nothing Then value = String.Empty
                If Not _value16.Equals(value) Then
                    _value16.Text = value
                    PropertyHasChanged("Value16")
                End If
            End Set
        End Property

        Private _value17 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value17() As String
            Get
                Return _value17.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value17", True)
                If value Is Nothing Then value = String.Empty
                If Not _value17.Equals(value) Then
                    _value17.Text = value
                    PropertyHasChanged("Value17")
                End If
            End Set
        End Property

        Private _value18 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value18() As String
            Get
                Return _value18.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value18", True)
                If value Is Nothing Then value = String.Empty
                If Not _value18.Equals(value) Then
                    _value18.Text = value
                    PropertyHasChanged("Value18")
                End If
            End Set
        End Property

        Private _value19 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value19() As String
            Get
                Return _value19.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value19", True)
                If value Is Nothing Then value = String.Empty
                If Not _value19.Equals(value) Then
                    _value19.Text = value
                    PropertyHasChanged("Value19")
                End If
            End Set
        End Property

        Private _lineTotal As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property LineTotal() As String
            Get
                Return _lineTotal.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LineTotal", True)
                If value Is Nothing Then value = String.Empty
                If Not _lineTotal.Equals(value) Then
                    _lineTotal.Text = value
                    PropertyHasChanged("LineTotal")
                End If
            End Set
        End Property

        Private _transactionType As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property TransactionType() As String
            Get
                Return _transactionType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransType", True)
                If value Is Nothing Then value = String.Empty
                If Not _transactionType.Equals(value) Then
                    _transactionType = value
                    PropertyHasChanged("TransType")
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

        Private _ordPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        <CellInfo(LinkCode.Period, GroupName:="", Tips:="")>
        Public Property OrdPrd() As String
            Get
                Return _ordPrd.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("OrdPrd", True)
                If value Is Nothing Then value = String.Empty
                If Not _ordPrd.Equals(value) Then
                    _ordPrd.Text = value
                    PropertyHasChanged("OrdPrd")
                End If
            End Set
        End Property

        Private _invNo As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property InvNo() As String
            Get
                Return _invNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("InvNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _invNo.Equals(value) Then
                    _invNo = value
                    PropertyHasChanged("InvNo")
                End If
            End Set
        End Property

        Private _ackPrint As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property AckPrint() As String
            Get
                Return _ackPrint
            End Get
            Set(ByVal value As String)
                CanWriteProperty("AckPrint", True)
                If value Is Nothing Then value = String.Empty
                If Not _ackPrint.Equals(value) Then
                    _ackPrint = value
                    PropertyHasChanged("AckPrint")
                End If
            End Set
        End Property

        Private _miscPrint As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscPrint() As String
            Get
                Return _miscPrint
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscPrint", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscPrint.Equals(value) Then
                    _miscPrint = value
                    PropertyHasChanged("MiscPrint")
                End If
            End Set
        End Property

        Private _idEntered As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property IdEntered() As String
            Get
                Return _idEntered
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IdEntered", True)
                If value Is Nothing Then value = String.Empty
                If Not _idEntered.Equals(value) Then
                    _idEntered = value
                    PropertyHasChanged("IdEntered")
                End If
            End Set
        End Property

        Private _idInvoiced As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property IdInvoiced() As String
            Get
                Return _idInvoiced
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IdInvoiced", True)
                If value Is Nothing Then value = String.Empty
                If Not _idInvoiced.Equals(value) Then
                    _idInvoiced = value
                    PropertyHasChanged("IdInvoiced")
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

        Private _priceBook As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property PriceBook() As String
            Get
                Return _priceBook
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PriceBook", True)
                If value Is Nothing Then value = String.Empty
                If Not _priceBook.Equals(value) Then
                    _priceBook = value
                    PropertyHasChanged("PriceBook")
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

        Private _miscDocPrint1 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscDocPrint1() As String
            Get
                Return _miscDocPrint1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscDocPrint1", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscDocPrint1.Equals(value) Then
                    _miscDocPrint1 = value
                    PropertyHasChanged("MiscDocPrint1")
                End If
            End Set
        End Property

        Private _miscDocPrint2 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscDocPrint2() As String
            Get
                Return _miscDocPrint2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscDocPrint2", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscDocPrint2.Equals(value) Then
                    _miscDocPrint2 = value
                    PropertyHasChanged("MiscDocPrint2")
                End If
            End Set
        End Property

        Private _miscDocPrint3 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscDocPrint3() As String
            Get
                Return _miscDocPrint3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscDocPrint3", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscDocPrint3.Equals(value) Then
                    _miscDocPrint3 = value
                    PropertyHasChanged("MiscDocPrint3")
                End If
            End Set
        End Property

        Private _miscDocPrint4 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscDocPrint4() As String
            Get
                Return _miscDocPrint4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscDocPrint4", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscDocPrint4.Equals(value) Then
                    _miscDocPrint4 = value
                    PropertyHasChanged("MiscDocPrint4")
                End If
            End Set
        End Property

        Private _miscDocPrint5 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property MiscDocPrint5() As String
            Get
                Return _miscDocPrint5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("MiscDocPrint5", True)
                If value Is Nothing Then value = String.Empty
                If Not _miscDocPrint5.Equals(value) Then
                    _miscDocPrint5 = value
                    PropertyHasChanged("MiscDocPrint5")
                End If
            End Set
        End Property

        Private _isInterfaced As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property IsInterfaced() As String
            Get
                Return _isInterfaced
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IsInterfaced", True)
                If value Is Nothing Then value = String.Empty
                If Not _isInterfaced.Equals(value) Then
                    _isInterfaced = value
                    PropertyHasChanged("IsInterfaced")
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

        Private _updatedBy As String = String.Empty
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
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

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Sub CheckRules()
            ValidationRules.CheckRules()
        End Sub

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of QTD)._fieldList
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

        Public Shared Function BlankQTD() As QTD
            Return New QTD
        End Function

        Public Shared Function NewQTD(ByVal pLineNo As String) As QTD
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("QTD")))
            Return DataPortal.Create(Of QTD)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As QTD
            Dim pLineNo As String = ID.Trim

            Return NewQTD(pLineNo)
        End Function

        Public Shared Function GetQTD(ByVal pLineNo As String) As QTD
            Return DataPortal.Fetch(Of QTD)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As QTD
            Dim pLineNo As String = ID.Trim

            Return GetQTD(pLineNo)
        End Function

        Public Shared Sub DeleteQTD(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As QTD
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("QTD")))

            Me.ApplyEdit()
            QTDInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneQTD(ByVal pLineNo As String) As QTD

            'If QTD.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningQTD As QTD = MyBase.Clone
            cloningQTD._lineNo = 0
            cloningQTD._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningQTD.MarkNew()
            cloningQTD.ApplyEdit()

            cloningQTD.ValidationRules.CheckRules()

            Return cloningQTD
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _lineNo As Integer

            Public Sub New(ByVal pLineNo As String)
                _lineNo = pLineNo.ToInteger

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _lineNo = criteria._lineNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_SO_QTD_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If
                    End Using

                End Using


            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _transRef = dr.GetString("TRANS_REF").TrimEnd
            _qtNo.Text = dr.GetInt32("QT_NO")
            _location = dr.GetString("LOCATION").TrimEnd
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _dueDate.Text = dr.GetInt32("DUE_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _transCd = dr.GetString("TRANS_CD").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _saleQty.Text = dr.GetDecimal("SALE_QTY")
            _unitSale = dr.GetString("UNIT_SALE").TrimEnd
            _stkQty.Text = dr.GetDecimal("STK_QTY")
            _bsp.Text = dr.GetDecimal("BSP")
            _curRate.Text = dr.GetDecimal("CUR_RATE")
            _unitPrice.Text = dr.GetDecimal("UNIT_PRICE")
            _value4.Text = dr.GetDecimal("VALUE_4")
            _net.Text = dr.GetDecimal("NET")
            _discount.Text = dr.GetDecimal("DISCOUNT")
            _shippingFee.Text = dr.GetDecimal("SHIPPING_FEE")
            _taxableAmount.Text = dr.GetDecimal("TAXABLE_AMOUNT")
            _taxRate.Text = dr.GetDecimal("TAX_RATE")
            _taxAmount.Text = dr.GetDecimal("TAX_AMOUNT")
            _value11.Text = dr.GetDecimal("VALUE_11")
            _value12.Text = dr.GetDecimal("VALUE_12")
            _value13.Text = dr.GetDecimal("VALUE_13")
            _value14.Text = dr.GetDecimal("VALUE_14")
            _value15.Text = dr.GetDecimal("VALUE_15")
            _value16.Text = dr.GetDecimal("VALUE_16")
            _value17.Text = dr.GetDecimal("VALUE_17")
            _value18.Text = dr.GetDecimal("VALUE_18")
            _value19.Text = dr.GetDecimal("VALUE_19")
            _lineTotal.Text = dr.GetDecimal("LINE_TOTAL")
            _transactionType = dr.GetString("TRANS_TYPE").TrimEnd
            _delDate.Text = dr.GetInt32("DEL_DATE")
            _ordPrd.Text = dr.GetInt32("ORD_PRD")
            _invNo = dr.GetString("INV_NO").TrimEnd
            _ackPrint = dr.GetString("ACK_PRINT").TrimEnd
            _miscPrint = dr.GetString("MISC_PRINT").TrimEnd
            _idEntered = dr.GetString("ID_ENTERED").TrimEnd
            _idInvoiced = dr.GetString("ID_INVOICED").TrimEnd
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
            _priceBook = dr.GetString("PRICE_BOOK").TrimEnd
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _miscDocPrint1 = dr.GetString("MISC_DOC_PRINT_1").TrimEnd
            _miscDocPrint2 = dr.GetString("MISC_DOC_PRINT_2").TrimEnd
            _miscDocPrint3 = dr.GetString("MISC_DOC_PRINT_3").TrimEnd
            _miscDocPrint4 = dr.GetString("MISC_DOC_PRINT_4").TrimEnd
            _miscDocPrint5 = dr.GetString("MISC_DOC_PRINT_5").TrimEnd
            _isInterfaced = dr.GetString("IS_INTERFACED").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    '    Using cm = ctx.Connection.CreateCommand()

                    '        cm.CommandType = CommandType.StoredProcedure
                    '        cm.CommandText = String.Format("pbs_SO_QTD_{0}_Insert", _DTB)

                    '        cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                    '        AddInsertParameters(cm)
                    '        cm.ExecuteNonQuery()

                    '    End Using

                    Insert(ctx.Connection)
                End Using


            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@TRANS_REF", _transRef.Trim)
            cm.Parameters.AddWithValue("@QT_NO", _qtNo.DBValue)
            cm.Parameters.AddWithValue("@LOCATION", _location.Trim)
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@DUE_DATE", _dueDate.DBValue)
            cm.Parameters.AddWithValue("@STATUS", _status.Trim)
            cm.Parameters.AddWithValue("@TRANS_CD", _transCd.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN", _descriptn.Trim)
            cm.Parameters.AddWithValue("@SALE_QTY", _saleQty.DBValue)
            cm.Parameters.AddWithValue("@UNIT_SALE", _unitSale.Trim)
            cm.Parameters.AddWithValue("@STK_QTY", _stkQty.DBValue)
            cm.Parameters.AddWithValue("@BSP", _bsp.DBValue)
            cm.Parameters.AddWithValue("@CUR_RATE", _curRate.DBValue)
            cm.Parameters.AddWithValue("@UNIT_PRICE", _unitPrice.DBValue)
            cm.Parameters.AddWithValue("@VALUE_4", _value4.DBValue)
            cm.Parameters.AddWithValue("@NET", _net.DBValue)
            cm.Parameters.AddWithValue("@DISCOUNT", _discount.DBValue)
            cm.Parameters.AddWithValue("@SHIPPING_FEE", _shippingFee.DBValue)
            cm.Parameters.AddWithValue("@TAXABLE_AMOUNT", _taxableAmount.DBValue)
            cm.Parameters.AddWithValue("@TAX_RATE", _taxRate.DBValue)
            cm.Parameters.AddWithValue("@TAX_AMOUNT", _taxAmount.DBValue)
            cm.Parameters.AddWithValue("@VALUE_11", _value11.DBValue)
            cm.Parameters.AddWithValue("@VALUE_12", _value12.DBValue)
            cm.Parameters.AddWithValue("@VALUE_13", _value13.DBValue)
            cm.Parameters.AddWithValue("@VALUE_14", _value14.DBValue)
            cm.Parameters.AddWithValue("@VALUE_15", _value15.DBValue)
            cm.Parameters.AddWithValue("@VALUE_16", _value16.DBValue)
            cm.Parameters.AddWithValue("@VALUE_17", _value17.DBValue)
            cm.Parameters.AddWithValue("@VALUE_18", _value18.DBValue)
            cm.Parameters.AddWithValue("@VALUE_19", _value19.DBValue)
            cm.Parameters.AddWithValue("@LINE_TOTAL", _lineTotal.DBValue)
            cm.Parameters.AddWithValue("@TRANS_TYPE", _transactionType.Trim)
            cm.Parameters.AddWithValue("@DEL_DATE", _delDate.DBValue)
            cm.Parameters.AddWithValue("@ORD_PRD", _ordPrd.DBValue)
            cm.Parameters.AddWithValue("@INV_NO", _invNo.Trim)
            cm.Parameters.AddWithValue("@ACK_PRINT", _ackPrint.Trim)
            cm.Parameters.AddWithValue("@MISC_PRINT", _miscPrint.Trim)
            cm.Parameters.AddWithValue("@ID_ENTERED", _idEntered.Trim)
            cm.Parameters.AddWithValue("@ID_INVOICED", _idInvoiced.Trim)
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
            cm.Parameters.AddWithValue("@PRICE_BOOK", _priceBook.Trim)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@MISC_DOC_PRINT_1", _miscDocPrint1.Trim)
            cm.Parameters.AddWithValue("@MISC_DOC_PRINT_2", _miscDocPrint2.Trim)
            cm.Parameters.AddWithValue("@MISC_DOC_PRINT_3", _miscDocPrint3.Trim)
            cm.Parameters.AddWithValue("@MISC_DOC_PRINT_4", _miscDocPrint4.Trim)
            cm.Parameters.AddWithValue("@MISC_DOC_PRINT_5", _miscDocPrint5.Trim)
            cm.Parameters.AddWithValue("@IS_INTERFACED", _isInterfaced.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_SO_QTD_{0}_Update", _DTB)

                    '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                    '    AddInsertParameters(cm)
                    '    cm.ExecuteNonQuery()

                    'End Using

                    Update(ctx.Connection)
                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_lineNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_SO_QTD_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        QTDInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return QTDInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_SO_QTD_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneQTD(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(QTD).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(QTD).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return QTDInfoList.GetQTDInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

#Region "Child"
        Shared Function NewQTDChild(pParentId As String) As QTD
            Dim ret = New QTD
            ret._transRef = pParentId
            ret.MarkAsChild()
            Return ret
        End Function

        Shared Function GetChildQTD(dr As SafeDataReader)
            Dim child = New QTD
            child.FetchObject(dr)
            child.MarkAsChild()
            child.MarkOld()
            Return child
        End Function

        Sub DeleteSelf(cn As SqlConnection)
            Using cm = cn.CreateCommand
                cm.CommandType = CommandType.Text
                cm.CommandText = <sqltext>DELETE pbs_SO_QTD_<%= _DTB %> WHERE LINE_NO = <%= _lineNo %></sqltext>
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Sub Insert(cn As SqlConnection)
            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SO_QTD_{0}_Insert", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

            End Using
        End Sub

        Sub Update(cn As SqlConnection)

            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SO_QTD_{0}_Update", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

            End Using

        End Sub
#End Region
    End Class

End Namespace