using System;

namespace EveTransactions.Domain.Esi
{
    public class EsiWalletJournal
    {
        public decimal amount { get; set; }
        public double balance { get; set; }
        public DateTime date { get; set; }
        public long first_party_id { get; set; }
        public string first_party_type { get; set; }
        public long second_party_id { get; set; }
        public string second_party_type { get; set; }
        public double tax { get; set; }
        public long ref_id { get; set; }
        public string ref_type { get; set; }  // ESI doesn't provide this, we'll have to look it up
    }
}
