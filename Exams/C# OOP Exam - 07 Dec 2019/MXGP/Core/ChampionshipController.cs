namespace MXGP
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private const string SpeedMotorcycleType = "SpeedMotorcycle";
        private const string PowerMotorcycleType = "PowerMotorcycle";

        private MotorcycleRepository motorcyles;
        private RiderRepository riders;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.motorcyles = new MotorcycleRepository();
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (!RiderExistValidator(riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (!MotorcycleExistValidator(motorcycleModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            var motorcycle = this.motorcyles.GetByName(motorcycleModel);
            this.riders.GetByName(riderName).AddMotorcycle(motorcycle);

            var result = string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
            return result;
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (!RaceExistValidator(raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!RiderExistValidator(riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var rider = this.riders.GetByName(riderName);

            if (!rider.CanParticipate)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotParticipate, riderName));
            }

            this.races.GetByName(raceName).AddRider(rider);

            var result = string.Format(OutputMessages.RiderAdded, riderName, raceName);
            return result;
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (MotorcycleExistValidator(model))
            {
                //probably mistake with message!
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type.StartsWith("Speed"))
            {
                var motorcycle = new SpeedMotorcycle(model, horsePower);
                this.motorcyles.Add(motorcycle);

                var result = string.Format(OutputMessages.MotorcycleCreated, SpeedMotorcycleType, model);
                return result;
            }
            else if (type.StartsWith("Power"))
            {
                var motorcycle = new PowerMotorcycle(model, horsePower);
                this.motorcyles.Add(motorcycle);

                var result = string.Format(OutputMessages.MotorcycleCreated, PowerMotorcycleType, model);
                return result;
            }
            else
            {
                throw new InvalidOperationException("Invalid type");
            }
        }

        public string CreateRace(string name, int laps)
        {
            if (RaceExistValidator(name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.races.Add(race);

            string result = string.Format(OutputMessages.RaceCreated, name);
            return result;
        }

        public string CreateRider(string riderName)
        {
            if (RiderExistValidator(riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = new Rider(riderName);

            this.riders.Add(rider);

            var result = string.Format(OutputMessages.RiderCreated, riderName);

            return result;
        }

        public string StartRace(string raceName)
        {
            if (!RaceExistValidator(raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var race = this.races.GetByName(raceName);

            if (this.races.GetByName(raceName).Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var riders = race.Riders.ToList();

            var result = new StringBuilder();
            //result.AppendLine(race.Laps.ToString());
            result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, raceName));
            //result.AppendLine(riders[0].Motorcycle.CubicCentimeters.ToString());
           // result.AppendLine(riders[0].Motorcycle.HorsePower.ToString());
           // result.AppendLine(riders[0].Motorcycle.CalculateRacePoints(race.Laps).ToString());
            result.AppendLine(string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, raceName));
           // result.AppendLine(riders[1].Motorcycle.CubicCentimeters.ToString());
           // result.AppendLine(riders[1].Motorcycle.HorsePower.ToString());
           // result.AppendLine(riders[1].Motorcycle.CalculateRacePoints(race.Laps).ToString());
            result.AppendLine(string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, raceName));
          //  result.AppendLine(riders[2].Motorcycle.CubicCentimeters.ToString());
           // result.AppendLine(riders[2].Motorcycle.HorsePower.ToString());
           // result.AppendLine(riders[2].Motorcycle.CalculateRacePoints(race.Laps).ToString());

            this.races.Remove(race);
            return result.ToString().Trim();
        }

        public bool MotorcycleExistValidator(string name)
        {
            if (this.motorcyles.GetByName(name) == null)
            {
                return false;
            }

            return true;
        }

        public bool RiderExistValidator(string name)
        {
            if (this.riders.GetByName(name) == null)
            {
                return false;
            }

            return true;
        }

        public bool RaceExistValidator(string name)
        {
            if (this.races.GetByName(name) == null)
            {
                return false;
            }

            return true;
        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
