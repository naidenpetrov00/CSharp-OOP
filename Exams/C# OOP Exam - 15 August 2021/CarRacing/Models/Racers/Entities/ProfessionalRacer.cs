namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalRacer : Racer
    {
        private const int ProfessionalDrivingExperience = 30;
        private const string ProfessionalRacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car)
            : base(username, ProfessionalRacingBehavior, ProfessionalDrivingExperience, car) { }
    }
}
