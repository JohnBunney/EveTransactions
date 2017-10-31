using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveTransactions.Domain
{
    public class UrlCache
    {
        public long UrlCacheID { get; set; }
        public string Url { get; set; }
        public DateTime CacheUntil { get; set; }
    }
}
