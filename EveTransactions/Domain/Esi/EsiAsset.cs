using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveTransactions.Domain.Esi
{
    public class EsiAsset
    {
        public long type_id { get; set; }
        public string location_id { get; set; }
        public string location_type { get; set; }
        public long item_id { get; set; }
        public string location_flag { get; set; }
        public bool is_singleton { get; set; }
        public int quantity { get; set; }
    }
}
