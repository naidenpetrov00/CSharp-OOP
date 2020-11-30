using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Entities.RepositoryEntities;
using System.Linq;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = null;//new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
