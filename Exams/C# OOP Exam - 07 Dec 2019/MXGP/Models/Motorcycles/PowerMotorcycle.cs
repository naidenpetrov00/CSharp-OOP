namespace MXGP.Models.Motorcycles
{

    public class PowerMotorcycle : Motorcycle
    {
        private const int minimalHorsePower = 70;
        private const int maximalHorsePower = 100;
        private const int cubicCentimeters = 450;

        public PowerMotorcycle(string model, int horsePower)
            :base(model, horsePower, cubicCentimeters)
        {
            this.MinimumHorsePower = minimalHorsePower;
            this.MaximumHorsePower = maximalHorsePower;
            this.HorsePower = horsePower;
        }
    }
}
