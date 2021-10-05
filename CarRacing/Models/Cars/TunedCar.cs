namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        private const double AvailableFuel = 65;
        private const double FuelConsumtion = 7.5;

        public TunedCar(string model, string make, string VIN, int horsePower)
            : base(model, make, VIN, horsePower, AvailableFuel, FuelConsumtion) { }
    }
}
