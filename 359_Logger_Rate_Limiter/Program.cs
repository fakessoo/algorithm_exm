using System;
using System.Collections.Generic;

namespace _359_Logger_Rate_Limiter
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.ShouldPrintMessage(1, "foo");
            logger.ShouldPrintMessage(2, "bar");
            logger.ShouldPrintMessage(3, "foo");
            logger.ShouldPrintMessage(8, "bar");
            logger.ShouldPrintMessage(10, "foo");
            logger.ShouldPrintMessage(11, "foo");
        }
    }

    public class Logger
    {
        /** Initialize your data structure here. */
        Dictionary<string, int> dict;

        public Logger()
        {
            dict = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!dict.ContainsKey(message))
            {
                dict.Add(message, timestamp + 10);
                Console.WriteLine("True");
                return true;
            }

            if (dict[message] > timestamp)
            {
                Console.WriteLine("False");
                return false;
            }
            else
            {
                dict[message] = timestamp + 10;
                Console.WriteLine("True");
                return true;
            }
        }
    }
}
