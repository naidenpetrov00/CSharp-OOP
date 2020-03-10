using System.Text;

namespace Cars
{
    public class Tesla : ElectricCar
    {
        public Tesla(string model, string color, int battery)
            :base(model, color, battery)
        {
        }
        public override string Start()
        {
            var output = new StringBuilder();

            output.AppendLine("Engine started");
            output.AppendLine("Hello Naiden!");

            return output.ToString().Trim();
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model} {this.Battery}";
        }
    }
}
