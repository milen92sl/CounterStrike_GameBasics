using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System.Drawing;
using System.Net.NetworkInformation;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
                //TODO: Player health cannot be equal to 0 ???
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
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
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;
        public void TakeDamage(int points)
        {
           
            if (armor - points >= 0)
            {
                armor -= points;
                return;
            }
            else if(armor > 0)
            {
                points -= armor;
                armor = 0;
            }

            health -= points;
            if (health < 0)
            {
                health = 0;
            }

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().Trim();

        }
    }
}
