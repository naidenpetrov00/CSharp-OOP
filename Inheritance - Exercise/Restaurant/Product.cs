namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public virtual decimal Price 
        {
            get { return this.price; }
            private set { this.price = value; }
        }
    }
}
