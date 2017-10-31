namespace EveTransactions.Domain.Esi
{
    class EsiMarketOrder
    {
        public long account_id { get; set; }
        public long duration { get; set; }
        public bool is_buy_order { get; set; }
        public long order_id { get; set; }
        public string state { get; set; }
        public long volume_remain { get; set; }
        public long volume_total { get; set; }
        public long type_id { get; set; }
        public double price { get; set; }
    }

}
