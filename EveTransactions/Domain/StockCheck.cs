namespace EveTransactions.Domain
{
    public class StockCheck
    {
        #region Properties

        public string ItemName { get; set; }
        public long AssumedStock { get; set; }

        public long ActualStock { get; set; }

        public long Difference => ActualStock - AssumedStock;

        #endregion

        public StockCheck(string itemName, long assumedStock, long actualStock)
        {
            ItemName = itemName;
            AssumedStock = assumedStock;
            ActualStock = actualStock;
        }
    }
}
