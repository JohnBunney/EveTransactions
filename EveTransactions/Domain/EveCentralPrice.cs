using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveTransactions.Domain
{
    public class EveCentralPrice
    {

        public long TypeID { get; set; }
        public string Name { get; set; }  
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double Volume { get; set; }

    }
}
