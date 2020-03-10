namespace Cars
{
    public abstract class ElectricCar : Car
    {
        public ElectricCar(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery 
        {
            get;
            private set;
        }
    }
}
