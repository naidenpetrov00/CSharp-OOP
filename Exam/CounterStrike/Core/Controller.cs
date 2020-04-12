namespace CounterStrike
{
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {

            if (type == "Pistol")
            {
                var gun = new Pistol(name, bulletsCount);
                this.guns.Add(gun);
            }
            else if (type == "Rifle")
            {
                var gun = new Rifle(name, bulletsCount);
                this.guns.Add(gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            var result = string.Format(OutputMessages.SuccessfullyAddedGun, name);
            return result;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if (this.guns.FindByName(gunName) == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            var gun = this.guns.FindByName(gunName);

            if (type == "Terrorist")
            {
                var terrorist = new Terrorist(username, health, armor, gun);
                this.players.Add(terrorist);
            }
            else if (type == "CounterTerrorist")
            {
                var counterTerrorist = new CounterTerrorist(username, health, armor, gun);
                this.players.Add(counterTerrorist);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            string result = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return result;
        }

        public string Report()
        {
            var report = new StringBuilder();

            var players = this.players.Models.ToList();
            //players
            //    .OrderBy(p => p.GetType().Name)
            //    .ThenByDescending(p => p.Health)
            //    .ThenBy(p => p.Username)
            //    .ToList();

            players.ForEach(p => report.AppendLine(p.ToString()));

            return report.ToString().Trim();
        }

        public string StartGame()
        {
           return this.map.Start(this.players.Models.ToList());
        }
    }
}
