namespace CounterStrike.Models.Players
{
    using CounterStrike.Models.Guns.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string username, int health, int armor, IGun gun)
            : base(username, health, armor, gun) { }
    }
}
