using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public static class Save
    {
        public static void SaveGame(Hero hero)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "StateOfHero.txt");
            string states = $"{hero.Name},{hero.MaxHealth},{hero.Power},{hero.Healing},{hero.Coin},{hero.OnLevel},{Arcade.StageNumber}";
            File.WriteAllText(filePath, states);
        }
    }
}
