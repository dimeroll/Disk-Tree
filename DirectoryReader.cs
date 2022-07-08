using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskTree
{
    public class DirectoryReader : IDirectoryReader
    {
        public Directory ReadDirectoryFromString(string input)
        {
            const int delimiterCode = 92;
            string dirName = "";
            Directory directory = null;
            Directory resDir = null;
            bool isResDirAssigned = false;

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c != delimiterCode)
                    dirName += c;
                if (c == delimiterCode || i == input.Length - 1)
                {
                    if (directory == null)
                    {
                        directory = new Directory(dirName);
                        if (!isResDirAssigned)
                        {
                            resDir = directory;
                            isResDirAssigned = true;
                        }
                    }
                    else
                    {
                        var subDirectory = new Directory(dirName);
                        directory.Add(subDirectory);
                        directory = subDirectory;
                    }
                    dirName = "";
                }
            }
            return resDir;
        }
    }
}
