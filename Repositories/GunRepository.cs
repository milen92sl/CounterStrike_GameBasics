using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using System.Linq;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        private readonly List<IGun> guns;
        public IReadOnlyCollection<IGun> Models => guns;
        public void Add(IGun model)
        {
            guns.Add(model);
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
        }

        public bool Remove(IGun model)
        => guns.Remove(model);


        public IGun FindByName(string name)
            => this.guns.FirstOrDefault(x => x.Name == name);
    }
}
