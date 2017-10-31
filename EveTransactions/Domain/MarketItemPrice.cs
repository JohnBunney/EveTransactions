using System;

namespace EveTransactions.Domain
{
    public class MarketItemPrice
    {
        #region Properties

        public long MarketItemPriceID { get; set; }
        public long TypeID { get; set; }
        public string Name { get; set; }  // Unit Name
        public string Group { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double Volume { get; set; }
        
        public double ProfitPerUnit { get; set; }
        public double ProfitPercent { get; set; }
        public double ProfitVolume { get; set; }  // Profit * Volume
        public double ProfitVolumePercent { get; set; } // Profit * Volume * Percent
        
        #endregion

        #region Constructors

        protected MarketItemPrice()
        { }

        public MarketItemPrice(long typeID, string name, string group, double buyPrice, double sellPrice, double volume)
        {
            TypeID = typeID;
            Name = name;
            Group = group;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Volume = volume;

            // Calculated Properties
            ProfitPerUnit= SellPrice - BuyPrice;
            ProfitPercent = (SellPrice / BuyPrice) - 1;
            ProfitVolume = ProfitPerUnit * Volume;
            ProfitVolumePercent = ProfitVolume * Math.Abs(ProfitPercent);
        }

        #endregion


    }
}
