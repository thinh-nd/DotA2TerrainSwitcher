using System;
using System.Collections.Generic;

namespace Dota2TerrainSwitcher
{
    class Menu
    {
        private string[] Terrains = { "dota_coloseum", "dota_spring", "dota_autumn", "dota_winter", "dota_journey" };
        //private Dictionary<int, string> _terrains;

        //public Menu()
        //{
        //    _terrains = GetAvailableTerrains();
        //}

        //private Dictionary<int, string> GetAvailableTerrains()
        //{
        //    return new Dictionary<int, string>
        //    {
        //        { 1, "dota_coloseum" },
        //        { 2, "dota_spring" },
        //        { 3, "dota_autumn" },
        //        { 4, "dota_winter" }
        //    };
        //}

        private void ShowMenu()
        {
            Separator();
            for (int i = 0; i < Terrains.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Terrains[i]);
            }
            Separator();
        }

        private int AskChoice()
        {
            int choice = 0;
            Console.Write("Choice: ");
            var input = Console.ReadLine();
            int.TryParse(input, out choice);
            return choice;
        }

        private void Separator()
        {
            Console.WriteLine("---------------------------");
        }

        private bool IsChoiceValid(int choice)
        {
            return choice > 0 && choice <= Terrains.Length;
        }

        public void Run()
        {
            ShowMenu();
            var choice = AskChoice();
            if (!IsChoiceValid(choice))
            {
                Console.WriteLine("Input not supported");
                return;
            }

            var switcher = new Switcher();
            switcher.Switch(Terrains[choice - 1]);
        }
    }
}
