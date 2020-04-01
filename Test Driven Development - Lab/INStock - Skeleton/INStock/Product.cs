namespace INStock
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get { return this.label; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Label cannot be null or empty!");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be less than zero!");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be less than zero!");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other) => this.Price.CompareTo(other.Price);
    }
}
