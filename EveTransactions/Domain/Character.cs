using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveTransactions.Domain
{
    public class Character
    {
        #region Properties

        public long CharacterID { get; set; }
        public string Name { get; set; }
        public long EveCharacterID { get; set; }
        public string KeyID { get; set; }
        public string vCode { get; set; }

        #endregion
    }
}
