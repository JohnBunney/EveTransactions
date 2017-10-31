namespace EveTransactions.Domain
{
    public class BuildItem
    {
        public const decimal SalesFeeMultiplier = 0.9688M;

        public string TypeName { get; set; }

        public long Blueprints { get; set; }

        public long QuantityNeeded { get; set; }

        public bool Research { get; set; }

        public long OutputMultiplier { get; set; }

        public decimal ProfitPerHour
        {
            get
            {
                if (UnitBuildTime == 0) return ProfitPerUnit;

                return ProfitPerUnit / UnitBuildTime * OutputMultiplier;
            }
        }

        public decimal ProfitPerBuildLimit
        {
            get
            {
                if (UnitBuildTime == 0) return ProfitPerUnit;

                return ProfitPerUnit * BuildLimit;
            }
        }

        public long BuildLimit { get; set; }

        public decimal MarketBuyPrice { get; set; }

        public decimal MarketSellPrice { get; set; }

        public decimal BuildPrice { get; set; }

        public decimal ProfitPerUnit
        {
            get { return (MarketSellPrice * SalesFeeMultiplier) - BuildPrice; }
        }

        public decimal UnitBuildTime { get; set; }

        public string Notes { get; set; }

        public BuildItem(string typeName, long outputMultiplier)
        {
            TypeName = typeName;
            QuantityNeeded = 0;
            MarketSellPrice = 0;
            MarketBuyPrice = 0;
            BuildPrice = 0;
            Notes = string.Empty;
            OutputMultiplier = outputMultiplier;
        }

    }

}
