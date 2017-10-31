using System.Data.Entity;
using EveTransactions.Domain;

namespace EveTransactions.Repository
{
    public class EveRepository : DbContext
    {

        public DbSet<EveWalletTransaction> WalletTransactions { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Reward> Rewards { get; set; }

        public DbSet<MarketItem> MarketItems { get; set; }

        public DbSet<MarketItemPrice> MarketItemPrices { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeInput> RecipeInputs { get; set; }

        public DbSet<InventedBlueprint> InventedBluePrints { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<EveItem> EveItems { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<UrlCache> UrlCaches { get; set; }

    }
}
