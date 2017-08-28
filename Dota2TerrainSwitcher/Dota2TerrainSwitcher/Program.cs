using System;

namespace Dota2TerrainSwitcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Run();
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
