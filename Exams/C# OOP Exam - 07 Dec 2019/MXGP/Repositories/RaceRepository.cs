namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<Race>
    {

        private List<Race> models;

        public RaceRepository()
        {
            this.models = new List<Race>();
        }

        public IReadOnlyCollection<Race> Models => this.models;

        public void Add(Race model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<Race> GetAll()
        {
            return this.Models;
        }

        public Race GetByName(string name)
        {
            return this.models.Find(m => m.Name.Equals(name));
        }

        public bool Remove(Race model)
        {
            return this.models.Remove(model);
        }
    }
}
