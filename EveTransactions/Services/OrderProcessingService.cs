using System;
using System.Collections.Generic;
using System.Linq;
using EveTransactions.Domain;

namespace EveTransactions.Services
{
    public class OrderProcessingService
    {
        #region Members
        
        private readonly IList<BuyOrder> m_BuyOrders;
        private readonly IList<SellOrder> m_SellOrders;
        private readonly IList<Item> m_Items;
        private readonly IList<OrderFulfilment> m_OrderFulfilments;
        
        #endregion

        public OrderProcessingService()
        {
            m_BuyOrders = new List<BuyOrder>();
            m_SellOrders = new List<SellOrder>();            
            m_Items = new List<Item>();
            m_OrderFulfilments = new List<OrderFulfilment>();
        }

        public Item AddItem(long itemId, string itemName)
        {
            Item item = new Item();
            item.ItemID = itemId;
            item.ItemName = itemName;

            if (m_Items.Any(x => x.ItemID == itemId))
            {
                return m_Items.First(x => (x.ItemID == itemId));
            }

            m_Items.Add(item);

            return item;
        }

        public void AddBuyOrder(Item item, long quantity, double unitPrice, DateTime orderDate)
        {
            // Create new BuyOrder
            BuyOrder buyOrder = new BuyOrder(item, quantity, unitPrice, orderDate);

            m_BuyOrders.Add(buyOrder);
        }

        public void AddSellOrder(Item item, long quantity, double unitPrice, DateTime orderDate)
        {
            // Create new SellOrder
            SellOrder sellOrder = new SellOrder(item.ItemID, quantity, unitPrice, orderDate);
            m_SellOrders.Add(sellOrder);

            long outstandingQuantity = quantity;

            while (outstandingQuantity > 0)
            {
                // Find the oldest corresponding Buy order, or create a new one
                BuyOrder buyOrder = GetOldestBuyOrder(item) ?? new BuyOrder(item, outstandingQuantity, 0, DateTime.Now);

                long newOutstandingQuantity = buyOrder.ReduceOutstandingQuantity(quantity);
                // Does this update the total in the IList?

                long matched = outstandingQuantity - newOutstandingQuantity;

                // Create an order fulfilment
                OrderFulfilment orderFulfilment = new OrderFulfilment(buyOrder, sellOrder, matched);
                m_OrderFulfilments.Add(orderFulfilment);
                outstandingQuantity = newOutstandingQuantity;
            }

        }

        public BuyOrder GetOldestBuyOrder(Item item)
        {
            return m_BuyOrders.FirstOrDefault(buyOrder => (buyOrder.Item == item) && (buyOrder.OutstandingQuantity > 0));
        }

        public void ShowProfits()
        {
            foreach (var orderFulfilment in m_OrderFulfilments)
            {
                Console.WriteLine(orderFulfilment.PrintProfit());
            }   
        }

        public IList<ProfitDTO> GetProfits()
        {
            return m_OrderFulfilments.Select(orderFulfilment => orderFulfilment.GetProfit()).ToList();
        }

        public void Test()
        {
            Item item1 = AddItem(999, "Test");
            Item item2 = AddItem(888, "Test2");
            Item item3 = AddItem(999, "Test");

            AddBuyOrder(item1, 10, 1.01, DateTime.Now);
            AddBuyOrder(item2, 50, 1.02, DateTime.Now);
            AddBuyOrder(item3, 1000, 1.03, DateTime.Now);

            Item item4 = AddItem(999, "Test");
            AddSellOrder(item4, 5, 2.05, DateTime.Now);

            ShowProfits();
        }

        public void LootProfit()
        {
            var profits = GetProfits();

            var items = profits.Select(x => x.ItemName).Distinct();

            foreach (var item in items)
            {
                var itemProfit = profits.Where(x => x.ItemName == item).Sum(y => y.TotalProfit);
                var itemCount = profits.Count(x => x.ItemName == item);

                Console.WriteLine(string.Format("{0},{1},{2}", item, itemProfit, itemCount));
            }
        }

    }
}
