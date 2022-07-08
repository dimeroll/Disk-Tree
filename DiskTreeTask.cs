using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskTree
{
    public static class DiskTreeTask
    {
        private static IDirectoryReader directoryReader = new DirectoryReader();
        public static List<string> Solve(List<string> input)
        {
            Directory baseDir = new Directory(null);
            foreach(var str in input)
            {
                Directory directory = directoryReader.ReadDirectoryFromString(str);
                MoveSubDirectories(directory, baseDir);
            }
            return baseDir.OutputOrderedSubDirectories();
        }

        private static void MoveSubDirectories(Directory directory, Directory baseDir)
        {
            Directory dirFromBase = null;
            foreach(var dir in baseDir.SubDirectories)
            {
                if (dir.Name == directory.Name)
                    dirFromBase = dir;
            }
            if (dirFromBase == null)
                baseDir.Add(directory);
            else if(directory.SubDirectories.Count > 0)
                MoveSubDirectories(directory.SubDirectories.First(), dirFromBase);
        }
    }
}
