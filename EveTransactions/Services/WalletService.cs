using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using EveTransactions.Domain;
using EveTransactions.Domain.Esi;
using EveTransactions.Repository;

namespace EveTransactions.Services
{
    public static class WalletService
    {
        public static void ProcessBuyTransactions(IEnumerable<EsiWalletTransaction> transactions, EsiRefreshToken esiToken, BackgroundWorker worker)
        {
            var esiWalletTransactions = transactions as IList<EsiWalletTransaction> ?? transactions.ToList();
            if (!esiWalletTransactions.Any()) return;

            EveRepository repository = new EveRepository();

            // Get minimum Transaction ID
            var min = esiWalletTransactions.OrderBy(x => x.transaction_id).First().transaction_id;

            // Get all higher transaction ID's that we've already processed
            var knownTransactions =
                repository.WalletTransactions.Where(x => x.TransactionIDFromEve >= min)
                    .Select(x => x.TransactionIDFromEve)
                    .ToArray();

            double total = esiWalletTransactions.Count;

            if (total < 1) return;

            double processed = 0;
            foreach (EsiWalletTransaction walletTransaction in esiWalletTransactions)
            {
                processed++;
                int percentProcessed = int.Parse(Math.Round(processed * 100 / total).ToString(CultureInfo.InvariantCulture));
                worker.ReportProgress(percentProcessed);

                //if (WalletTransactionExists(repository, walletTransaction.TransactionID)) continue;
                if (knownTransactions.Contains(walletTransaction.transaction_id)) continue;

                walletTransaction.type_name = EveItemService.GetTypeNameFromId(esiToken, walletTransaction.type_id);

                EveWalletTransaction eveWalletTransaction = new EveWalletTransaction(walletTransaction);
                repository.WalletTransactions.Add(eveWalletTransaction);
                repository.SaveChanges();

                // Add this item to stock
                Stock stock = new Stock(eveWalletTransaction);
                repository.Stocks.Add(stock);
                repository.SaveChanges();
            }
        }

        public static void ProcessSellTransactions(IEnumerable<EsiWalletTransaction> transactions, EsiRefreshToken esiToken, BackgroundWorker worker)
        {
            var esiWalletTransactions = transactions as IList<EsiWalletTransaction> ?? transactions.ToList();

            if (!esiWalletTransactions.Any()) return;

            EveRepository repository = new EveRepository();

            // Get minimum Transaction ID
            var min = esiWalletTransactions.OrderBy(x => x.transaction_id).First().transaction_id;

            // Get all higher transaction ID's that we've already processed
            var knownTransactions =
                repository.WalletTransactions.Where(x => x.TransactionIDFromEve >= min)
                    .Select(x => x.TransactionIDFromEve)
                    .ToArray();

            double total = esiWalletTransactions.Count;

            if (total < 1) return;

            double processed = 0;

            foreach (EsiWalletTransaction walletTransaction in esiWalletTransactions)
            {
                processed++;
                int percentProcessed = Int32.Parse(Math.Round(processed * 100 / total).ToString(CultureInfo.InvariantCulture));
                worker.ReportProgress(percentProcessed);

                if (knownTransactions.Contains(walletTransaction.transaction_id)) continue;
                //if (WalletTransactionExists(repository, walletTransaction.TransactionID)) continue;

                walletTransaction.type_name = EveItemService.GetTypeNameFromId(esiToken, walletTransaction.type_id);
                EveWalletTransaction eveWalletTransaction = new EveWalletTransaction(walletTransaction);
                repository.WalletTransactions.Add(eveWalletTransaction);
                repository.SaveChanges();

                long outstandingQuantity = eveWalletTransaction.Quantity;

                while (outstandingQuantity > 0)
                {
                    var matchingStock =
                        repository.Stocks.OrderBy(x => x.StockID)
                            .Where(s => s.TypeName == eveWalletTransaction.TypeName);

                    var stock = matchingStock.FirstOrDefault();

                    if (stock != null)
                    {
                        if (stock.Quantity > outstandingQuantity)
                        {
                            // A partial sell of some existing stock
                            Sale sale = new Sale(stock, eveWalletTransaction, outstandingQuantity);
                            repository.Sales.Add(sale);
                            repository.SaveChanges();

                            // Reduce the stock
                            stock.Quantity = stock.Quantity - outstandingQuantity;
                            repository.SaveChanges();

                            outstandingQuantity = 0;
                        }
                        else if (stock.Quantity == outstandingQuantity)
                        {
                            // A full sell of some existing stock
                            Sale sale = new Sale(stock, eveWalletTransaction, outstandingQuantity);

                            repository.Sales.Add(sale);
                            repository.SaveChanges();

                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();

                            outstandingQuantity = 0;
                        }
                        else
                        {
                            // Sell the entirity of the current stock item, and then we'll look for more stock
                            Sale sale = new Sale(stock, eveWalletTransaction, stock.Quantity);
                            repository.Sales.Add(sale);
                            repository.SaveChanges();

                            outstandingQuantity = outstandingQuantity - stock.Quantity;

                            // Remove the stock altogether
                            repository.Stocks.Remove(stock);
                            repository.SaveChanges();
                        }
                    }
                    else
                    {
                        // No stock, so probably loot
                        Stock fakeStock = new Stock(eveWalletTransaction.TypeName, eveWalletTransaction.Date,eveWalletTransaction.Quantity);
                        Sale sale = new Sale(fakeStock, eveWalletTransaction, eveWalletTransaction.Quantity);

                        repository.Sales.Add(sale);
                        repository.SaveChanges();

                        outstandingQuantity = 0;
                    }
                }
            }
        }

    }
}
