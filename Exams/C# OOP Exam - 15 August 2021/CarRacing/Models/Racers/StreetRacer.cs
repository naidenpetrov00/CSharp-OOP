namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StreetRacer : Racer
    {
        private const int DrivingExperience = 10;
        private const string RacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, RacingBehavior, DrivingExperience, car) { }
    }
}
