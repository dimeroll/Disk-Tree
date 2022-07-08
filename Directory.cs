using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskTree
{
    public class Directory : IComparable
    {
        public string Name { get; private set; }
        public List<Directory> SubDirectories { get; private set; }

        private bool isOrdered = false;

        public Directory(string name)
        {
            Name = name;
            SubDirectories = new List<Directory>();
        }

        public void Add(Directory directory) => SubDirectories.Add(directory);

        private void OrderDirectories()
        {
            SubDirectories = SubDirectories.OrderBy(d => d).ToList();
            foreach (var dir in SubDirectories)
                dir.OrderDirectories();

            isOrdered = true;
        }

        public List<string> OutputSubDirectories(string spaces)
        {
            var result = new List<string>();
            foreach (var dir in SubDirectories)
            {
                result.Add(spaces + dir.Name);
                result.AddRange(dir.OutputSubDirectories(spaces + " "));
            }

            return result;
        }

        public List<string> OutputOrderedSubDirectories()
        {
            if (!isOrdered)
                OrderDirectories();
            return OutputSubDirectories("");
        }

        public int CompareTo(object obj)
        {
            return String.CompareOrdinal(this.Name, (obj as Directory).Name);
        }
    }
}
