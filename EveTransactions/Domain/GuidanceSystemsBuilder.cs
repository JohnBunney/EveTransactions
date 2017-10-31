using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveTransactions.Domain
{
    class GuidanceSystemsBuilder
    {
        #region Constants

        // Base costs
        const int PI_R0_BaseCost = 4;
        const int PI_P1_BaseCost = 400;
        const int PI_P2_BaseCost = 7200;
        const int PI_P3_BaseCost = 60000;
        const int PI_P4_BaseCost = 1200000;

        #endregion

        #region Properties

        public long WaterCooledCPUStock { get; set; }
        public long TransmitterStock { get; set; }

        public long WaterCooledCPUUsed { get; set; }
        public long TransmitterUsed { get; set; }
        
        public long GuidanceSystemsRequired { get; set; }
        public long GuidanceSystemsBuilt { get; set; }

        #endregion

        #region Methods

        public decimal Build(decimal taxRate)
        {
            BuildUsingP2();

            var p2InputsConsumed = WaterCooledCPUUsed + TransmitterUsed;

            decimal p2importCost = (taxRate / 2) * PI_P2_BaseCost * p2InputsConsumed;
            decimal exportCost = taxRate * PI_P3_BaseCost * GuidanceSystemsBuilt;
            decimal totalCost = p2importCost + exportCost;

            return totalCost;
        }

        public void BuildUsingP2()
        {
            if (GuidanceSystemsRequired < 1) return;

            var minP1 = Math.Min(WaterCooledCPUStock, TransmitterStock);

            // How many Robotics can we make - 3 Robotics = 10 P2
            var runs = Math.Floor((double)minP1 / 10);
            var guidanceSystemsOutput = (long)runs * 3;

            if (guidanceSystemsOutput > GuidanceSystemsRequired)
            {
                guidanceSystemsOutput = GuidanceSystemsRequired;
            }

            var mecUsed = (long)guidanceSystemsOutput * 10 / 3;

            ConsumeWaterCooledCPU(mecUsed);
            ConsumeTransmitter(mecUsed);
            BuildRobotics(guidanceSystemsOutput);
        }

        private void BuildRobotics(long quantity)
        {
            GuidanceSystemsBuilt += quantity;
            GuidanceSystemsRequired -= quantity;
        }

        private void ConsumeWaterCooledCPU(long quantity)
        {
            WaterCooledCPUUsed += quantity;
            WaterCooledCPUStock -= quantity;
        }

        private void ConsumeTransmitter(long quantity)
        {
            TransmitterUsed += quantity;
            TransmitterStock -= quantity;
        }
        #endregion

    }
}

