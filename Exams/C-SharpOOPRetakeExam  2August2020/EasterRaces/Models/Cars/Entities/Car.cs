namespace EasterRaces.Models.Cars.Contracts
{
    using EasterRaces.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private string model;
        private double cubicCentimeters;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, this.model, 4));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters
        {
            get { return this.cubicCentimeters; }
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            var result = this.CubicCentimeters / (this.HorsePower * laps);

            return result;
        }
    }
}
