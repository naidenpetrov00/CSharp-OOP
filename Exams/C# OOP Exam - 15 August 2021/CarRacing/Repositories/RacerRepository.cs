namespace CarRacing
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
        {
            get { return this.models; }
        }

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            var racer = this.models.Find(c => c.Username.Equals(property));

            if (racer != null)
            {
                return racer;
            }

            return null;
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
