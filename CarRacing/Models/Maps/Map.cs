namespace CarRacing
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Map : IMap
    {
        private const string NotAvailableRacers = "Race cannot be comnpleted because both racers are not available!";
        private string walkoverWinner = string.Format($"{0} wins the race! {1} was not available to race!");

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return NotAvailableRacers;
            }
            else if (!racerOne.IsAvailable())
            {
               var test = walkoverWinner
            }
            else if (!racerTwo.IsAvailable())
            {

            }
        }
    }
}
