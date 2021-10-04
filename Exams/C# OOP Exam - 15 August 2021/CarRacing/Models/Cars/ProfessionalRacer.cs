namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalRacer : Racer
    {
        private const int DrivingExperience = 30;
        private const string RacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car)
            : base(username, RacingBehavior, DrivingExperience, car) { }
    }
}
