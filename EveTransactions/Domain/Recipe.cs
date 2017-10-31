
namespace EveTransactions.Domain
{
    /// <summary>
    /// Just a list of names of things that can be invented
    /// </summary>
    public class Recipe
    {
        #region Properties

        public long RecipeID { get; set; }
        public string TypeName { get; set; }  // Unit Name
        public long OutputMultiplier { get; set; }
        public long MaximumStock { get; set; }
        public string PrimaryManufacturer { get; set; }
        public decimal BuildTimeHours { get; set; }
        public long MaxRuns { get; set; }
        
        #endregion

        #region Constructors

        protected Recipe()
        { }

        public Recipe(string typeName)
        {
            TypeName = typeName;
        }

        #endregion

    }

}
