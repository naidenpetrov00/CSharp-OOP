namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title 
        {
            get { return this.title; }
            set { this.title = value; } 
        }

        public string Author
        {
            get { return this.author; }
            set 
            {
                string[] name = value.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string secondName = name[1];

                if (Char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException ("Author not valid!");
                }

                this.author = value; 
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
