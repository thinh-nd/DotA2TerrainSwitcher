using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Dota2TerrainSwitcher
{
    class Switcher
    {
        public void Switch(string terrainName)
        {
            var success = false;
            Console.WriteLine("Working...");

            if (!Paths.IsFolderExists(Paths.Dota2MapPath) || !Paths.IsFolderExists(Paths.VpkRunnerPath))
                return;

            var vpkRunner = new VpkRunner(Paths.VpkRunnerPath, Paths.Dota2MapPath);

            vpkRunner.TryExtract("dota.vpk");
            vpkRunner.TryExtract(terrainName + ".vpk");

            var vpkExtractedPath = Path.Combine(Paths.Dota2MapPath, terrainName);
            if (!Paths.IsFolderExists(vpkExtractedPath)) 
            {
                Console.WriteLine("Failed to extract vpk file");
                return;
            }

            FileSystem.CopyDirectory(vpkExtractedPath, Path.Combine(Paths.Dota2MapPath, "dota"), true);
            success = vpkRunner.TryCreate("dota");
            if (success) Console.WriteLine("Terrain switched successfully.");
        }
    }
}
