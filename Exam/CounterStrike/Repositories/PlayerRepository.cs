namespace CounterStrike
{
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> player;

        public PlayerRepository()
        {
            this.player = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.player
            .OrderBy(p => p.GetType().Name)
            .ThenByDescending(p => p.Health)
            .ThenBy(p => p.Username)
            .ToList();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.player.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.player.Find(g => g.Username.Equals(name));
        }

        public bool Remove(IPlayer model)
        {
            return this.player.Remove(model);
        }
    }
}
