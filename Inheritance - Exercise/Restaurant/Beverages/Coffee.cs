namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Coffee : HotBeverage
    {
        private const double coffeMilliliters = 50;
        private const decimal coffePrice = 3.50M;

        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public  override double Milliliters { get => coffeMilliliters; }

        public override decimal Price { get => coffePrice; }

        public double Caffeine { get; private set; }
    }
}
