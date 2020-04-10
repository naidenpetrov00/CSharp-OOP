namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public class RaceRepository : IRepository<IRace>
    {

        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Models;
        }

        public IRace GetByName(string name)
        {
            return this.models.Find(m => m.Name.Equals(name));
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
