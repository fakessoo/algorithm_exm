using System;
using System.Collections;

namespace _28_Implement_strStr__
{
    class Program
    {
        static void Main(string[] args)
        {
            string haystack = "hello";
            string needle = "ll";
            Console.WriteLine(StrStr(haystack, needle));
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) 
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (i + needle.Length > haystack.Length)
                    return -1;

                for (int j = 0; j < needle.Length; j++)
                {
                    if (needle[j] == haystack[i+j])
                    {
                        if (j == needle.Length - 1)
                            return i;
                    }
                    else
                        break;
                }
            }

            return -1;
        }
    }
}
