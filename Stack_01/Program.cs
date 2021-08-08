using System;
using System.Collections;

namespace Stack_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates and initializes a new Stack
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and Values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:     {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
            {
                Console.Write("     {0}", obj);
            }
            Console.WriteLine();
        }
    }
}
