namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public class RiderRepository : IRepository<IRider>
    {

        private List<IRider> models;

        public RiderRepository()
        {
            this.models = new List<IRider>();
        }

        public IReadOnlyCollection<IRider> Models => this.models;

        public void Add(IRider model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.Models;
        }

        public IRider GetByName(string name)
        {
            return this.models.Find(m => m.Name.Equals(name));
        }

        public bool Remove(IRider model)
        {
            return this.models.Remove(model);
        }
    }
}
