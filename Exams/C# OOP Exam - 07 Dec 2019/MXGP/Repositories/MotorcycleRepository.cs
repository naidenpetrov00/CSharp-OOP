namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {

        private List<IMotorcycle> models;

        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }

        public IReadOnlyCollection<IMotorcycle> Models => this.models;

        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.Models;
        }

        public IMotorcycle GetByName(string name)
        {
            return this.models.Find(m => m.Model.Equals(name));
        }

        public bool Remove(IMotorcycle model)
        {
            return this.models.Remove(model);
        }
    }
}
