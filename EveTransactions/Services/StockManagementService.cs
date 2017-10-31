using System;
using System.Linq;
using EveTransactions.Domain;
using EveTransactions.Repository;

namespace EveTransactions.Services
{
    public class StockManagementService
    {

        public static void AddStock(string name, DateTime date, long quantity, decimal price)
        {
            var repository = new EveRepository();

            // ReSharper disable once UseObjectOrCollectionInitializer
            Stock newStock = new Stock(name, date, quantity);
            newStock.Price = (decimal)price;

            repository.Stocks.Add(newStock);

            EveItem item = repository.EveItems.FirstOrDefault(x => x.ItemName == name);
            if (item != null)
            {
                item.CurrentStock += quantity;
            }

            repository.SaveChanges();
        }

        public static void AddStockUsingTotalPrice(string name, DateTime date, int quantity, double price)
        {
            decimal pricePerUnit = (decimal)price / quantity;

            AddStock(name, date, quantity, pricePerUnit);
        }

        public static decimal RemoveStock(string name, long quantity)
        {
            var repository = new EveRepository();

            EveItem item = repository.EveItems.FirstOrDefault(x => x.ItemName == name);
            if (item != null)
            {
                item.CurrentStock -= quantity;
                if (item.CurrentStock < 0) item.CurrentStock = 0;
                repository.SaveChanges();
            }

            decimal stockCost = 0;

            var outstandingQuantity = quantity;

            while (outstandingQuantity > 0)
            {
                var matchingStock = repository.Stocks.OrderBy(x => x.StockID).Where(s => s.TypeName == name);

                var stock = matchingStock.FirstOrDefault();

                if (stock != null)
                {
                    if (stock.Quantity > outstandingQuantity)
                    {
                        // Reduce the stock
                        stock.Quantity = stock.Quantity - outstandingQuantity;
                        repository.SaveChanges();

                        stockCost += stock.Price * outstandingQuantity;

                        outstandingQuantity = 0;
                    }
                    else if (stock.Quantity == outstandingQuantity)
                    {
                        // Remove the stock altogether
                        repository.Stocks.Remove(stock);
                        repository.SaveChanges();

                        stockCost += stock.Price * outstandingQuantity;

                        outstandingQuantity = 0;
                    }
                    else
                    {
                        // Use the entirity of the current stock item, and then we'll look for more stock

                        outstandingQuantity = outstandingQuantity - stock.Quantity;
                        stockCost += stock.Price * stock.Quantity;

                        // Remove the stock altogether
                        repository.Stocks.Remove(stock);
                        repository.SaveChanges();
                    }
                }
                else
                {
                    // No stock, so probably loot
                    outstandingQuantity = 0;
                }
            }

            return stockCost;
        }

        public static long GetStockCount(string name)
        {
            EveRepository repository = new EveRepository();

            var query = from stock in repository.Stocks
                        group stock by stock.TypeName
                into g
                        select
                            new
                            {
                                Item = g.Key,
                                Quantity = g.Sum(stock => stock.Quantity),
                                AverageValue = g.Average(stock => stock.Price)
                            };

            var match = query.FirstOrDefault(s => s.Item == name);

            return match == null ? 0 : match.Quantity;
        }

    }
}
