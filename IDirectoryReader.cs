using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskTree
{
    public interface IDirectoryReader
    {
        Directory ReadDirectoryFromString(string input);
    }
}
