namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;

    public abstract class Racer : IRacer
    {
        private const string TypeProfessionalRacer = "ProfessionalRacer";
        private const string TypeStreetRacer = "StreetRacer";
        private const int ProfessionalRacerExperienceAdder = 10;
        private const int ProfessionalStreetRacerAdder = 5;

        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private Car car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }


        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get { return this.racingBehavior; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get { return this.drivingExperience; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get { return this.car; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }

                this.car = (Car)value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable - this.Car.FuelConsumptionPerRace < 0)
            {
                return false;
            }

            return true;
        }

        public void Race()
        {
            this.Car.Drive();

            if (this.GetType().Equals(TypeProfessionalRacer))
            {
                this.DrivingExperience += ProfessionalRacerExperienceAdder;
            }
            else if (this.GetType().Equals(TypeStreetRacer))
            {
                this.DrivingExperience += ProfessionalStreetRacerAdder;
            }
        }
    }
}
