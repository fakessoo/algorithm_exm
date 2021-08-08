using System;

namespace _14_Longest_Common_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[] { "flower", "flow", "flight" };
            Console.WriteLine(LongestCommonPrefix(strs));
        }

        public static string LongestCommonPrefix(string[] strs)
        {

            // Input: strs = ["flower","flow","flight"]
            // Output: "fl"

            // Input: strs = ["dog","racecar","car"]
            // Output: ""
            // Explanation: There is no common prefix among the input strings.


            // Goal : longest prefix as string

            // Features : prefix is always checking in the begining of the index
            // if there is not matched then i can break the loop
            // what is the best performance to handle the data

            // should be change to the chars from string one by one
            // its array i can access exact index on it.
            // fully loop all the string array

            // only using lower case of eng

#if false
            string prefix_result = "";
            for (int idx = 0; idx < strs[0].Length; idx++)
            {
                char stored_chr = strs[0][idx];
                bool[] chr_chk_arr = new bool[strs.Length];
                chr_chk_arr[0] = true;

                for (int i = 1; i < strs.Length; i++)
                {
                    if (idx < strs[i].Length)
                    {
                        char compare_chr = strs[i][idx];
                        if (stored_chr == compare_chr)
                        {
                            chr_chk_arr[i] = true;
                        }
                        else
                        {
                            chr_chk_arr[i] = false;
                            break;
                        }
                    }
                    else
                        break;
                }

                for (int i = 0; i < chr_chk_arr.Length; i++)
                {
                    if (chr_chk_arr[i] == false)
                        return prefix_result;
                }

                prefix_result += stored_chr;
            }
            return prefix_result;
#else

            // optimized
            string prefix_result = "";
            for (int idx = 0; idx < strs[0].Length; idx++)
            {
                char stored_chr = strs[0][idx];
                for (int i = 1; i < strs.Length; i++)
                {
                    if (idx < strs[i].Length)
                    {
                        char compare_chr = strs[i][idx];
                        if (stored_chr != compare_chr)
                        {
                            prefix_result = strs[0].Substring(0, idx);
                            return prefix_result;
                        }
                    }
                    else
                        return prefix_result;
                }
                prefix_result += stored_chr;
            }
            return prefix_result;
#endif
        }

    }
}
