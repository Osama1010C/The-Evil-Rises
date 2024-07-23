using System;
using System.Xml.Serialization;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        public static void Menu()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "StateOfHero.txt");
            Hero hero = new Hero();



            while (true)
            {
                // title of the game
                Console.Write("========================\n     The ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Evil ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Rises\n========================\n");

                //first menu
                Console.WriteLine("1] New Game\n\n2] Continue\n\n3] Info About Game\n\n4] Exit\n");
                int select;
                //try to get valid input
                while (true)
                {
                    try
                    {
                        select = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unknown Choice");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    if (select != 1 && select != 2 && select != 3 && select != 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unknown Choice");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    else break;
                }
                //now i have select variable

                //Info about game
                if (select == 3)
                {
                    Console.Clear();

                    Console.Write("=================\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("      Info ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n=================\n");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Epic Quest of The Hero\n\n");

                    // Introduction
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) It's an RBG Game works on your terminal\n");
                    Console.WriteLine("2) You will face a lot of Devils\n");
                    Console.WriteLine("3) You have to save your people\n");

                    Console.WriteLine("----------------------------------------------------\n");
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Becareful\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1) If you chose New Game and you have a progress in the game then all your progress will deleted \n");
                    Console.WriteLine("2) when you start the game and want to close it please choose save and exit in the second page otherwise what you did      will not be saved\n");

                    Console.WriteLine("======================================================================================================================\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n< Click Enter To Back >");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();

                    Console.Clear();

                }

                //Exit
                else if (select == 4)
                {
                    break;
                }

                else
                {
                    //new game
                    if (select == 1)
                    {
                        Console.Clear();

                        Console.Write("========================\n      ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t Heroes ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n========================\n");

                        if (File.Exists(filePath))
                        {
                            // Delete the file
                            File.Delete(filePath);
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("< Choose Your Hero > \n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Hero.ShowHeros();
                        Console.Write("Enter The Number Of The Hero You Want : ");

                        //try to get valid input
                        while (true)
                        {
                            try
                            {
                                select = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown Choice");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continue;
                            }
                            if (select < 1 || select > Hero.NumberOfHeros())
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown Choice");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continue;
                            }
                            else break;
                        }
                        //now i have number of the hero

                        hero = hero[select - 1];

                        // now i have the hero
                    }
                    //continue
                    else if (select == 2)
                    {
                        Console.Clear();
                        Console.Write("========================\n      ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  Progress ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n========================\n");
                        if (!File.Exists(filePath))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You Don't Have Played Yet !\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("=======================================\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n< Click Enter To Back >");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.ReadKey();
                            Console.Clear();
                            continue;

                        }
                        else
                        {
                            string content = File.ReadAllText(filePath);
                            string[] states = content.Split(',');
                            hero = new Hero(states[0], int.Parse(states[1]), int.Parse(states[2]), int.Parse(states[3]));
                            hero.Coin = int.Parse(states[4]);
                            hero.OnLevel = int.Parse(states[5]);
                        }

                        //now i have the hero

                        Console.Clear();
                    }

                    // second menu
                    Console.Clear();
                    while (true)
                    {

                        Console.Write("========================\n     The ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Evil ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Rises\n========================\n");

                        Console.WriteLine("1] Story Mode\n\n2] Hero Info\n\n3] Upgrade abilities\n\n4] Save And Exit\n");
                        //try to get valid input
                        while (true)
                        {
                            try
                            {
                                select = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown Choice");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continue;
                            }
                            if (select != 1 && select != 2 && select != 3 && select != 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown Choice");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continue;
                            }
                            else break;
                        }
                        //choices from second menu

                        //story mode menu
                        if (select == 1)
                        {
                            //levels menu
                            while (true)
                            {
                                Console.Clear();

                                Console.Write("==================\n");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("      Levels");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n==================\n");
                                Console.Write("0)");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(" Story\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-\n");
                                Console.Write("1) Level 1\t2) Level 2\n\n3) Level 3\t4) Level 4\n\n5) ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Level 5\t");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("6) Level 6\n\n7) Level 7\t8) Level 8\n\n9) Level 9\t10) ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Level 10\n\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-\n");
                                Console.Write("\n11) ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Back\n\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n===============================\n");
                                //Console.ForegroundColor = ConsoleColor.Green;
                                //Console.Write("Choose Level : ");
                                //Console.ForegroundColor = ConsoleColor.Gray;

                                //try to choose level
                                while (true)
                                {
                                    try
                                    {
                                        select = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Choice");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        continue;
                                    }
                                    if (select < 0 || select > Level.NumberOfLevels + 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Choice");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        continue;
                                    }
                                    else
                                    {
                                        if (hero.OnLevel < select && select != Level.NumberOfLevels + 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Finish Level {select - 1} To Play Level {select}");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            continue;
                                        }
                                        else break;
                                    }
                                }
                                // now i have a valid and allowed input of level
                                Level level = new Level();
                                if(select == 0)
                                {
                                    Console.Clear();
                                    level.Story(hero);
                                }
                                else if (select == 1)
                                {
                                    Console.Clear();
                                    level.Level1(hero);

                                }
                                else if (select == 2)
                                {
                                    Console.Clear();
                                    level.Level2(hero);

                                }
                                else if (select == 3)
                                {
                                    Console.Clear();
                                    level.Level3(hero);

                                }
                                else if (select == 4)
                                {
                                    Console.Clear();
                                    level.Level4(hero);

                                }
                                else if (select == 5)
                                {
                                    Console.Clear();
                                    level.Level5(hero);

                                }
                                else if (select == 6)
                                {
                                    Console.Clear();
                                    level.Level6(hero);

                                }
                                else if (select == 7)
                                {
                                    Console.Clear();
                                    level.Level7(hero);

                                }
                                else if (select == 8)
                                {
                                    Console.Clear();
                                    level.Level8(hero);

                                }
                                else if (select == 9)
                                {
                                    Console.Clear();
                                    level.Level9(hero);

                                }
                                else if (select == 10)
                                {
                                    Console.Clear();
                                    level.Level10(hero);

                                }
                                else
                                {
                                    Console.Clear();
                                    break;
                                }
                                //
                                if (select == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\n\n< Click Enter To Begin The Journey >");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\n\n< Click Enter To Back >");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }

                        //hero state menu 
                        else if (select == 2)
                        {
                            Console.Clear();

                            Console.Write("==================\n");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("     Your Hero");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n==================\n");
                            Console.WriteLine(hero);
                            Console.WriteLine("\n======================================\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n< Click Enter To Back >");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        //upgrade menu
                        else if (select == 3)
                        {

                            while (true)
                            {
                                Console.Clear();
                                Console.Write("===================\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("      Upgrade");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n===================\n");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Coins : " + hero.Coin);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("~~~~~~~~~~~~~\n");
                                Console.Write("Any Upgrade For ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("5 Coins");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("\n---------------------------\n\n");
                                Console.WriteLine("1) Upgrade Health\n\n2) Upgrade Attack\n\n3) Upgrade Healing\n\n4) Back\n");
                                //try to get the choice to upgrade
                                while (true)
                                {
                                    try
                                    {
                                        select = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Choice");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        continue;
                                    }
                                    if (select != 1 && select != 2 && select != 3 & select != 4)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Choice");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        continue;
                                    }
                                    else break;
                                }
                                // now i know what hero will upgrade
                                if (select == 4) break;
                                if (hero.Coin < 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not Enough Coins To Upgrade");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else
                                {
                                    if (select == 1)
                                    {

                                        int oldhealth = hero.MaxHealth;
                                        hero.UpgradeHealth();
                                        Console.Write($"Health Is Upgraded From {oldhealth} => ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"{hero.MaxHealth}");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        hero.Coin -= 5;
                                    }
                                    else if (select == 2)
                                    {

                                        int oldpower = hero.Power;
                                        hero.UpgradePower();
                                        Console.Write($"Attacking Is Upgraded From {oldpower} => ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"{hero.Power}");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        hero.Coin -= 5;
                                    }
                                    else if (select == 3)
                                    {

                                        int oldheal = hero.Healing;
                                        hero.UpgradeHealing();
                                        Console.Write($"Healing Is Upgraded From {oldheal} => ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"{hero.Healing}");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        hero.Coin -= 5;
                                    }
                                }
                                Thread.Sleep(1800);
                                Console.Clear();
                            }
                            Console.Clear();


                        }
                        //exit from app from second menu
                        else
                        {
                            string states = $"{hero.Name},{hero.MaxHealth},{hero.Power},{hero.Healing},{hero.Coin},{hero.OnLevel}";
                            File.WriteAllText(filePath, states);
                            return;
                        }
                    }
                }
            }
        }
    }
}
