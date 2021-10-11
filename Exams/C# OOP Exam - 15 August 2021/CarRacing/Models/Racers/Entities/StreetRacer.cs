namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int StreetDrivingExperience = 10;
        private const string StreetRacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, StreetRacingBehavior, StreetDrivingExperience, car) { }
    }
}
