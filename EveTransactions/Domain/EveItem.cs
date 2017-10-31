namespace EveTransactions.Domain
{
    public class EveItem
    {
        #region Properties

        public long EveItemID { get; set; }
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public bool TrackPrices { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double JitaBuyPrice { get; set; }
        public double JitaSellPrice { get; set; }
        public double BuildPrice { get; set; }
        public long CurrentStock { get; set; }
        public long TargetStock { get; set; }

        #endregion

        public void ResetPrices()
        {
            BuyPrice = 0;
            SellPrice = 0;
            JitaBuyPrice = 0;
            JitaSellPrice = 0;
        }
    }
}
