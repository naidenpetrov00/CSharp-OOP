namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class SportsCar : Car
    {
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;
        private const double cubicCentimeters = 3000;

        private int horsePower;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubicCentimeters, MinHorsePower, MaxHorsePower)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
