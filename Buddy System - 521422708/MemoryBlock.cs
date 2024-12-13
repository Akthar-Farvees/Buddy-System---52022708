using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddy_System___521422708
{
    internal class MemoryBlock
    {
        public int Size { get; set; }
        public bool IsAllocated { get; set; }

        public MemoryBlock(int size)
        {
            Size = size;
            IsAllocated = false;
        }
    }
}
