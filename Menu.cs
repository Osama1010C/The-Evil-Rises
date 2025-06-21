using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public static class Menu
    {
        public static void GameMenu()
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

                    Info.GameInfo();

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
                        Save.SaveGame(hero);

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
                            Arcade.StageNumber = int.Parse(states[6]);
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

                        Console.WriteLine("1] Story Mode\n\n2] Arcade\n\n3] Hero Info\n\n4] Upgrade abilities\n\n5] Back\n");
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
                            if (select != 1 && select != 2 && select != 3 && select != 4 && select != 5)
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
                                if (select == 0)
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
                                Save.SaveGame(hero);
                            }
                        }

                        //arcade mode
                        else if (select == 2)
                        {
                            try
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.Write("=====================\n");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("     Arcade Mode");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("\n=====================\n");
                                    Arcade.StartArcadeMode(hero);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\n\n< Click Enter To Continue ( 0 ) to Exit >");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Save.SaveGame(hero);

                                    if (Console.ReadLine() == "0")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An Error Occurred: " + e.Message);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n\n< Click Enter To Back >\n");
                                Console.ReadKey();
                            }
                            Console.Clear();

                        }

                        //hero state menu 
                        else if (select == 3)
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
                        else if (select == 4)
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
                                Save.SaveGame(hero);
                            }
                            Console.Clear();


                        }
                        //exit from app from second menu
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
            }
        }
    }
}
