namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        private const double AvailableFuel = 80;
        private const double FuelConsumtion = 10;

        public SuperCar(string model, string make, string VIN, int horsePower)
            : base(model, make, VIN, horsePower, AvailableFuel, FuelConsumtion) { }
    }
}
