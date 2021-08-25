using System;
using System.Collections.Generic;

namespace _387_First_Unique_Character_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "loveleetcode";
            //string s = "aabb";
            string s = "dddccdbba";
            //string s = "aadadaad";
            Console.WriteLine(FirstUniqChar(s));
        }

        public static int FirstUniqChar(string s)
        {
            // brute force
            //int ret_val = -1;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    char target = s[i];
            //    bool matched = false;
            //    for (int j = 0; j < s.Length; j++)
            //    {
            //        if (target == s[j] && i != j)
            //        {
            //            matched = true;
            //        }
            //    }

            //    if (!matched)
            //    {
            //        ret_val = i;
            //        break;
            //    }
            //}


            // 1 for
            // 하나의 for문으로 줄여보려 했지만 실제 값이 3개가 연동되어야 해서 그렇게 할 수 없었다.
            // Solution을 보니 이중for문이 아닌 두개의 for문으로 관리하는 것을 보고 참고하여 코드를 수정함.

            int ret_val = -1;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = s.Length -1; i >= 0; i--)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], 1);
                }
                else
                {
                    dic[s[i]] = dic[s[i]] + 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dic[s[i]] == 1)
                {
                    ret_val = i;
                    break;
                }
            }
            return ret_val;

            // Time complexity : O(N) since we go through the string of length N two times.
            // Space complexity : O(1) because English alphabet contains 26 letters.
        }
    }
}
