using System;

namespace EveTransactions.Domain
{
    public class Sale
    {

        #region Properties

        public long SaleID { get; set; }
        public string TypeName { get; set; }  // Unit Name
        public DateTime BuyDate { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime SellDate { get; set; }
        public decimal SellPrice { get; set; }
        public long Quantity { get; set; }

        public decimal ProfitPerUnit { get; set; }
        public decimal BrokerFeePerUnit { get; set; }
        public decimal SalesTaxPerUnit { get; set; }
        public decimal NetProfitPerUnit { get; set; }

        public decimal TotalProfit { get; set; }
        public decimal BrokerFee { get; set; }
        public decimal SalesTax { get; set; }
        public decimal NetProfit { get; set; }

        public decimal HoursHeld { get; set; }

        #endregion

        #region Constructors

        protected Sale()
        { }

        public Sale(Stock stock, EveWalletTransaction walletTransaction, long quantity)
        {
            TypeName = stock.TypeName;
            BuyDate = stock.Date;
            BuyPrice = stock.Price;
            SellDate = walletTransaction.Date;
            SellPrice = (decimal)walletTransaction.Price;
            Quantity = quantity;

            const decimal BrokerFeeRate = 0.0065m;
            const decimal SalesTaxRate = 0.0105m;

            ProfitPerUnit= SellPrice - BuyPrice;
            TotalProfit = ProfitPerUnit * Quantity;

            BrokerFeePerUnit = BuyPrice * BrokerFeeRate;
            BrokerFee = BrokerFeePerUnit * Quantity;

            SalesTaxPerUnit = SellPrice * SalesTaxRate;
            SalesTax = SalesTaxPerUnit * Quantity;

            NetProfit = TotalProfit - BrokerFee - SalesTax;
            NetProfitPerUnit = ProfitPerUnit - BrokerFeePerUnit - SalesTaxPerUnit;

            TimeSpan heldFor = SellDate - BuyDate;
            HoursHeld = (decimal)heldFor.TotalHours;
        }

        #endregion

    }
}
