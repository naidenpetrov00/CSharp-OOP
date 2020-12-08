namespace EasterRaces.Core.Contracts
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Repositories.Contracts;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<ICar> carRep;
        private readonly IRepository<IRace> raceRep;
        private readonly IRepository<IDriver> driverRep;

        public ChampionshipController()
        {
            this.carRep = new CarRepository();
            this.raceRep = new RaceRepository();
            this.driverRep = new DriverRepository();
        }

        public IRepository<ICar> CarRep => this.carRep;
        public IRepository<IRace> RaceRep => this.raceRep;
        public IRepository<IDriver> DriverRep => this.driverRep;

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.DriverExistence(driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (!this.CarExistence(carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            var driver = this.DriverRep.GetByName(driverName);
            var car = this.CarRep.GetByName(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.RaceExistence(raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (!this.DriverExistence(driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else
            {
                var race = this.RaceRep.GetByName(raceName);
                var driver = this.DriverRep.GetByName(driverName);

                race.AddDriver(driver);

                return string.Format(OutputMessages.DriverAdded, driverName, raceName);
            }
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (!this.CarExistence(model))
            {
                if (type == "Muscle")
                {
                    var muscleCar = new MuscleCar(model, horsePower);
                    this.carRep.Add(muscleCar);
                }
                else if (type == "Sports")
                {
                    var sportsCar = new SportsCar(model, horsePower);
                    this.carRep.Add(sportsCar);
                }

                return string.Format(OutputMessages.CarCreated, type + "Car", model);
            }

            throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
        }

        public string CreateDriver(string driverName)
        {
            if (!this.DriverExistence(driverName))
            {
                var driver = new Driver(driverName);
                this.driverRep.Add(driver);

                return string.Format(OutputMessages.DriverCreated, driverName);
            }

            throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
        }

        public string CreateRace(string name, int laps)
        {
            if (this.RaceExistence(name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.raceRep.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.RaceRep.GetByName(raceName);
            if (!this.RaceExistence(raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var raceWiners = race.Drivers.Take(3).ToList();

            var sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, raceWiners[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, raceWiners[1].Name, raceName));
            sb.Append(string.Format(OutputMessages.DriverThirdPosition, raceWiners[2].Name, raceName));

            this.raceRep.Remove(race);

            return sb.ToString().Trim();
        }

        public bool DriverExistence(string name)
        {
            if (this.DriverRep.GetByName(name) is null)
            {
                return false;
            }

            return true;
        }
        public bool RaceExistence(string name)
        {
            if (this.RaceRep.GetByName(name) is null)
            {
                return false;
            }

            return true;
        }
        public bool CarExistence(string model)
        {
            if (this.CarRep.GetByName(model) is null)
            {
                return false;
            }

            return true;
        }
    }
}
