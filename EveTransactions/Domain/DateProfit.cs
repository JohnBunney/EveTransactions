namespace EveTransactions.Domain
{
    public class DateProfit
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Profit { get; set; }

        public string Date
        {
            get { return string.Format("{0:d4}-{1:d2}-{2:d2}", Year, Month, Day); }
        }
    }

}
