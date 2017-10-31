using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rdbCore;

namespace rMOD.Structures
{
    class CoreInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public Core Core { get; set; }

        public CoreInfo() { }

        public CoreInfo(int index, Encoding encoding)
        {
            Index = index;
            this.Core = new Core(encoding);
        }

        public CoreInfo(int index, string name, Encoding encoding)
        {
            Index = index;
            Name = name;
            Core = new Core(encoding);
        }
    }
}
