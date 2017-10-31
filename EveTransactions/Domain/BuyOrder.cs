using System;

namespace EveTransactions.Domain
{
    public class BuyOrder
    {

        #region Properties

        public long BuyOrderID { get; set; }
        public Item Item { get; set; }
        public long Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public long OutstandingQuantity { get; set; }
        public DateTime OrderDate { get; set; }

        #endregion

        #region Constructor

        public BuyOrder (Item item, long quantity, double unitPrice, DateTime orderDate)
        {
            Item = item;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = unitPrice * quantity;
            OutstandingQuantity = quantity;
            OrderDate = orderDate;
        }

        #endregion

        #region Methods

        public long ReduceOutstandingQuantity(long quantity)
        {
            if (quantity >= OutstandingQuantity)
            {
                long remainingQuantity = OutstandingQuantity - quantity;
                OutstandingQuantity = 0;
                return remainingQuantity;
            }

            OutstandingQuantity = OutstandingQuantity - quantity;
            return 0;  // We've allocated all of the input quantity
        }

        #endregion

    }

}
