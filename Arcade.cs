using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Arcade
    {
        private static int _stageNumber = 0;

        public static int StageNumber
        {
            get
            {
                if (_stageNumber == 0) GetLastLevel();
                return _stageNumber;
            }
            set { _stageNumber = value; }
        }
       


        private static void GetLastLevel()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "StateOfHero.txt");
            if (!File.Exists(filePath))
            {
                _stageNumber = 0;
            }
            else
            {
                string content = File.ReadAllText(filePath);
                string[] states = content.Split(',');
                _stageNumber = Convert.ToInt32(states[6]);
            }
            
        }
       

        public static void StartArcadeMode(Hero hero)
        {     
            if (hero.OnLevel <= 3) throw new Exception("You must complete level 3 before starting this mode");

            //GetLastLevel();
            //GetCurrentLevel();
            Devil devil = new Devil
            {
                Name = $"Enemy{StageNumber + 1}",
                MaxHealth = 50 + (StageNumber + 5),
                CurrentHealth = 50 + (StageNumber + 5),
                Power = 10 + (StageNumber + 3),
                Healing = 5 + (StageNumber + 4),
            };

            if (StageNumber == 0)
            {
                //beginner message
                string message = "This is Arcade mode you will play untill you die!";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Arcade : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in message)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
            }
            Console.Clear();



            Console.Write("===================\n");
            Console.Write($"      Stage {StageNumber + 1}");
            Console.WriteLine("\n===================\n");
            hero.Stat();
            Console.Write("\t\t");
            devil.Stat();
            Console.WriteLine("\n\n---------------------------------------------\n");
            while (true)
            {

                int choice = 0;
                if (!hero.isDead())
                {

                    Console.Write("1) Attack \t2) Heal \n\n: ");

                    while (true)
                    {
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please Enter 1 Or 2");
                            continue;
                        }
                        if (choice == 1)
                        {
                            hero.Attack(devil);
                            break;
                        }
                        else if (choice == 2)
                        {
                            hero.Heal();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please Enter 1 Or 2");
                            continue;
                        }

                    }


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Are Dead");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                if (!devil.isDead())
                {

                    Thread.Sleep(3000);
                    Random rand = new Random();
                    choice = rand.Next(1, 5);
                    if (choice != 1) devil.Attack(hero);
                    else devil.Heal();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.Write("===================\n");
                    Console.Write($"      Stage {StageNumber + 1}");
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    _stageNumber++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 1; // <-
                    hero.Coin += earnedCoins;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You Earned +{earnedCoins} Coins\n");
                    Console.Write("Your Coins : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(hero.Coin);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n=========================================\n");
                    break;
                }
                Console.Write("===================\n");
                Console.Write($"      Stage {StageNumber + 1}");
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
            
        }
    }
}
