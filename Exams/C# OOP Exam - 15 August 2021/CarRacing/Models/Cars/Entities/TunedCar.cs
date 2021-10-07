namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        private const double AvailableFuel = 65;
        private const double FuelConsumtion = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, AvailableFuel, FuelConsumtion) { }
    }
}
