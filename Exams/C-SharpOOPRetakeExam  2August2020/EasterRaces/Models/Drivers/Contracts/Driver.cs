namespace EasterRaces.Models.Drivers.Contracts
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberofWins;
        private bool canParticipate = false;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car
        {
            get { return this.car; }
            private set { this.car = value; }
        }

        public int NumberOfWins
        {
            get { return this.numberofWins; }
            private set { this.numberofWins = value; }
        }

        public bool CanParticipate
        {
            get { return this.canParticipate; }
            private set { this.canParticipate = value; }
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            else
            {
                this.Car = car;
                this.CanParticipate = true;
            }
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
