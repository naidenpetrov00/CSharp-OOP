namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        private const double AvailableFuel = 80;
        private const double FuelConsumtion = 10;

        public SuperCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, AvailableFuel, FuelConsumtion) { }
    }
}
