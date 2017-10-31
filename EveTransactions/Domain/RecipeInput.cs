
namespace EveTransactions.Domain
{
    /// <summary>
    /// Just a list of names of things that can be invented
    /// </summary>
    public class RecipeInput
    {
        #region Properties

        public long RecipeInputID { get; set; }
        public long RecipeID { get; set; }
        public string TypeName { get; set; }  // The name of the input used for the invention
        public long Quantity { get; set; }

        #endregion

        #region Constructors

        protected RecipeInput()
        { }

        public RecipeInput(long recipeId, string typeName, long quantity)
        {
            RecipeID = recipeId;
            TypeName = typeName;
            Quantity = quantity;
        }

        #endregion

    }

}
