namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicles
    {
        private const double airConditionerConsumtionRiseс = 0.9;


        public Car(double fuel, double consumption)
            : base(fuel, consumption) 
        {
            AirConditionerLooses();
        }

        protected override void AirConditionerLooses()
        {
            double risedConsumption = base.Consumption + airConditionerConsumtionRiseс;

            base.Consumption = risedConsumption;
        }
    }
}
