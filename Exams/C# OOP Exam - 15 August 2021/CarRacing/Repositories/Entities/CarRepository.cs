namespace CarRacing
{
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;

    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models
        {
            get { return this.models; }
        }

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }

            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            var car = this.models.Find(c => c.VIN.Equals(property));

            if (car != null)
            {
                return car;
            }

            return null;
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
