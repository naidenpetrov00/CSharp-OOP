namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MotorcycleRepository : IRepository<Motorcycle>
    {

        private List<Motorcycle> models;

        public MotorcycleRepository()
        {
            this.models = new List<Motorcycle>();
        }

        public IReadOnlyCollection<Motorcycle> Models => this.models;

        public void Add(Motorcycle model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<Motorcycle> GetAll()
        {
            return this.Models;
        }

        public Motorcycle GetByName(string name)
        {
            return this.models.Find(m => m.Model.Equals(name));
        }

        public bool Remove(Motorcycle model)
        {
            return this.models.Remove(model);
        }
    }
}
