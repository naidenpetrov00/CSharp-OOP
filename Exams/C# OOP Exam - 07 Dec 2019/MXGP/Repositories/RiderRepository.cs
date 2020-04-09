namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RiderRepository : IRepository<Rider>
    {

        private List<Rider> models;

        public RiderRepository()
        {
            this.models = new List<Rider>();
        }

        public IReadOnlyCollection<Rider> Models => this.models;

        public void Add(Rider model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<Rider> GetAll()
        {
            return this.Models;
        }

        public Rider GetByName(string name)
        {
            return this.models.Find(m => m.Name.Equals(name));
        }

        public bool Remove(Rider model)
        {
            return this.models.Remove(model);
        }
    }
}
