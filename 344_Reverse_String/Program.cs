using System;

namespace _344_Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = new char[] { 'h', 'e', 'l', 'l', 'o' };
            ReverseString(s);

            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + " ");
            }
        }

        public static void helper(char[] s, int left, int right)
        {
            if (left >= right)
                return;

            char tmp = s[left];
            s[left++] = s[right];
            s[right--] = tmp;
            helper(s, left, right);
        }

        public static void ReverseString(char[] s)
        {

#if true

            // 1. Recursion, In-Place, O(N) Space

            helper(s, 0, s.Length - 1);

            //  Time complexity : O(N) time to perform N/2 swap
            //  Space complexity : O(N) to keep the recursion stack

#elif true
            // 2. Two Pointers, Iteration, O(1) Space

            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                char tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }

            //  Time complexity : O(N) to swap N/2 element
            //  Space complexity : O(1), it's a constant space solution.

#elif true
            // 내코드
            char temp = '\0';
            for (int i = 0, j = s.Length -1; i < j; i++, j--)
            {
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
#elif true
            // 내코드
            Array.Reverse(s);
#endif
        }
    }
}
