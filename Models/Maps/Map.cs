using CounterStrike.Models.Maps.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Players.Contracts;
using System.Linq;
using CounterStrike.Models.Players;

namespace CounterStrike.Models.Maps
{
    public class Map :IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(terrorist => terrorist.GetType() == typeof(Terrorist))
                .ToList();

            var counterTerrorists = players
                .Where(counterTerrorist => counterTerrorist.GetType() == typeof(CounterTerrorist))
                .ToList();

            while (terrorists.Any(t=>t.IsAlive) &&
                   counterTerrorists.Any(c=>c.IsAlive))
            {
                foreach (var terro in terrorists.Where(t=>t.IsAlive))
                {
                    if (!terro.IsAlive)
                    {
                        continue;
                    }
                    foreach (var counterTerro in counterTerrorists)
                    {
                        if (!counterTerro.IsAlive)
                        {
                            continue;
                        }
                        counterTerro.TakeDamage(terro.Gun.Fire());
                    }
                }
                //TODO:Check if terrorist are alive 

                foreach (var counterTerro in counterTerrorists.Where(ct => ct.IsAlive))
                {
                    if (!counterTerro.IsAlive)
                    {
                        continue;
                    }
                    foreach (var terro in terrorists.Where(t=>t.IsAlive))
                    {
                        if (!terro.IsAlive)
                        {
                            continue;
                        }
                        terro.TakeDamage(counterTerro.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;

            if (terrorists.Any(x=>x.IsAlive))
            {
                return result = "Terrorist wins!";
            }
            else
            {
                return result = "Counter Terrorist wins!";
            }
        }
    }
}
