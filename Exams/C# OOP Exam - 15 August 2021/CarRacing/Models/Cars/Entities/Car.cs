namespace CarRacing
{
    using CarRacing.Models.Cars.Contracts;
    using System;

    public abstract class Car : ICar
    {
        private const string TunedCar = "TunedCar";

        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }


        public string Make
        {
            get { return this.make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get { return this.vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get { return this.fuelAvailable; }
            private set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }
                else
                {
                    this.fuelAvailable = value;
                }
            }
        }

        public double FuelConsumptionPerRace
        {
            get { return this.fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }

                this.fuelConsumptionPerRace = value;
            }
        }

        public void Drive()
        {
            this.FuelAvailable -= this.fuelConsumptionPerRace;

            if (this.Model.GetType().Equals(TunedCar))
            {
                var hpAfterWear = Math.Round(this.HorsePower / 1.03);

                this.HorsePower = (int)hpAfterWear;
            }
        }
    }
}
