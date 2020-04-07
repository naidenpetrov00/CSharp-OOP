namespace AquaShop
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;

        public IReadOnlyCollection<IDecoration> Models => this.Models;

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.Models.First(m => m.GetType().Name.Equals(type));
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
