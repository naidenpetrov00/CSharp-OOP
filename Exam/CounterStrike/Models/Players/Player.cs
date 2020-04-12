namespace CounterStrike
{
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Player : IPlayer
    {
        private string userName;
        private int health;
        private int armor;
        private bool isAlive;

        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;

            if (this.Health > 0)
            {
                this.IsAlive = true;
            }
        }

        public string Username
        {
            get => this.userName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.userName = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                if (value == null)
                {
                    //probably mistake with exception message!!!
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive 
        {
            get => this.isAlive;
            private set { this.isAlive = value; }
        }

        public void TakeDamage(int points)
        {
            if (this.Armor - points < 0)
            {
                var result = points - this.Armor;
                this.Armor = 0;

                if (this.Health - points <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (this.Health - points > 0)
                {
                    this.Health -= points;
                }
            }
            else if (this.Armor - points >= 0)
            {
                this.Armor -= points;
            }
        }

        public override string ToString()
        {
            //"{player type}: {player username}");
            //"--Health: {player health}");
            //"--Armor: {player armor}");
            //"--Gun: {player gun name}")

            var report = new StringBuilder();
            report.AppendLine($"{this.GetType().Name}: {this.Username}");
            report.AppendLine($"--Health: {this.Health}");
            report.AppendLine($"--Armor: {this.Armor}");
            report.AppendLine($"--Gun: {this.Gun.Name}");

            return report.ToString().Trim();
        }
    }
}
