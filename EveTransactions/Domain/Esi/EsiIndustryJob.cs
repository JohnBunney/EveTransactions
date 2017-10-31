using System;

namespace EveTransactions.Domain.Esi
{
    public class EsiIndustryJob
    {
        public long activity_id { get; set; }
        public long blueprint_id { get; set; }
        public long blueprint_location_id { get; set; }
        public long blueprint_type_id { get; set; }
        public long product_type_id { get; set; }
        public double cost { get; set; }
        public long duration { get; set; }
        public DateTime end_date { get; set; }
        public long facility_id { get; set; }
        public long installer_id { get; set; }
        public long job_id { get; set; }
        public long licensed_runs { get; set; }
        public long runs { get; set; }
        public DateTime start_date { get; set; }
        public long station_id { get; set; }
        public string status { get; set; }
        public long successful_runs { get; set; }
        public decimal probability { get; set; }
    }
}
