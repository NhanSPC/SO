
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports System.Text.RegularExpressions

Namespace SO

    <Serializable()> _
    Public Class QTDInfo
        Inherits Csla.ReadOnlyBase(Of QTDInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _recType As String = String.Empty
        Public ReadOnly Property RecType() As String
            Get
                Return _recType
            End Get
        End Property

        Private _transRef As String = String.Empty
        Public ReadOnly Property TransRef() As String
            Get
                Return _transRef
            End Get
        End Property

        Private _transLine As String = String.Empty
        Public ReadOnly Property TransLine() As String
            Get
                Return _transLine
            End Get
        End Property

        Private _detailId As String = String.Empty
        Public ReadOnly Property DetailId() As String
            Get
                Return _detailId
            End Get
        End Property

        Private _location As String = String.Empty
        Public ReadOnly Property Location() As String
            Get
                Return _location
            End Get
        End Property

        Private _itemCode As String = String.Empty
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        Private _dueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property DueDate() As String
            Get
                Return _dueDate.DateViewFormat
            End Get
        End Property

        Private _status As String = String.Empty
        Public ReadOnly Property Status() As String
            Get
                Return _status
            End Get
        End Property

        Private _transCd As String = String.Empty
        Public ReadOnly Property TransCd() As String
            Get
                Return _transCd
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value1() As String
            Get
                Return _value1.Text
            End Get
        End Property

        Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value2() As String
            Get
                Return _value2.Text
            End Get
        End Property

        Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value3() As String
            Get
                Return _value3.Text
            End Get
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value4() As String
            Get
                Return _value4.Text
            End Get
        End Property

        Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value5() As String
            Get
                Return _value5.Text
            End Get
        End Property

        Private _value6 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value6() As String
            Get
                Return _value6.Text
            End Get
        End Property

        Private _value7 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value7() As String
            Get
                Return _value7.Text
            End Get
        End Property

        Private _value8 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value8() As String
            Get
                Return _value8.Text
            End Get
        End Property

        Private _value9 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value9() As String
            Get
                Return _value9.Text
            End Get
        End Property

        Private _value10 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value10() As String
            Get
                Return _value10.Text
            End Get
        End Property

        Private _value11 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value11() As String
            Get
                Return _value11.Text
            End Get
        End Property

        Private _value12 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value12() As String
            Get
                Return _value12.Text
            End Get
        End Property

        Private _value13 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value13() As String
            Get
                Return _value13.Text
            End Get
        End Property

        Private _value14 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value14() As String
            Get
                Return _value14.Text
            End Get
        End Property

        Private _value15 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value15() As String
            Get
                Return _value15.Text
            End Get
        End Property

        Private _value16 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value16() As String
            Get
                Return _value16.Text
            End Get
        End Property

        Private _value17 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value17() As String
            Get
                Return _value17.Text
            End Get
        End Property

        Private _value18 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value18() As String
            Get
                Return _value18.Text
            End Get
        End Property

        Private _value19 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value19() As String
            Get
                Return _value19.Text
            End Get
        End Property

        Private _value20 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value20() As String
            Get
                Return _value20.Text
            End Get
        End Property

        Private _transactionType As String = String.Empty
        Public ReadOnly Property TransactionType() As String
            Get
                Return _transactionType
            End Get
        End Property

        Private _delDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property DelDate() As String
            Get
                Return _delDate.DateViewFormat
            End Get
        End Property

        Private _invDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property InvDate() As String
            Get
                Return _invDate.DateViewFormat
            End Get
        End Property

        Private _ordPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        Public ReadOnly Property OrdPrd() As String
            Get
                Return _ordPrd.Text
            End Get
        End Property

        Private _invPrd As SmartPeriod = New pbs.Helper.SmartPeriod()
        Public ReadOnly Property InvPrd() As String
            Get
                Return _invPrd.Text
            End Get
        End Property

        Private _unitSale As String = String.Empty
        Public ReadOnly Property UnitSale() As String
            Get
                Return _unitSale
            End Get
        End Property

        Private _invNo As String = String.Empty
        Public ReadOnly Property InvNo() As String
            Get
                Return _invNo
            End Get
        End Property

        Private _ackPrint As String = String.Empty
        Public ReadOnly Property AckPrint() As String
            Get
                Return _ackPrint
            End Get
        End Property

        Private _miscPrint As String = String.Empty
        Public ReadOnly Property MiscPrint() As String
            Get
                Return _miscPrint
            End Get
        End Property

        Private _allocRef As String = String.Empty
        Public ReadOnly Property AllocRef() As String
            Get
                Return _allocRef
            End Get
        End Property

        Private _recptRef As String = String.Empty
        Public ReadOnly Property RecptRef() As String
            Get
                Return _recptRef
            End Get
        End Property

        Private _lineAnal As String = String.Empty
        Public ReadOnly Property LineAnal() As String
            Get
                Return _lineAnal
            End Get
        End Property

        Private _accntCode As String = String.Empty
        Public ReadOnly Property AccntCode() As String
            Get
                Return _accntCode
            End Get
        End Property

        Private _assetCode As String = String.Empty
        Public ReadOnly Property AssetCode() As String
            Get
                Return _assetCode
            End Get
        End Property

        Private _assSubCode As String = String.Empty
        Public ReadOnly Property AssSubCode() As String
            Get
                Return _assSubCode
            End Get
        End Property

        Private _assetInd As String = String.Empty
        Public ReadOnly Property AssetInd() As String
            Get
                Return _assetInd
            End Get
        End Property

        Private _idEntered As String = String.Empty
        Public ReadOnly Property IdEntered() As String
            Get
                Return _idEntered
            End Get
        End Property

        Private _idInvoiced As String = String.Empty
        Public ReadOnly Property IdInvoiced() As String
            Get
                Return _idInvoiced
            End Get
        End Property

        Private _linkedText As String = String.Empty
        Public ReadOnly Property LinkedText() As String
            Get
                Return _linkedText
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

        Private _assemblyInd As String = String.Empty
        Public ReadOnly Property AssemblyInd() As String
            Get
                Return _assemblyInd
            End Get
        End Property

        Private _assemblyDesc As String = String.Empty
        Public ReadOnly Property AssemblyDesc() As String
            Get
                Return _assemblyDesc
            End Get
        End Property

        Private _assemblyLevel As String = String.Empty
        Public ReadOnly Property AssemblyLevel() As String
            Get
                Return _assemblyLevel
            End Get
        End Property

        Private _priceBook As String = String.Empty
        Public ReadOnly Property PriceBook() As String
            Get
                Return _priceBook
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _saleQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property SaleQty() As String
            Get
                Return _saleQty.Text
            End Get
        End Property

        Private _stkQty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property StkQty() As String
            Get
                Return _stkQty.Text
            End Get
        End Property

        Private _totValue As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property TotValue() As String
            Get
                Return _totValue.Text
            End Get
        End Property

        Private _dispVal1 As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property DispVal1() As String
            Get
                Return _dispVal1.Text
            End Get
        End Property

        Private _dispVal2 As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property DispVal2() As String
            Get
                Return _dispVal2.Text
            End Get
        End Property

        Private _dispVal3 As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property DispVal3() As String
            Get
                Return _dispVal3.Text
            End Get
        End Property

        Private _miscDocPrint1 As String = String.Empty
        Public ReadOnly Property MiscDocPrint1() As String
            Get
                Return _miscDocPrint1
            End Get
        End Property

        Private _miscDocPrint2 As String = String.Empty
        Public ReadOnly Property MiscDocPrint2() As String
            Get
                Return _miscDocPrint2
            End Get
        End Property

        Private _miscDocPrint3 As String = String.Empty
        Public ReadOnly Property MiscDocPrint3() As String
            Get
                Return _miscDocPrint3
            End Get
        End Property

        Private _miscDocPrint4 As String = String.Empty
        Public ReadOnly Property MiscDocPrint4() As String
            Get
                Return _miscDocPrint4
            End Get
        End Property

        Private _miscDocPrint5 As String = String.Empty
        Public ReadOnly Property MiscDocPrint5() As String
            Get
                Return _miscDocPrint5
            End Get
        End Property

        Private _dNoteNo As String = String.Empty
        Public ReadOnly Property DNoteNo() As String
            Get
                Return _dNoteNo
            End Get
        End Property

        Private _isInterfaced As String = String.Empty
        Public ReadOnly Property IsInterfaced() As String
            Get
                Return _isInterfaced
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
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
            Return String.Format("{0}:{1}", _transRef.Trim, _transLine.Trim)
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            'Dim m As MatchCollection = Regex.Matches(ID, pbsRegex.AlphaNumericExt)
            'Dim pTransRef As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).Value.Trim
            'Dim pTransLine As String = Regex.Matches(ID, pbsRegex.AlphaNumericExt).NextMatch.Value.Trim

            Dim pTransRef As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).Value
            Dim pTransLine As String = Regex.Match(ID, pbsRegex.AlphaNumericExt2).NextMatch.Value

            If _transRef.Trim < pTransRef Then Return -1
            If _transRef.Trim > pTransRef Then Return 1
            If _transLine.Trim < pTransLine Then Return -1
            If _transLine.Trim > pTransLine Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return String.Format("{0}.{1}", _transRef, _transLine)
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return String.Format("{0}.{1}", _transRef, _transLine)
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("{0}.{1}", _transRef, _transLine)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            QTDInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetQTDInfo(ByVal dr As SafeDataReader) As QTDInfo
            Return New QTDInfo(dr)
        End Function

        Friend Shared Function EmptyQTDInfo(Optional ByVal pTransRef As String = "", Optional ByVal pTransLine As String = "") As QTDInfo
            Dim info As QTDInfo = New QTDInfo
            With info
                ._transRef = pTransRef
                ._transLine = pTransLine

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
            _recType = dr.GetString("REC_TYPE").TrimEnd
            _transRef = dr.GetString("TRANS_REF").TrimEnd
            _transLine = dr.GetString("TRANS_LINE").TrimEnd
            _detailId = dr.GetString("DETAIL_ID").TrimEnd
            _location = dr.GetString("LOCATION").TrimEnd
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _dueDate.Text = dr.GetInt32("DUE_DATE")
            _status = dr.GetString("STATUS").TrimEnd
            _transCd = dr.GetString("TRANS_CD").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _value1.Text = dr.GetDecimal("VALUE_1")
            _value2.Text = dr.GetDecimal("VALUE_2")
            _value3.Text = dr.GetDecimal("VALUE_3")
            _value4.Text = dr.GetDecimal("VALUE_4")
            _value5.Text = dr.GetDecimal("VALUE_5")
            _value6.Text = dr.GetDecimal("VALUE_6")
            _value7.Text = dr.GetDecimal("VALUE_7")
            _value8.Text = dr.GetDecimal("VALUE_8")
            _value9.Text = dr.GetDecimal("VALUE_9")
            _value10.Text = dr.GetDecimal("VALUE_10")
            _value11.Text = dr.GetDecimal("VALUE_11")
            _value12.Text = dr.GetDecimal("VALUE_12")
            _value13.Text = dr.GetDecimal("VALUE_13")
            _value14.Text = dr.GetDecimal("VALUE_14")
            _value15.Text = dr.GetDecimal("VALUE_15")
            _value16.Text = dr.GetDecimal("VALUE_16")
            _value17.Text = dr.GetDecimal("VALUE_17")
            _value18.Text = dr.GetDecimal("VALUE_18")
            _value19.Text = dr.GetDecimal("VALUE_19")
            _value20.Text = dr.GetDecimal("VALUE_20")
            _transactionType = dr.GetString("TRANS_TYPE").TrimEnd
            _delDate.Text = dr.GetInt32("DEL_DATE")
            _invDate.Text = dr.GetInt32("INV_DATE")
            _ordPrd.Text = dr.GetInt32("ORD_PRD")
            _invPrd.Text = dr.GetInt32("INV_PRD")
            _unitSale = dr.GetString("UNIT_SALE").TrimEnd
            _invNo = dr.GetString("INV_NO").TrimEnd
            _ackPrint = dr.GetString("ACK_PRINT").TrimEnd
            _miscPrint = dr.GetString("MISC_PRINT").TrimEnd
            _allocRef = dr.GetString("ALLOC_REF").TrimEnd
            _recptRef = dr.GetString("RECPT_REF").TrimEnd
            _lineAnal = dr.GetString("LINE_ANAL").TrimEnd
            _accntCode = dr.GetString("ACCNT_CODE").TrimEnd
            _assetCode = dr.GetString("ASSET_CODE").TrimEnd
            _assSubCode = dr.GetString("ASS_SUB_CODE").TrimEnd
            _assetInd = dr.GetString("ASSET_IND").TrimEnd
            _idEntered = dr.GetString("ID_ENTERED").TrimEnd
            _idInvoiced = dr.GetString("ID_INVOICED").TrimEnd
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
            _assemblyInd = dr.GetString("ASSEMBLY_IND").TrimEnd
            _assemblyDesc = dr.GetString("ASSEMBLY_DESC").TrimEnd
            _assemblyLevel = dr.GetString("ASSEMBLY_LEVEL").TrimEnd
            _priceBook = dr.GetString("PRICE_BOOK").TrimEnd
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _saleQty.Text = dr.GetDecimal("SALE_QTY")
            _stkQty.Text = dr.GetDecimal("STK_QTY")
            _totValue.Text = dr.GetInt32("TOT_VALUE")
            _dispVal1.Text = dr.GetInt32("DISP_VAL_1")
            _dispVal2.Text = dr.GetInt32("DISP_VAL_2")
            _dispVal3.Text = dr.GetInt32("DISP_VAL_3")
            _miscDocPrint1 = dr.GetString("MISC_DOC_PRINT_1").TrimEnd
            _miscDocPrint2 = dr.GetString("MISC_DOC_PRINT_2").TrimEnd
            _miscDocPrint3 = dr.GetString("MISC_DOC_PRINT_3").TrimEnd
            _miscDocPrint4 = dr.GetString("MISC_DOC_PRINT_4").TrimEnd
            _miscDocPrint5 = dr.GetString("MISC_DOC_PRINT_5").TrimEnd
            _dNoteNo = dr.GetString("D_NOTE_NO").TrimEnd
            _isInterfaced = dr.GetString("IS_INTERFACED").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Sub New()
        End Sub


#End Region ' Factory Methods

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _transRef)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace