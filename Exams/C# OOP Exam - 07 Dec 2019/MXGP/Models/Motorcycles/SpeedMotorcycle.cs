namespace MXGP.Models.Motorcycles
{

    public class SpeedMotorcycle : Motorcycle
    {
        private const int minimalHorsePower = 50;
        private const int maximalHorsePower = 69;
        private const int cubicCentimeters = 125;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, cubicCentimeters)
        {
            this.MinimumHorsePower = minimalHorsePower;
            this.MaximumHorsePower = maximalHorsePower;
            this.HorsePower = horsePower;
        }
    }
}
