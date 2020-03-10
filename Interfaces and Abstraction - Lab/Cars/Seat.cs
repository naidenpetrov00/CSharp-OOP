namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
            :base(model, color)
        {
        }

        public override string Start()
        {
            return "prprprr";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
