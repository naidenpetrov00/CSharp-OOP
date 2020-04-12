namespace CounterStrike
{
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            return this.guns.Find(g => g.Name.Equals(name));
        }

        public bool Remove(IGun model)
        {
           return this.guns.Remove(model);
        }
    }
}
