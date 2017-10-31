using System;

namespace EveTransactions.Domain
{
    public class ProfitDTO
    {

        #region Properties

        public string ItemName { get; set; }
        public long Quantity { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public double TotalProfit { get; set; }
        public double ProfitPerUnit { get; set; }
        public double HoursHeld { get; set; }
        public double TotalProfitPerHourHeld { get; set; }
        public double ProfitPerUnitPerHourHeld { get; set; }
        public double ProfitPercentage { get; set; }
        public double ProfitPercentagePerHourHeld { get; set; }

        #endregion

    }
}
