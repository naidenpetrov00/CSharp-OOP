﻿namespace AquaShop
{
    public class FreshwaterFish : Fish
    {
        private const int initialSize = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = initialSize;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
