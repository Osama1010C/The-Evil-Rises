using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG_Game
{
    public class Hero
    {
        private static List<Hero> heros = new List<Hero>()
        {
            new Hero("Sam", 100, 20, 10),
            new Hero("Finn", 90, 25, 8),
            new Hero("Arin", 110, 18, 12),
            new Hero("Eldrin", 80, 15, 20),
            new Hero("Kael", 120, 22, 5),
        };
        private int currentlevel = 1;
        public String Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Power { get; set; }
        public int Healing { get; set; }
        public int Coin { get; set; }
        public int OnLevel
        {
            get => currentlevel;

            set
            {
                currentlevel = value;
            }
        }

        public Hero this[int index]
        {
            get => heros[index];
        }

        public Hero(String name, int initiateHealth, int power, int healing)
        {
            Name = name;
            MaxHealth = initiateHealth;
            CurrentHealth = initiateHealth;
            Power = power;
            Healing = healing;
        }
        public Hero() : this("", 0, 0, 0)
        {

        }

        public void LevelUp()
        {
            OnLevel++;
        }

        public void UpgradeHealth()
        {
            MaxHealth += 1;
            CurrentHealth = MaxHealth;
        }
        public void UpgradePower() => Power += 1;

        public void UpgradeHealing() => Healing += 1;

        public override string ToString()
            => $"Name : {Name}\n\nHealth : {MaxHealth}\n\nPower : {Power}\n\nHealing : {Healing}\n\nCoins : {Coin}\n\nArcade Last Stage : {Arcade.StageNumber}";

        public void Stat()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($" | HP : {CurrentHealth}");
        }
        public void Attack(Devil devil)
        {
            Random random = new Random();
            int damage = random.Next(Power - (int)(0.25 * Power), Power + 1);
            if (damage > devil.CurrentHealth)
            {
                devil.CurrentHealth = 0;
            }
            else
            {
                devil.CurrentHealth -= damage;
            }
            Console.Write($"\n{Name} deals ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(damage);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" damage\n");
        }


        public bool isDead()
        {
            if (CurrentHealth == 0) return true;
            return false;
        }

        public void Heal()
        {
            if (CurrentHealth < MaxHealth)
            {
                if (Healing + CurrentHealth > MaxHealth)
                    CurrentHealth = MaxHealth;
                else
                    CurrentHealth += Healing;

                Console.Write($"\n{Name} is Healing +");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Healing + "HP\n");
                Console.ForegroundColor = ConsoleColor.Gray;


            }
            else
            {
                Console.Write("\nYou Are Already Max Heal But You ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lost Your Turn Now\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        public static void ShowHeros()
        {
            int i = 1;
            foreach (Hero hero in heros)
            {
                Console.WriteLine($"{i}]");
                Console.WriteLine($"Name: {hero.Name}\tHealth: {hero.MaxHealth}\tPower: {hero.Power}\tHealing: {hero.Healing}");
                i++;
                Console.WriteLine("-------------------------------------------------------------------\n");
            }
        }

        public void HeroWinOrLose() => CurrentHealth = MaxHealth;

        public static int NumberOfHeros() => heros.Count;
    }
}