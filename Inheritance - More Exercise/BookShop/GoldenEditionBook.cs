namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {

        }

        public override decimal Price
        {
            get { return base.Price * (decimal)1.30; }
        }
    }
}
