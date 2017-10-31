namespace EveTransactions.Domain
{
    public class MarketItem
    {
        #region Properties

        public long MarketItemID { get; set; }
        public long TypeID { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public bool Disabled { get; set; }

        #endregion

        #region Constructors

        public MarketItem()
        { }

        #endregion

    }
}
