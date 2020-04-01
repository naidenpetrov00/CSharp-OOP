namespace INStock
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ProductStock : IProductStock
    {
        public IProduct this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public void Add(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
