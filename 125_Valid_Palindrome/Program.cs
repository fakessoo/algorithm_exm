using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _125_Valid_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "A man, a plan, a canal: Panama";
            //string s = "A man, a plan, a canal --Panama";
            string s = "race a car";
            Console.WriteLine(IsPalindrome(s));
        }

        public static bool IsPalindrome(string s)
        {

#if false
            // 내코드
            // 특수문자 삭제는 인터넷 참고
            // 실제로 돌아가게끔 만들기까지는 특수문자 삭제 코드를 알고서 접근해야함

            s = Regex.Replace(s, @"[^a-zA-Z0-9]", "").Trim().ToLower();

            int start = 0;
            int end = (s.Length - 1);

            while (end > start)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }

            return true;

#elif false

            // 1. Comprea with Reverse

            // Algorithm

            //  We'll reverse the given string and compare it with the original if those are equivalent, its a palindrome.(회문 : 앞이나 뒤에서 읽을때 동일한 단어나 구)
            //  Since only alphanumeric characters are considered, we'll filter out all other types of characters before we apply our algorithm.
            //  Additionally, because we're treating letters as case-insensitive, we'll convert the remaining letters to lower case.
            //  The digits will be left the same.

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                {
                    builder.Append(char.ToLower(s[i]));
                }
            }

            string filterString = builder.ToString();
            var filterArr = filterString.ToCharArray();
            Array.Reverse(filterArr);
            string reverseString = new string(filterArr);

            // Java의 StringBuilder와 다르게 Reverse() 명령이 없어서 Array를 이용함
            return filterString.Equals(reverseString);



            // Time complexity : O(n), in length n of the string

            //  We need to iterate thrice(3회) through the string:

            //      1. When we filter out non-alphanumeric characters, and convert the remaining characters to lower-case.
            //      2. When we reverse the string.
            //      3. When we compare the original and the reversed strings.

            //  Each iteration runs linear in time (since each character operation completes in constant time). Thus, the effective run-time complexity is linear.

            //  Space complexity : O(n), in length n of the string. We need O(n) additional space to stored the filtered string and the reversed string.

#elif true

            // 2. Two Pointers


            //  Algorithm

            //  Since the input string contains charaters that we need to ignore in our palindromic check, it becomes tedious(지루한, 싫증나는) to figure out the real middle point of our palindromic input.
            
            //      Instead of going outwards from the middle, we could just go inwards towards the middle!

            //  So, if we start traversing inwards, from both ends of the input string, we can expert to see the same characters, in the same order.
            //  The resulting algorithm is simple

            //      Set two pointers, one at each end of the input string.
            //      If the input is palindromic, both the pointers should point to equivalent characters at all times.
            //          If this condition is not met at any point of time, we break and return early.

            //      We can simply ignore non-alphanumeric charaters by continuing to traverse futher.
            //      Continue traversing inwards until the pointers meet in the middle.

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;
            }

            return true;

            //  Time complexity : O(n), in length n of the string. We traverse (가로지르다, 횡단하다) over each character at-most once, 
            //  until the two potiners meet in the middle, or when we break and return early.

            //  Space complexity : O(1), No extra space required, at all.
#endif
        }
    }
}
