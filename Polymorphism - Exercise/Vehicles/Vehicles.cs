namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double consumptionPerKilometer;

        public Vehicles(double fuelQuantity, double consumptionPerKilometer)
        {
            this.Fuel = fuelQuantity;
            this.Consumption = consumptionPerKilometer;
        }

        public double Fuel 
        {
            get { return this.fuelQuantity; }
            protected set { this.fuelQuantity = value; } 
        }

        public double Consumption
        {
            get { return this.consumptionPerKilometer; }
            protected set { this.consumptionPerKilometer = value; }
        }

        protected abstract void AirConditionerLooses();

        public virtual void Refuel(double liters)
        {
            this.Fuel += liters;
        }

        public string Drive(double kilometers)
        {
            var neededLiters = this.Consumption * kilometers;

            if (neededLiters <= this.Fuel)
            {
                this.Fuel -= neededLiters;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
    }
}
