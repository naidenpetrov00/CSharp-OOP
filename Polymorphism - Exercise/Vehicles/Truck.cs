namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Vehicles
    {
        private const double airConditionerConsumtionRiseс = 1.6;
        private const double holeInTheTankLosses = 0.95;


        public Truck(double fuel, double consumption)
            : base(fuel, consumption)
        {
            AirConditionerLooses();
        }

        protected override void AirConditionerLooses()
        {
            double risedConsumption = base.Consumption + airConditionerConsumtionRiseс;

            base.Consumption = risedConsumption;
        }

        public override void Refuel(double liters)
        {
            var fuelLefted = liters * holeInTheTankLosses;

            this.Fuel += fuelLefted;
        }
    }
}
