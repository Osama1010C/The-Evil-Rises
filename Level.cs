using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Level
    {
        public static int NumberOfLevels => Devil.devils.Count;

        
        //work here
        public void Story(Hero hero)
        {
            Console.Write("=================\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("      Story"); // <-
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n=================\n");
            //stories
            string theStory1 = $"{hero.Name}, a humble farmer from Greenvale, grew up with tales of legendary heroes. He lived a simple life, learning the values of determination and kindness.";
            string theStory2 = "The evil sorcerer ";
            //malgor
            string theStory22 = $" plunged Eldoria into darkness, bringing fear and despair to the land, including {hero.Name}'s village";
            string theStory3 = $"One night, the Oracle appeared to {hero.Name} in a dream, revealing that he was destined to be the hero who would defeat ";
            //malgor
            string theStory33 = $" and restore light to Eldoria. ";
            string theStory333 = $"{hero.Name} accepted this calling and set out on his journey.";
            
            foreach (char letter in theStory1)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Thread.Sleep(800);
            Console.WriteLine("\n");


            foreach (char letter in theStory2)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor= ConsoleColor.Red;
            foreach (char letter in "Malgor")
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }          
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (char letter in theStory22)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Thread.Sleep(800);
            Console.WriteLine("\n");

            foreach (char letter in theStory3)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (char letter in "Malgor")
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (char letter in theStory33)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char letter in theStory333)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Level1(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 1"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[0]; // <-

            if(hero.OnLevel == 1)
            {
                //story
                string messageOfDevil = "Turn back, human! You cannot defeat us all. Each step you take brings you closer to your doom.";
                string messageOfHero = "I have no choice but to press on. The fate of my people depends on it. If I must fight you to proceed, then so be it.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();


            Console.Write("===================\n");
            Console.Write("      Level 1"); // <-
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
                    Console.Write("      Level 1"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 2 ? 2 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 5; // <-
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
                Console.Write("      Level 1"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level2(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 2"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[1]; // <-

            if(hero.OnLevel == 2)
            {
                //story
                string messageOfDevil = "Why fight? Join us, and you will be powerful. You can rule beside Malgor and bask in glory.";
                string messageOfHero = "Power means nothing if it is used to oppress. My only desire is to see my homeland free from tyranny. Your offer holds no way over me.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();


            Console.Write("===================\n");
            Console.Write("      Level 2"); // <-
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
                    Console.Write("      Level 2"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 3 ? 3 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 10; // <-
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
                Console.Write("      Level 2"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
            

        }

        public void Level3(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 3"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[2]; // <-

            if(hero.OnLevel == 3)
            {
                //story
                string messageOfDevil = "Your journey ends here, mortal. I am the swift blade in the dark. None have survived my ambush.";
                string messageOfHero = "I've faced many dangers to get here. You are just another obstacle in my path. I will not fall to you.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 3"); // <-
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
                    Console.Write("      Level 3"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 4 ? 4 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 15; // <-
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
                Console.Write("      Level 3"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level4(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 4"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[3]; // <-

            if(hero.OnLevel == 4)
            {
                //story
                string messageOfDevil = "Feel the burn of my flames! I will reduce you to ashes.";
                string messageOfHero = "Your flames may be fierce, but my resolve is fiercer. I will withstand your heat and extinguish your fire.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 4"); // <-
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
                    Console.Write("      Level 4"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 5 ? 5 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 20; // <-
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
                Console.Write("      Level 4"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level5(Hero hero)
        {
            Console.Write("===================\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      Level 5"); // <-
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[4]; // <-

            if(hero.OnLevel == 5)
            {
                //story
                string messageOfDevil = "My poison will seep into your veins and bring you to a slow, painful end.";
                string messageOfHero = "I have faced many trials and survived. Your poison will not deter me from my quest.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      Level 5"); // <-
            Console.ForegroundColor = ConsoleColor.Gray;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("      Level 5"); // <-
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 6 ? 6 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 25; // <-
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("      Level 5"); // <-
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level6(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 6"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[5]; // <-

            if(hero.OnLevel == 6)
            {
                //story
                string messageOfDevil = "You cannot reach me in the air! I will tear you apart from above.";
                string messageOfHero = "Your wings will not save you. I have faced many aerial foes before.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 6"); // <-
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
                    Console.Write("      Level 6"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 7 ? 7 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 30; // <-
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
                Console.Write("      Level 6"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level7(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 7"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[6]; // <-

            if(hero.OnLevel == 7)
            {
                //story
                string messageOfDevil = "You will join the dead! My dark sword will ensure your demise.";
                string messageOfHero = "As long as I breathe, I will fight. Your sword will not stop me.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 7"); // <-
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
                    Console.Write("      Level 7"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 8 ? 8 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 35; // <-
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
                Console.Write("      Level 7"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level8(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 8"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[7]; // <-

            if(hero.OnLevel == 8)
            {
                //story
                string messageOfDevil = "Fear is your downfall. I am the embodiment of terror, and you will crumble before me.";
                string messageOfHero = "I have faced my fears and emerged stronger. Your terror has no hold over me.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 8"); // <-
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
                    Console.Write("      Level 8"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 9 ? 9 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 40; // <-
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
                Console.Write("      Level 8"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level9(Hero hero)
        {
            Console.Write("===================\n");
            Console.Write("      Level 9"); // <-
            Console.WriteLine("\n===================\n");
            Devil devil = Devil.devils[8]; // <-

            if(hero.OnLevel == 9)
            {
                //story
                string messageOfDevil = "I am the guardian of Malgor, I will crush you! My strength is unmatched, and I will break you.";
                string messageOfHero = "Strength alone is not enough. It is courage and determination that will see me through.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{devil.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfDevil)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Thread.Sleep(800);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{hero.Name} : ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char letter in messageOfHero)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("< Click Enter To Start The Fight >");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                //end of story
            }
            Console.Clear();
            

            Console.Write("===================\n");
            Console.Write("      Level 9"); // <-
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
                    Console.Write("      Level 9"); // <-
                    Console.WriteLine("\n===================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");
                    hero.OnLevel = hero.OnLevel < 10 ? 10 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 45; // <-
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
                Console.Write("      Level 9"); // <-
                Console.WriteLine("\n===================\n");
                hero.Stat();
                Console.Write("\t\t");
                devil.Stat();
                Console.WriteLine("\n\n---------------------------------------------\n");
            }
            hero.HeroWinOrLose();
            devil.DevilWinOrLose();
        }

        public void Level10(Hero hero)
        {
            Console.Write("====================\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      Level 10"); // <-
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n====================\n");
            Devil devil = Devil.devils[9]; // <-
            //story
            string messageOfDevil = "You have come far, but this is where your journey ends. I am Malgor, the master of darkness. Your efforts are  useless.";
            string messageOfHero = "I have fought through your minions and faced countless dangers. I will not falter now. The light will prevail over your darkness.";
            string lastWordsOfMalgor1 = "No... this cannot be...";
            string lastWordsOfMalgor2 = "How... how could I be defeated by a human? This was not meant to be my fate!";
            string lastWordsOfMalgor3 = "You... you have no idea what you have done. This light you have brought... it is fragile. Darkness... darkness is eternal.";
            string lastWordsOfMalgor4 = "You have merely delayed the inevitable. My legacy... my minions... they will rise again. Darkness... will always find a way.";
            string lastWordsOfMalgor5 = "Remember, hero... the shadows are always watching.";
            string messageOfEndGame = $"In an epic battle, {hero.Name} faced Malgor, the sorcerer who had plunged the land into darkness. The clash was intense, with spells and sword strikes lighting up the dark chamber. Malgor's magic was powerful, but {hero.Name}'s heart was pure and unyielding. Drawing on all the strength and skills he had gained, {hero.Name} managed to pierce Malgor's defenses and deliver the final blow.\r\n\r\nWith Malgor defeated, the darkness began to lift. The sun broke through the clouds, bathing the land in light once more. The people rejoiced and hailed {hero.Name}. Peace returned, and {hero.Name}, though he could have claimed riches and power, chose to return to his simple life";
            string lastLine = "forever remembered as the hero who had conquered the darkness.";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{devil.Name} : ");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (char letter in messageOfDevil)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(800);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{hero.Name} : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (char letter in messageOfHero)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("< Click Enter To Start The Fight >");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            Console.Clear();
            //end of story

            Console.Write("====================\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      Level 10"); // <-
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n====================\n");
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
                    Console.Write("====================\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("      Level 10"); // <-
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n====================\n");
                    hero.Stat();
                    Console.Write("\t\t");
                    devil.Stat();
                    Console.WriteLine("\n\n---------------------------------------------\n");


                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{devil.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (char letter in lastWordsOfMalgor1)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(800);
                    Console.WriteLine("\n");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{devil.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (char letter in lastWordsOfMalgor2)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(800);
                    Console.WriteLine("\n");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{devil.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (char letter in lastWordsOfMalgor3)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(800);
                    Console.WriteLine("\n");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{devil.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (char letter in lastWordsOfMalgor4)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(800);
                    Console.WriteLine("\n");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{devil.Name} : ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (char letter in lastWordsOfMalgor5)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(800);
                    Console.WriteLine("\n\n");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("< Press Enter To Continue >");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();

                    //end of the game
                    Console.Clear();
                    Console.Write("=================\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("     The End"); // <-
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n=================\n");
                    foreach (char letter in messageOfEndGame)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(800);
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (char letter in lastLine)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(800);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("< Press Enter To Continue >");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    Console.Clear();

                    Console.Write("====================\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("      Level 10"); // <-
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n====================\n");
                    hero.OnLevel = hero.OnLevel < 11 ? 11 : hero.OnLevel; // <-
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Killed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{devil.Name} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("And Won\n");
                    int earnedCoins = 50; // <-
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

                Console.Write("====================\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("      Level 10"); // <-
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n====================\n");
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

