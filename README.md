# Custom Enumerators in C#

This repository provides a collection of educational examples demonstrating how to create and use **custom enumerators** in C#. Its primary goal is to help you understand how data structures can be traversed, how the **Iterator pattern** works, and how to write reusable **programming algorithms** that work across different types of data.

## Why this project?

In C#, we often rely on `foreach` or LINQ, which handle the details of moving through data automatically. This project explores what happens "under the hood" by building enumerators from scratch, showing you:

-   How to control the movement through a collection (`First`, `Next`, `End`, `Current`).
    
-   How to create universal tools that work on arrays, lists, graphs, files, or even generated sequences like Fibonacci.
    
-   How to write standard programming algorithms (summation, searching, finding the maximum) once, and use them on any data structure.
    

## Key Concepts

-   **Iterator Pattern:** Understanding the logic required to step through elements of any collection one by one.
    
-   **Common Algorithms:** Implementing basic programming tasks like counting, searching, and calculating totals independently of the underlying data storage.
    
-   **Resource Management:** How to properly close files or release resources while iterating through data.
    

## Project Structure

-   **`Enumerators/`**: The core library containing the interface definitions, the specific enumerator implementations for various data structures (arrays, matrices, sets, stacks, queues, graphs), and the shared algorithm library.
    
-   **`Enumerators.ConsoleApp/`**: A sample application demonstrating how to use these enumerators and algorithms in practice.
    

## How to Use

1.  Clone the repository.
    
2.  Open the solution in Visual Studio or your preferred IDE.
    
3.  Explore the implementations in the `Enumerators` project to see how each data structure is traversed.
    
4.  Run the `Enumerators.ConsoleApp` to see the enumerators in action and test the built-in programming algorithms.
    

## Contributing

This is an open-source project intended for educational purposes. Feel free to fork the repository, experiment with the code, or add new data structures and algorithms to help others learn!