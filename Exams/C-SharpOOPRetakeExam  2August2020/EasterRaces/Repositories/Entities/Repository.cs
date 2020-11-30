namespace EasterRaces.Repositories.Entities.RepositoryEntities
{
    using EasterRaces.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models => this.models.AsReadOnly();

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
