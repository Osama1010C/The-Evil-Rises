using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public static class Info
    {
        public static void GameInfo()
        {
            Console.Write("=================\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("      Info ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n=================\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Epic Quest of The Hero\n\n");

            // Introduction
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) It's an RPG Game works on your terminal\n");
            Console.WriteLine("2) You will face a lot of Devils\n");
            Console.WriteLine("3) You have to save your people\n");

            Console.WriteLine("----------------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Arcade Mode Unlocks After Level 3\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1) Once the player completes level 3, they unlock Arcade Mode, a continuous survival challenge where the hero fights endless waves of enemies \n");
            Console.WriteLine("2) This mode increases difficulty with each stage and rewards players with coins as they progress\n");

            Console.WriteLine("======================================================================================================================\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n< Click Enter To Back >");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
