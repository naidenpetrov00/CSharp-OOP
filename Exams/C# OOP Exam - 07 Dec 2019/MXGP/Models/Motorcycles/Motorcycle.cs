namespace MXGP
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.cubicCentimeters = cubicCentimeters;
        }

        public int MinimumHorsePower { get; protected set; }

        public int MaximumHorsePower { get; protected set; }

        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < this.MinimumHorsePower || value > this.MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
        }

        public double CalculateRacePoints(int laps)
        {
            var result = this.CubicCentimeters / this.HorsePower * laps;

            return result;
        }
    }
}
