﻿namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> Models => this.models;

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
