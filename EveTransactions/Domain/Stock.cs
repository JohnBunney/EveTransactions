using System;

namespace EveTransactions.Domain
{

    public class Stock
    {

        #region Properties

        public long StockID { get; set; }
        public string TypeName { get; set; }  // Unit Name
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }

        #endregion

        #region Constructors

        protected Stock()
        { }

        public Stock(EveWalletTransaction walletTransaction)
        {
            TypeName = walletTransaction.TypeName;
            Date = walletTransaction.Date;
            Price = (decimal)walletTransaction.Price;
            Quantity = walletTransaction.Quantity;
        }

        public Stock(string typeName, DateTime purchaseDate, long quantity)
        {
            TypeName = typeName;
            Date = purchaseDate;
            Quantity = quantity;
            Price = 0; // Found/looted stock
        }

        #endregion

    }

}
