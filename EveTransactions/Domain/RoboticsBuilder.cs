using System;
using System.Linq;

namespace EveTransactions.Domain
{
    public class RoboticsBuilder
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

        public long ChiralStructuresStock { get; set; }
        public long ToxicMetalsStock { get; set; }
        public long ReactiveMetalsStock { get; set; }
        public long PreciousMetalsStock { get; set; }
        public long MechanicalPartsStock { get; set; }
        public long ConsumerElectronicsStock { get; set; }

        public long ChiralStructuresUsed { get; set; }
        public long ToxicMetalsUsed { get; set; }
        public long ReactiveMetalsUsed { get; set; }
        public long PreciousMetalsUsed { get; set; }
        public long MechanicalPartsUsed { get; set; }
        public long ConsumerElectronicsUsed { get; set; }

        public long RoboticsRequired { get; set; }
        public long RoboticsBuilt { get; set; }

        #endregion

        #region CalculatedProperties

        public long LowestP1Stock
        {
            get
            {
                var stockList = new[] { ToxicMetalsStock, PreciousMetalsStock, ReactiveMetalsStock, ChiralStructuresStock };
                return stockList.Min();
            }
        }

        public long NumberOfRoboticsWeCanBuildFromP1Stock
        {
            get
            {
                // P1 is consumed in batches of 80
                var batches = Math.Floor((double)LowestP1Stock/80);

                // Resulting number of robotics is 3 per batch
                return (long)batches*3;
            }
        }

        #endregion

        #region Methods

        public decimal Build(decimal taxRate)
        {
            // Step 1 - Build using p0
            BuildUsingP1();

            //BuildUsingP1AndMechanicalParts();

            //BuildUsingP1AndConsumerElectronics();

            //BuildUsingP2();

            var p1InputsConsumed = ChiralStructuresUsed + ToxicMetalsUsed + ReactiveMetalsUsed + PreciousMetalsUsed;
            var p2InputsConsumed = ConsumerElectronicsUsed + MechanicalPartsUsed;

            decimal p1importCost = (taxRate / 2) * PI_P1_BaseCost * p1InputsConsumed;
            decimal p2importCost = (taxRate / 2) * PI_P2_BaseCost * p2InputsConsumed;
            decimal exportCost = taxRate * PI_P3_BaseCost * RoboticsBuilt;
            decimal totalCost = p1importCost + p2importCost + exportCost;

            return totalCost;
        }

        public void BuildUsingP1()
        {
            if (RoboticsRequired < 1) return;

            var p1Required = (RoboticsRequired * 80) / 3;

            if (LowestP1Stock > p1Required)
            {
                // We have enough p1 stock for the full order
                ConsumeChiralStructures(p1Required);
                ConsumeToxicMetals(p1Required);
                ConsumePreciousMetals(p1Required);
                ConsumeReactiveMetals(p1Required);
                BuildRobotics(RoboticsRequired);
            }
            else
            {
                // How many can we build with the stock we have?
                var numberToBuild = NumberOfRoboticsWeCanBuildFromP1Stock;
                var p1Used = (numberToBuild * 80) / 3;
                ConsumeChiralStructures(p1Used);
                ConsumeToxicMetals(p1Used);
                ConsumePreciousMetals(p1Used);
                ConsumeReactiveMetals(p1Used);
                BuildRobotics(numberToBuild);
            }
        }

        public void BuildUsingP1AndMechanicalParts()
        {
            if (RoboticsRequired < 1) return;

            var minP1 = Math.Min(ChiralStructuresStock, ToxicMetalsStock);

            // How many Consumer Electronics can we make - 3 Robotics = 10 CE = 80 P1
            var consumerElectronicsRuns = Math.Floor((double)minP1 / 80);
            var mechPartsRuns = Math.Floor((double)MechanicalPartsStock / 10);

            var minRuns = Math.Min(consumerElectronicsRuns, mechPartsRuns);
            var roboticsOutput = (long)minRuns * 3;

            if (roboticsOutput > RoboticsRequired)
            {
                roboticsOutput = RoboticsRequired;
            }

            var p1Used = (long)roboticsOutput * 80 / 3;
            var mecUsed = (long)roboticsOutput * 10 / 3;

            ConsumeChiralStructures(p1Used);
            ConsumeToxicMetals(p1Used);
            ConsumeMechanicalParts(mecUsed);
            BuildRobotics(roboticsOutput);
        }

        public void BuildUsingP1AndConsumerElectronics()
        {
            if (RoboticsRequired < 1) return;

            var minP1 = Math.Min(ReactiveMetalsStock, PreciousMetalsStock);

            // How many Consumer Electronics can we make - 3 Robotics = 10 CE = 80 P1
            var consumerElectronicsRuns = Math.Floor((double)ConsumerElectronicsStock / 10);
            var mechPartsRuns = Math.Floor((double)minP1 / 80);

            var minRuns = Math.Min(consumerElectronicsRuns, mechPartsRuns);
            var roboticsOutput = (long)minRuns * 3;

            if (roboticsOutput > RoboticsRequired)
            {
                roboticsOutput = RoboticsRequired;
            }

            var p1Used = (long)roboticsOutput * 80;
            var mecUsed = (long)roboticsOutput * 10;

            ConsumeReactiveMetals(p1Used);
            ConsumePreciousMetals(p1Used);
            ConsumeConsumerElectronics(mecUsed);
            BuildRobotics(roboticsOutput);
        }

        public void BuildUsingP2()
        {
            if (RoboticsRequired < 1) return;

            var minP1 = Math.Min(ConsumerElectronicsStock, MechanicalPartsStock);

            // How many Robotics can we make - 3 Robotics = 10 P2
            var runs = Math.Floor((double)minP1 / 10);
            var roboticsOutput = (long)runs * 3;

            if (roboticsOutput > RoboticsRequired)
            {
                roboticsOutput = RoboticsRequired;
            }

            var mecUsed = (long)roboticsOutput * 10 / 3;

            ConsumeMechanicalParts(mecUsed);
            ConsumeConsumerElectronics(mecUsed);
            BuildRobotics(roboticsOutput);
        }

        private void BuildRobotics(long quantity)
        {
            RoboticsBuilt += quantity;
            RoboticsRequired -= quantity;
        }

        private void ConsumeChiralStructures(long quantity)
        {
            ChiralStructuresUsed += quantity;
            ChiralStructuresStock -= quantity;
        }

        private void ConsumeToxicMetals(long quantity)
        {
            ToxicMetalsUsed += quantity;
            ToxicMetalsStock -= quantity;
        }

        private void ConsumePreciousMetals(long quantity)
        {
            PreciousMetalsUsed += quantity;
            PreciousMetalsStock -= quantity;
        }

        private void ConsumeReactiveMetals(long quantity)
        {
            ReactiveMetalsUsed += quantity;
            ReactiveMetalsStock -= quantity;
        }

        private void ConsumeMechanicalParts(long quantity)
        {
            MechanicalPartsUsed += quantity;
            MechanicalPartsStock -= quantity;
        }

        private void ConsumeConsumerElectronics(long quantity)
        {
            ConsumerElectronicsUsed += quantity;
            ConsumerElectronicsStock -= quantity;
        }
        #endregion

    }
}
