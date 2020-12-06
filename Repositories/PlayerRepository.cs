using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        private readonly List<IPlayer> players;
        public IReadOnlyCollection<IPlayer> Models => players;
        public void Add(IPlayer model)
        {
            players.Add(model);

            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
        }

        public bool Remove(IPlayer model)
            => players.Remove(model);


        public IPlayer FindByName(string name)
            => this.players.FirstOrDefault(x => x.Username == name);
    }
}
