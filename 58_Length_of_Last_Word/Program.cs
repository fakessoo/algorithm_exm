using System;

namespace _58_Length_of_Last_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "   fly me   to   the moon  ";
            Console.WriteLine(LengthOfLastWord(s));
        }

        public static int LengthOfLastWord(string s)
        {

#if true

            // 내 코드

            string input_val = s.Trim();
            string[] input_arr = input_val.Split(" ");
            return input_arr[input_arr.Length -1].Length;

#elif false

            // 1. String Index Manipulation

            // trim the trailing spaces.
            int p = s.Length - 1;
            while (p >= 0 && s[p] == ' ')
            {
                p--;
            }

            // complete the length of tha last word
            int length = 0;
            while (p >= 0 && s[p] != ' ')
            {
                p--;
                length++;
            }
            return length;

            // Time Complexity : O(N), where N is the length of the input string.

            // In the worst case, the input string might contain only a single word, which implies that we would need to iterate through the entire string to obtain the result.

            // Space Complexity : O(N), only constant memory is consumed, regardless the input.

#elif false

            // 2. One-loop Iteration

            int p = s.Length;
            int length = 0;

            while(p > 0)
            {
                p--;
                // we're in the middle of the last word
                if (s[p] != ' ')
                {
                    length++;
                }
                // here is the end of last word
                else if (length > 0)
                {
                    return length;
                }
            }
            return length;

            // Time complexity : O(N), where N is the length of the input string.

            // This approach has the same time complexity as the previous approach(1). The only difference is that we combined two loops into one.

            // Space Complexity : O(1), again a constant memory is consumed, regardless the input.

#elif false
            
            // 3. Built-in String Functions
            
            s = s.Trim();
            return s.Length - s.LastIndexOf(" ") - 1;

            // Time Complexity : O(N), where N is the length of the input string.

            // Since we use some built-in function from the String data type, we should look into the complexity of each built-in function that we used, 
            // in order to obtain the overall time complextiy of our algorithm.

            // It would be safe to assume the time complextiy of the methods such as "str.split()" and "String.lastIndexOf()" to be O(N),
            // since in the worst case we would need to scan the entire string for both methods.

            // Space complexity : O(N), Again, we should look into the built-in functions that we used in the algorithm.

            // In the Java implementation, we used the function "String.trim()" which returns a copy of the input string without leading and trailing whitesplace.
            // Therefore, we would need O(N) space for our algorithm to hold this copy.

            // In the Python implemetation, we used "str.split()", which returns a lit of substrings that are separated by the space delimiter.
            // As the result, we would need O(N) space for our algorithm to store this list.

#endif

        }
    }
}
