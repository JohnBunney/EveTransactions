namespace EveTransactions.Domain
{
    public class OrderFulfilment
    {
        #region Properties

        public BuyOrder BuyOrder { get; set; }
        public SellOrder SellOrder { get; set; }
        public long MatchedQuantity { get; set; }
        
        #endregion

        #region Constructor

        public OrderFulfilment(BuyOrder buyOrder, SellOrder sellOrder, long matchedQuantity)
        {
            BuyOrder = buyOrder;
            SellOrder = sellOrder;
            MatchedQuantity = matchedQuantity;
        }

        #endregion

        #region Methods

        public string PrintProfit()
        {
            double profit = MatchedQuantity * (SellOrder.UnitPrice - BuyOrder.UnitPrice);

            var heldFor = SellOrder.OrderDate - BuyOrder.OrderDate;

            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", 
                BuyOrder.Item.ItemName,
                MatchedQuantity,
                BuyOrder.UnitPrice,
                BuyOrder.OrderDate,
                SellOrder.UnitPrice,
                SellOrder.OrderDate,
                profit,
                (profit / MatchedQuantity),
                heldFor.TotalHours,
                ((profit/MatchedQuantity)/heldFor.TotalHours)
                );
        }

        public ProfitDTO GetProfit()
        {
            var totalProfit = MatchedQuantity * (SellOrder.UnitPrice - BuyOrder.UnitPrice);
            var heldFor = SellOrder.OrderDate - BuyOrder.OrderDate;
            var profitPercentage = ((SellOrder.UnitPrice / BuyOrder.UnitPrice) - 1) * 100;

            ProfitDTO profit = new ProfitDTO();
            profit.BuyDate = BuyOrder.OrderDate;
            profit.BuyPrice = BuyOrder.UnitPrice;
            profit.HoursHeld = heldFor.TotalHours;
            profit.ItemName = BuyOrder.Item.ItemName;
            profit.ProfitPerUnit = totalProfit / MatchedQuantity;
            profit.ProfitPerUnitPerHourHeld = totalProfit / MatchedQuantity / heldFor.TotalHours;
            profit.Quantity = MatchedQuantity;
            profit.SellDate = SellOrder.OrderDate;
            profit.SellPrice = SellOrder.UnitPrice;
            profit.TotalProfit = totalProfit;
            profit.TotalProfitPerHourHeld = totalProfit / heldFor.TotalHours;
            profit.ProfitPercentage = profitPercentage;
            profit.ProfitPercentagePerHourHeld = profitPercentage / heldFor.TotalHours;

            return profit;
        }

        #endregion

    }
}
