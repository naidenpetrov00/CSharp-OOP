namespace Cars
{
    public abstract class Car
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public abstract string Start();

        public string Stop()
        {
            return "Engine Stoped!";
        }
    }
}
