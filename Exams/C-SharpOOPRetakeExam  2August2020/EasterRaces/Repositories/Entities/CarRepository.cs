using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Entities.RepositoryEntities;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(c => c.Model.Equals(name));
        }
    }
}
