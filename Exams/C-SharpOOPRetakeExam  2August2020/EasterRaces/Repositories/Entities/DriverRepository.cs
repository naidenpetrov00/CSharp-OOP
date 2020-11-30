using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Entities.RepositoryEntities;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(d => d.Name.Equals(name));
        }
    }
}
