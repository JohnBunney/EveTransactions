using System;

namespace EveTransactions.Domain
{
    public class SellOrder
    {
        #region Properties

        public long SellOrderID { get; set; }
        public long ItemID { get; set; }
        public long Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        #endregion

        #region Constructor

        public SellOrder (long itemID, long quantity, double unitPrice, DateTime orderDate)
        {
            ItemID = itemID;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = unitPrice * quantity;
            OrderDate = orderDate;
        }

        #endregion

    }
}
