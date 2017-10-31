using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EveTransactions.Domain.Esi;

namespace EveTransactions.Domain
{

    public enum JobType
    {
        None = 0,
        Manufacturing = 1,
        Research = 2,
        TimeEfficiency = 3,
        MaterialEfficiency = 4,
        Copying = 5,
        Duplicating = 6,
        ReverseEngineering = 7,
        Invention = 8
    }

    public class IndustryJobs
    {
        List<Job> m_Jobs = new List<Job>();

        public List<Job> Jobs
        {
            get { return m_Jobs; }
        }

        public IndustryJobs(DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                Job job = new Job(row);

                m_Jobs.Add(job);
            }
        }
    }

    public class Job
    {
        public long JobID { get; set; }
        public long EveJobID { get; set; }
        public long InstallerID { get; set; }
        public string InstallerName { get; set; } // "Tashaki Snowblink"
        public long FacilityID { get; set; }
        public long SolarSystemID { get; set; }
        public string SolarSystemName { get; set; } // "Oremulf"
        public long StationID { get; set; }
        public JobType Activity { get; set; } // "1=??, 2=??"
        public long BlueprintID { get; set; }
        public long BlueprintTypeID { get; set; }
        public string BlueprintTypeName { get; set; } // "Acolyte II Blueprint"
        public long BlueprintLocationID { get; set; }
        public long OutputLocationID { get; set; }
        public long Runs { get; set; }
        public double Cost { get; set; } // 12729.00
        public long TeamID { get; set; }
        public long LicensedRuns { get; set; }
        public decimal Probability { get; set; }
        public long ProductTypeID { get; set; }
        public string ProductTypeName { get; set; } // "Acolyte II"
        public long Status { get; set; } // 1=Active, 2=Paused, 3=Ready, 101=Delivered, 102=Cancelled, 103=Reverted
        public long TimeInSeconds { get; set; } // 9213
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public long CompletedCharacterID { get; set; }
        public long SuccessfulRuns { get; set; }

        public Job()
        {

        }

        public Job(DataRow row)
        {
            EveJobID = long.Parse(row[0].ToString());
            InstallerID = long.Parse(row[1].ToString());
            InstallerName = row[2].ToString();
            FacilityID = long.Parse(row[3].ToString());
            SolarSystemID = long.Parse(row[4].ToString());
            SolarSystemName = row[5].ToString();
            StationID = long.Parse(row[6].ToString());
            Activity = (JobType)Enum.Parse(typeof(JobType), row[7].ToString());
            BlueprintID = long.Parse(row[8].ToString());
            BlueprintTypeID = long.Parse(row[9].ToString());
            BlueprintTypeName = row[10].ToString();
            BlueprintLocationID = long.Parse(row[11].ToString());
            OutputLocationID = long.Parse(row[12].ToString());
            Runs = long.Parse(row[13].ToString());
            Cost = double.Parse(row[14].ToString());
            TeamID = long.Parse(row[15].ToString());
            LicensedRuns = long.Parse(row[16].ToString());
            Probability = decimal.Parse(row[17].ToString());
            ProductTypeID = long.Parse(row[18].ToString());
            ProductTypeName = row[19].ToString();
            Status = long.Parse(row[20].ToString());
            TimeInSeconds = long.Parse(row[21].ToString());
            StartDate = DateTime.Parse(row[22].ToString());
            EndDate = DateTime.Parse(row[23].ToString());
            CompletedDate = DateTime.Parse(row[25].ToString());
            CompletedCharacterID = long.Parse(row[26].ToString());
            SuccessfulRuns = long.Parse(row[27].ToString());

            if (CompletedDate.Year < 2000) CompletedDate = EndDate;
        }

        public Job(EsiIndustryJob job)
        {
            EveJobID = job.job_id;
            InstallerID = job.installer_id;
            //InstallerName = row[2].ToString();
            FacilityID = job.facility_id;
            //SolarSystemID = long.Parse(row[4].ToString());
            //SolarSystemName = row[5].ToString();
            StationID = job.station_id;
            Activity = (JobType) job.activity_id; //Enum.Parse(typeof(JobType), job.activity_id);
            BlueprintID = job.blueprint_id;
            BlueprintTypeID = job.blueprint_type_id;
            BlueprintTypeName = string.Empty;
            BlueprintLocationID = job.blueprint_location_id;
            //OutputLocationID = job.ou;
            Runs = job.runs;
            Cost = job.cost;
            //TeamID = long.Parse(row[15].ToString());
            LicensedRuns = job.licensed_runs;
            Probability = job.probability;
            ProductTypeID = job.product_type_id;
            ProductTypeName = string.Empty;

            //  1=Active, 2=Paused, 3=Ready, 101=Delivered, 102=Cancelled, 103=Reverted
            Status = SetStatusValue(job.status); //  ['active', 'paused', 'ready', 'delivered', 'cancelled', 'reverted'],

            TimeInSeconds = job.duration;
            StartDate = job.start_date;
            EndDate = job.end_date;
            //CompletedDate = jo;
            //CompletedCharacterID = long.Parse(row[26].ToString());
            SuccessfulRuns = job.successful_runs;

            if (CompletedDate.Year < 2000) CompletedDate = EndDate;
        }

        public int SetStatusValue(string name)
        {
            switch (name)
            {
                case "active":
                    return 1;
                case "paused":
                    return 2;
                case "ready":
                    return 3;
                case "delivered":
                    return 101;
                case "cancelled":
                    return 102;
                case "reverted":
                    return 103;
            }
            return 0;
        }

    }
}
