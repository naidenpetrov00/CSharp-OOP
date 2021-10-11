namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double AvailableFuel = 65;
        private const double FuelConsumtion = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, AvailableFuel, FuelConsumtion) { }
    }
}
