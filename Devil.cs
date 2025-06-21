using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Devil
    {
        public static List<Devil> devils = new List<Devil>()
        {
             new Devil("Gorath", 90, 18, 5),
             new Devil("Zarvok", 85, 22, 6),
             new Devil("Thyraxis", 95, 19, 4),
             new Devil("Flameon", 100, 24, 3),
             new Devil("Venomix", 80, 27, 7),
             new Devil("Aerialis", 110, 26, 5),
             new Devil("Bonecrusher", 120, 30, 6),
             new Devil("Nightshade", 105, 26, 4),
             new Devil("Grimrock", 115, 27, 8),
             new Devil("Malgor", 150, 40, 10),
        };
        public String Name { get; set; } = null!;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Power { get; set; }
        public int Healing { get; set; }

        public Devil() { }

        public Devil(String name, int initiateHealth, int power, int healing)
        {
            Name = name;
            MaxHealth = initiateHealth;
            CurrentHealth = initiateHealth;
            Power = power;
            Healing = healing;

        }


        public override string ToString()
        {
            return $"Name : {Name}\nHealth : {MaxHealth}\nPower : {Power}\nHealing : {Healing}";
        }
        public void Stat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($" | HP : {CurrentHealth}");
        }
        public void Attack(Hero hero)
        {

            Random random = new Random();
            int damage = random.Next(Power - (int)(0.25 * Power), Power + 1);
            if (damage > hero.CurrentHealth)
            {
                hero.CurrentHealth = 0;
            }
            else
            {
                hero.CurrentHealth -= damage;
            }
            Console.Write($"\n{Name} deals ");
            Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Healing + "HP\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("\n" + Name);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Miss");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" His Turn\n");
            }
        }
        public void DevilWinOrLose() => CurrentHealth = MaxHealth;
    }
}
