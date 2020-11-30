using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Entities.RepositoryEntities;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(r => r.Name.Equals(name));
        }
    }
}
