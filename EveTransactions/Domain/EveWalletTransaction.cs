using System;
using EveAI.Live;
using EveTransactions.Domain.Esi;

namespace EveTransactions.Domain
{
    public class EveWalletTransaction
    {

        #region Properties

        public long EveWalletTransactionID { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string Station { get; set; }
        public string TransactionFor { get; set; }  // Personal / Corp
        public string TransactionType { get; set; }
        public string TypeName { get; set; }  // Unit Name
        public long Quantity { get; set; }
        public long TransactionIDFromEve { get; set; }

        #endregion

        #region Constructors

        protected EveWalletTransaction()
        {}

        public EveWalletTransaction(EveAI.Live.Utility.TransactionEntry transactionEntry)
        {
            TransactionIDFromEve = transactionEntry.TransactionID;
            Date = transactionEntry.DateLocalTime;
            Price = transactionEntry.Price;
            TotalPrice = transactionEntry.PriceTotal;
            ClientName = transactionEntry.ClientName;
            Station = transactionEntry.StationName;
            TransactionFor = transactionEntry.TransactionFor.ToString();
            TransactionType = transactionEntry.TransactionType.ToString();
            TypeName = transactionEntry.TypeName;
            Quantity = transactionEntry.Quantity;
        }

        public EveWalletTransaction(EsiWalletTransaction transactionEntry)
        {
            TransactionIDFromEve = transactionEntry.transaction_id;
            Date = transactionEntry.date;
            Price = transactionEntry.unit_price;
            Quantity = transactionEntry.quantity;
            TotalPrice = Price * Quantity;
            ClientName = transactionEntry.client_id.ToString();  // New API doesn't expose friendly client name (of person traded with)
            Station = transactionEntry.location_id.ToString();  // New API doesn't expose friendly station name, just location ID
            TransactionFor = transactionEntry.is_personal ? "Personal" : "Corp";
            TransactionType = transactionEntry.is_buy ? "Buy" : "Sell";
            TypeName = transactionEntry.type_name;  // New API doesn't expose friendly type name, just type ID - look it up in the MarketItems table
        }

        #endregion
    }
}
