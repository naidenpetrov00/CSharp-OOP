namespace EasterRaces.Models.Cars.Contracts
{
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
        }

        public string Model 
        {
            get { return this.model; }
            private set 
            {
                if(String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,this.model, 4));
                }

                this.model = value;
            }
        }       

        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var result = this.CubicCentimeters / (this.HorsePower * laps);

            return result;
        }
    }
}
