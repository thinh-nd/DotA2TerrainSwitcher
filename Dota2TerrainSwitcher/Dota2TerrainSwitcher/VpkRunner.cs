using System.Diagnostics;
using System.IO;

namespace Dota2TerrainSwitcher
{
    class VpkRunner
    {
        private string VpkRunnerPath;
        private string WorkingFolder;

        public VpkRunner(string vpkRunnerPath, string workingFolder)
        {
            VpkRunnerPath = vpkRunnerPath;
            WorkingFolder = workingFolder;
        }

        private void Run(string targetName)
        {
            Process p = new Process();
            p.StartInfo.WorkingDirectory = VpkRunnerPath;
            p.StartInfo.FileName = "vpk.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.Arguments = '\"' + WorkingFolder + targetName + '\"';
            p.Start();
            p.WaitForExit();
        }

        public bool TryCreate(string folderName)
        {
            var folderPath = Path.Combine(WorkingFolder, folderName);
            if (!Paths.IsFolderExists(folderPath)) return false;

            Run(folderName);
            return true;
        }

        public bool TryExtract(string vpkFileName)
        {
            var filePath = Path.Combine(WorkingFolder, vpkFileName);
            if (!Paths.IsFileExists(filePath, "vpk")) return false;

            Run(vpkFileName);
            return true;
        }
    }
}
