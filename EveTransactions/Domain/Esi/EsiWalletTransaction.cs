using System;

namespace EveTransactions.Domain.Esi
{
    public class EsiWalletTransaction
    {

        public long client_id { get; set; }
        public DateTime date { get; set; }
        public bool is_buy { get; set; }
        public bool is_personal { get; set; }
        public long journal_ref_id { get; set; }
        public long location_id { get; set; }
        public long quantity { get; set; }
        public long transaction_id { get; set; }
        public long type_id { get; set; }
        public string type_name { get; set; }  // ESI doesn't provide this, we'll have to look it up
        public double unit_price { get; set; }

    }
}
