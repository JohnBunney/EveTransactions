using System;

namespace EveTransactions.Domain
{
    public class Reward
    {

        #region Properties

        public long RewardID { get; set; }
        public string Description { get; set; }  // Unit Name
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public long EveJournalID { get; set; }

        #endregion

        #region Constructors

        public Reward()
        { }

        #endregion

    }
}
