using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddy_System___521422708
{
    class Program
    {
        static List<MemoryBlock> memoryBlocks = new List<MemoryBlock> { new MemoryBlock(1024) };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose Here:");
                Console.WriteLine("1. Allocate Memory");
                Console.WriteLine("2. Free Memory");
                Console.WriteLine("3. Print Memory State");
                Console.WriteLine("4. Exit\n");

                Console.Write("Enter your choice here: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AllocateMemory();
                        break;
                    case "2":
                        FreeMemory();
                        break;
                    case "3":
                        PrintMemoryState();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        static void AllocateMemory()
        {
            Console.Write("Enter the size of memory you need to allocate (in KB): ");
            if (int.TryParse(Console.ReadLine(), out int size))
            {
                int allocationSize = GetSmallestPowerOfTwo(size);
                bool allocated = false;

                for (int i = 0; i < memoryBlocks.Count; i++)
                {
                    if (!memoryBlocks[i].IsAllocated && memoryBlocks[i].Size >= allocationSize)
                    {
                        SplitBlock(i, allocationSize);
                        memoryBlocks[i].IsAllocated = true;
                        Console.WriteLine($"\nAllocated Block of Size: {allocationSize}KB\n");
                        allocated = true;
                        PrintMemoryState();
                        break;
                    }
                }

                if (!allocated)
                {
                    Console.WriteLine("Not enough memory to allocate the requested size.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        static void FreeMemory()
        {
            Console.Write("Enter the size of the memory block you want to free (in KB): ");
            if (int.TryParse(Console.ReadLine(), out int size))
            {
                for (int i = 0; i < memoryBlocks.Count; i++)
                {
                    if (memoryBlocks[i].IsAllocated && memoryBlocks[i].Size == size)
                    {
                        memoryBlocks[i].IsAllocated = false;
                        Console.WriteLine($"Freed Block of Size: {size}KB\n");
                        MergeBuddies();
                        PrintMemoryState();
                        return;
                    }
                }
                Console.WriteLine("No allocated block of that size found.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        static void PrintMemoryState()
        {
            int totalMemory = 1024;
            int allocatedMemory = memoryBlocks.Where(b => b.IsAllocated).Sum(b => b.Size);
            int freeMemory = totalMemory - allocatedMemory;

            Console.WriteLine("\nCurrent Memory State:");
            Console.WriteLine($"Total Memory: {totalMemory}KB");
            Console.WriteLine($"Allocated Memory: {allocatedMemory}KB");
            Console.WriteLine($"Free Memory: {freeMemory}KB\n");

            Console.WriteLine("Free Blocks:");
            foreach (var block in memoryBlocks)
            {
                Console.WriteLine($"Block Size: {block.Size}KB, Allocated: {block.IsAllocated}");
            }
        }

        static int GetSmallestPowerOfTwo(int size)
        {
            int power = 1;
            while (power < size)
            {
                power *= 2;
            }
            return power;
        }

        static void SplitBlock(int index, int allocationSize)
        {
            while (memoryBlocks[index].Size > allocationSize)
            {
                int newSize = memoryBlocks[index].Size / 2;
                memoryBlocks[index].Size = newSize;
                memoryBlocks.Insert(index + 1, new MemoryBlock(newSize));
            }
        }

        static void MergeBuddies()
        {
            for (int i = 0; i < memoryBlocks.Count - 1; i++)
            {
                if (!memoryBlocks[i].IsAllocated && !memoryBlocks[i + 1].IsAllocated && memoryBlocks[i].Size == memoryBlocks[i + 1].Size)
                {
                    memoryBlocks[i].Size *= 2;
                    memoryBlocks.RemoveAt(i + 1);
                    i = -1; 
                }
            }
        }
    }

}

