using System;
using System.Collections;

namespace _937_Reorder_Data_in_Log_Files
{
    public class LogComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string log1 = (string)x;
            string log2 = (string)y;

            // split each log into two parts: <identifier, content>
            string[] split1 = log1.Split(" ", 2);
            string[] split2 = log2.Split(" ", 2);

            bool isDigit1 = Char.IsDigit(split1[1][0]);
            bool isDigit2 = Char.IsDigit(split2[1][0]);

            // case 1). both logs are letter-logs
            if (!isDigit1 && !isDigit2)
            {
                // first compare the content
                int cmp = split1[1].CompareTo(split2[1]);
                if (cmp != 0)
                    return cmp;

                // logs of same content, compare the identifiers
                return split1[0].CompareTo(split2[0]);
            }

            // case 2). one of logs is digit-log
            if (!isDigit1 && isDigit2)
            {
                // the letter-log comes before digit-logs
                return -1;
            }
            else if (isDigit1 && !isDigit2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // string[] logs = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            string[] logs = new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" };
            ReorderLogFiles(logs);
        }

        public static string[] ReorderLogFiles(string[] logs)
        {

#if true
            // Comparator

            // 1. The letter-logs should be prioritized above all digit-logs.
            // 
            // 2. Among the letter-logs, we should futher sort them firstly based on their contents,
            //      and then on their identifiers if the contents are identical.
            //
            // 3. Among the digit-logs, they should remain in the same order as they are in the collection.

            LogComparer myComp = new LogComparer();
            Array.Sort(logs, myComp);
            return logs;
#elif true


#endif 
        }
    }
}
