Imports pbs.BO
Imports pbs.Helper
Imports pbs.Helper.Interfaces

Namespace SO
    Public Class QT2SO
        Implements IRunable

        Public ReadOnly Property Notes As String Implements IRunable.Notes
            Get
                Return <Syntax>
                           This function convert one Quotation to Sales Order
                           Syntax: pbs.BO.SO.QT2SO?LineNo=[LineNo]&amp;$Show=Y/N
                       </Syntax>
            End Get
        End Property

        Public Sub Run(args As pbsCmdArgs) Implements IRunable.Run
            Dim _lineNo = args.GetValueByKey("LineNo", String.Empty)
            Dim _show = args.GetValueBySystemKey("$Show", "N")

            'convert QT to SOH
            Dim _qt = QT.GetQT(_lineNo)
            Dim _soh = SOH.NewSOH(String.Empty)

            _soh.TransCode = String.Empty
            '_so.TransRef = String.Empty
            _soh.OrderNo = _qt.OrderNo
            _soh.OrderDate = _qt.OrderDate
            _soh.Status = _qt.Status
            _soh.TransDate = _qt.TransDate
            _soh.AckDate = _qt.AckDate
            _soh.InvDate = String.Empty
            _soh.PayDate = String.Empty
            _soh.QuotationRef = _qt.TransRef
            _soh.DateQuoted = _qt.DateQuoted
            _soh.CustCode = _qt.CustCode
            _soh.CustRef = String.Empty
            _soh.DNoteNo = _qt.DNoteNo
            _soh.PickDate = String.Empty
            _soh.DelDate = String.Empty
            _soh.DelivAdd = _qt.DelivAdd
            _soh.DelivAddress = _qt.DelivAddress
            _soh.QuoteExpiryDate = _qt.QuoteExpiryDate
            _soh.PeriodQuoted = _qt.PeriodQuoted
            _soh.ConvCode = _qt.ConvCode
            _soh.Comments = _qt.Comments

            'convert QTD to SOD
            Dim _qtd = CType((From line In QTDInfoList.GetQTDInfoList Where line.QtNo = _qt.LineNo), QTD)
            Dim _sod = _soh.Lines.AddNew
            
            _sod.AccntCode = String.Empty
            _sod.AckPrint = _qtd.AckPrint
            _sod.AssemblyDesc = String.Empty
            _sod.AssemblyLevel = String.Empty
            _sod.AssetCode = String.Empty
            _sod.AssetInd = String.Empty
            _sod.AssSubCode = String.Empty
            _sod.ConvCode = _qtd.ConvCode
            _sod.CurrencyRate = _qtd.CurRate
            _sod.DelDate = _qtd.DelDate
            _sod.Descriptn = _qtd.Descriptn
            _sod.Discount = _qtd.Discount
            '_sod.DispValue1
            '_sod.DispValue2
            '_sod.DispValue3
            _sod.DNoteNo = String.Empty
            _sod.DueDate = _qtd.DueDate
            _sod.InvDate = String.Empty
            _sod.InvNo = _qtd.InvNo
            _sod.InvPrd = String.Empty
            _sod.ItemCode = _qtd.ItemCode
            '_sod.ItemInfo 
            _sod.LineTotal = _qtd.LineTotal
            _sod.Location = _qtd.Location
            _sod.Net = _qtd.Net
            _sod.RecptRef = String.Empty
            _sod.SaleQty = _qtd.SaleQty
            _sod.ShippingFee = _qtd.ShippingFee
            '_sod.Status
            _sod.StkQty = _qtd.StkQty
            _sod.TaxableAmount = _qtd.TaxableAmount
            _sod.TaxAmount = _qtd.TaxAmount
            _sod.TaxRate = _qtd.TaxRate
            '_sod.TotalValue
            '_sod.TransLine
            '_sod.TransRef
            '_sod.TransType
            _sod.UnitBasePrice = String.Empty
            _sod.UnitPrice = _qtd.UnitPrice
            _sod.UnitSale = _qtd.UnitSale



        End Sub
    End Class
End Namespace