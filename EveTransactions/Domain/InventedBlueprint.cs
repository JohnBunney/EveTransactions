using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EveTransactions.Domain
{
    public class InventedBlueprint
    {

        #region Properties

        //public long InventedBlueprintID { get; set; }

        [Key]
        public string TypeName { get; set; }  // Unit Name
        public decimal TotalCost { get; set; }
        public decimal AverageCost { get; set; }
        public long NumberOfInventionAttempts { get; set; }
        public long SuccessfulAttempts { get; set; }
        public long OutputMultiplier { get; set; }

        #endregion

        #region Constructors

        public InventedBlueprint()
        { 

        }

        public InventedBlueprint(string typeName)
        {
            TypeName = typeName;
            OutputMultiplier = 10; // As a default
        }

        #endregion

        #region Methods

        public void AddAttempts(long numberOfAttempts, long numberOfSuccesfulAttempts, decimal cost)
        {
            TotalCost += cost;
            NumberOfInventionAttempts += numberOfAttempts;
            SuccessfulAttempts += numberOfSuccesfulAttempts;
            AverageCost = TotalCost / (NumberOfInventionAttempts * OutputMultiplier) ;
        }

        #endregion

    }
}
