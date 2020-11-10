namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class MuscleCar : Car
    {
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;
        private const double cubicCentimeters = 5000;

        private int horsePower;

        public MuscleCar(string model, int horsePower, double cubicCentimeters)
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

        public override double CubicCentimeters => cubicCentimeters;
    }
}
