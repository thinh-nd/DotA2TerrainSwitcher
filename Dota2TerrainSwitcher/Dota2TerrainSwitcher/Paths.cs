using System;
using System.IO;

namespace Dota2TerrainSwitcher
{
    public static class Paths
    {
        public const string VpkRunnerPath = @"D:\Games\Steam\steamapps\common\dota 2 beta\game\dota\maps\vpk_tool\";
        public const string Dota2MapPath = @"D:\Games\Steam\steamapps\common\dota 2 beta\game\dota\maps\";

        public static bool IsFolderExists(string path)
        {
            if (Directory.Exists(path)) return true;

            Console.WriteLine("Path {0} does not exist.", path);
            return false;
        }

        public static bool IsFileExists(string path)
        {
            if (File.Exists(path)) return true;

            Console.WriteLine("File {0} does not exist.", path);
            return false;
        }

        public static bool IsFileExists(string path, string extension)
        {
            var isFileExists = IsFileExists(path);
            if (!isFileExists) return false;

            if (new FileInfo(path).Extension == ("." + extension)) return true;

            Console.WriteLine("Specified file is not a {0} file", extension);
            return false;
        }
    }
}
