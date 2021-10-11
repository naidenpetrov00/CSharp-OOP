namespace CarRacing
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;

    class Map : IMap
    {
        private const string NotAvailableRacers = "Race cannot be completed because both racers are not available!";
        private const string StrictBehavior = "strict";
        private const string AggressiveBehavior = "aggressive";
        private const double StrictBehaviorMultiplier = 1.2;
        private const double AggressiveBehaviorMultiplier = 1.1;

        private double chanceOfWinningRacerOne;
        private double chanceOfWinningRacerTwo;

        private static string WalkoverWinner(string winner, string loser)
        {
            return string.Format($"{0} wins the race! {1} was not available to race!", winner, loser);
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return NotAvailableRacers;
            }
            else if (!racerOne.IsAvailable())
            {
                return WalkoverWinner(racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return WalkoverWinner(racerOne.Username, racerTwo.Username);
            }

            if (racerOne.RacingBehavior == StrictBehavior)
            {
                chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }
            else if (racerOne.RacingBehavior == AggressiveBehavior)
            {

                chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }
            if (racerTwo.RacingBehavior == StrictBehavior)
            {
                chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else if (racerTwo.RacingBehavior == AggressiveBehavior)
            {

                chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }

            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
            {
                return string.Format($"{0} has just raced against {1}! {2} is the winner!", racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format($"{0} has just raced against {1}! {2} is the winner!", racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }

    }
}