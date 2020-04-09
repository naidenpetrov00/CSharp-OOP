namespace MXGP
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rider : IRider
    {
        private string name;
        private int numberOfWins;
        private bool canParticipate = false;

        private IMotorcycle motorcycle;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle
        {
            get => this.motorcycle;
            private set { this.motorcycle = value; }
        }

        public int NumberOfWins { get => this.numberOfWins; private set { this.numberOfWins = value; } }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set { this.canParticipate = value; }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;

            this.CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
