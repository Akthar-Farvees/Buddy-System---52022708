# Buddy System Memory Management

## Overview

This is a simple implementation of the **Buddy System Memory Management** algorithm in C#. The buddy system is a method of partitioning memory to satisfy allocation requests efficiently while minimizing fragmentation. It works by splitting memory blocks into halves (buddies) as needed and merging buddies when they are freed, provided they are the same size.

This console-based application allows users to allocate memory, free memory, and display the current state of memory blocks.

## Features

- **Memory Allocation**: Request a block of memory, which will be allocated in the smallest power-of-two size that fits the request.
- **Memory Deallocation**: Free a previously allocated memory block.
- **Memory State Display**: View the current memory allocation, including free and allocated blocks.
- **Buddy System Merging**: When adjacent free blocks (buddies) of the same size are found, they are merged to reduce fragmentation.

## How It Works

- The program starts with a single memory block of **1024 KB**.
- When allocating memory, the system finds the smallest available block that can accommodate the request and splits it into buddies as needed.
- When freeing memory, the program attempts to merge adjacent free blocks (buddies) to reduce fragmentation.

## Requirements

- **.NET Core SDK** (Version 3.1 or higher) or **.NET Framework**.
- A C# IDE or compiler (e.g., Visual Studio, Visual Studio Code).

## How to Run the Project

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/buddy-system-memory.git
   cd buddy-system-memory
   ```

2. **Build the Project**:
   ```bash
   dotnet build
   ```

3. **Run the Project**:
   ```bash
   dotnet run
   ```

4. **Interact with the Console Application** by choosing options:
   - **1**: Allocate Memory
   - **2**: Free Memory
   - **3**: Print Memory State
   - **4**: Exit

## Example Usage

```plaintext
Choose Here:
1. Allocate Memory
2. Free Memory
3. Print Memory State
4. Exit

Enter your choice here: 1
Enter the size of memory you need to allocate (in KB): 200

Allocated Block of Size: 256KB

Current Memory State:
Total Memory: 1024KB
Allocated Memory: 256KB
Free Memory: 768KB

Free Blocks:
Block Size: 256KB, Allocated: True
Block Size: 256KB, Allocated: False
Block Size: 512KB, Allocated: False
```

## Code Structure

```
BuddySystemMemory/
│-- Program.cs          # Main entry point with core logic
│-- MemoryBlock.cs      # MemoryBlock class representing memory segments
└-- README.md           # Project documentation
```

## Key Methods

### `AllocateMemory()`

Prompts the user to enter the size to allocate. It finds the smallest power-of-two block that fits and allocates it by splitting larger blocks if necessary.

### `FreeMemory()`

Prompts the user to enter the size of the block to free. After freeing, it attempts to merge adjacent buddies.

### `PrintMemoryState()`

Displays the current state of all memory blocks, including the total, allocated, and free memory.

### `GetSmallestPowerOfTwo(int size)`

Returns the smallest power of two greater than or equal to the requested size.

### `SplitBlock(int index, int allocationSize)`

Splits a block into smaller blocks until it matches the requested allocation size.

### `MergeBuddies()`

Merges adjacent free blocks (buddies) of the same size.

## License

This project is licensed under the **MIT License**. Feel free to use and modify it.

## Author

**Akthar Farvees**  
[Check My Profile](https://github.com/Akthar-Farvees)  
