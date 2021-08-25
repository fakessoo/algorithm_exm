using System;

namespace _88_Merge_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            //int[] nums2 = new int[] { 2, 5, 6 };
            //int[] nums1 = new int[] { 4, 5, 6, 0, 0, 0 };
            //int[] nums2 = new int[] { 1, 2, 3 };
            //int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            //int[] nums2 = new int[] { 2, 5, 6 };
            //int m = 3;
            //int n = 3;

            //int[] nums1 = new int[] { 4, 0, 0, 0, 0, 0 };
            //int[] nums2 = new int[] { 1, 2, 3, 5, 6 };
            //int m = 1;
            //int n = 5;

            int[] nums1 = new int[] { -1, 0, 0, 3, 3, 3, 0, 0, 0 };
            int[] nums2 = new int[] { 1, 2, 2 };
            int m = 6;
            int n = 3;

            Merge(nums1, m, nums2, n);
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // nums1을 기준으로 변경
            // nums1의 length는 m+n 기준으로 설정되어 있으므로 따로 length를 변경할 필요가 없다.

            // brute force
#if false

            int temp = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums2[j] < nums1[i] || (nums1[i] == 0 && i > m - 1))
                    {
                        temp = nums1[i];
                        nums1[i] = nums2[j];
                        nums2[j] = temp;
                    }
                }
            }

#elif false

            // 1. Merge and sort.

            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }
            Array.Sort(nums1);

            // Time complexity : O((n + m)log(n + m)).

            //  The cost of sorting a list of length x using a built-in sorting algorithm is O(xlogx). 
            //  Because in this case we're sorting a list of length m + n.
            //  we get a total time complexity of O((n + m)log(n + m)).

            // Space compexity : O(n), but it can vary.

            //  Most programming languages have a built-in sorting algorithm that uses O(n) space.

#elif false

            // 2. Three Pointers (Start From the Beginning)

            // Algorithm

            //  The simplest implementation would be to make a copy of the values in 'nums1', called 'nums1Copy', and then use two read potiners 
            //  and one write porter to read values from 'nums1Copy' and 'nums2' and write them into 'nums1'.
            //  
            //      - Initialize 'nums1Copy' to be a new array containing the first 'm' values of 'nums1'.
            //      - Initialize read pointer 'p1' to the beginning of 'nums1Copy'.
            //      - Initialize read pointer 'p2' to the beginning of 'nums2'.
            //      - Initialize write pointer 'p' to the beginning of 'nums1'.
            //      - While 'p' is still within 'nums1' : 
            //          if 'nums1Copy[p1]' exists and is less than or equal to 'nums2[p2]' : 
            //              Write 'nums1Copy[p1]' into 'nums1[p]', and increment 'p1' by '1'.
            //          Else
            //              Write 'nums2[p2]' into 'nums1[p]', and increment p2 by 1.
            //          Increment p by 1.


            // Make a copy of the first m elements of nums1.
            int[] nums1Copy = new int[m];
            for (int i = 0; i < m; i++)
            {
                nums1Copy[i] = nums1[i];
            }

            // Read pointers for nums1Copy and nums2 respectively.
            int p1 = 0;
            int p2 = 0;

            // Compare elements from nums1Copy and nums2 and write the smallest to nums1.
            for (int p = 0; p < m + n; p++)
            {
                //  We also need to ensure that p1 and p2 aren't over the boundaries
                //  of their respective arrays.
                if (p2 >= n || (p1 < m && nums1Copy[p1] < nums2[p2]))
                {
                    nums1[p] = nums1Copy[p1++];
                }
                else
                {
                    nums1[p] = nums2[p2++];
                }
            }

            //  Time complexity : O(n + m)

            //      We are performing n + 2⋅m reads and n + 2⋅m writes. 
            //      Because constants are ignored in Big O notation, this gives us a time complexity of O(n + m)

            //  Space complexity : O(m).
            
            //      We are allocating an additional array of length m

#elif true

            // 3. Three Pointers (Start From the End)

            // Interview Tip :
            //      This is a medium-level solution to an easy-level problem.
            //      Many of LeetCode's easy-level problems have more difficult solutions,
            //      and good candidates are expected to find them.

            // Interview Tip :
            //      Whenever you're trying to solve an array problem in-place, 
            //      always consider the possibillity of iterating backwards instead of forwards through the array.
            //      It can completely change the problem, and make it a lot easier.


            //int p1 = m - 1;
            //int p2 = n - 1;

            //for ( int p = m + n - 1; p >= 0; p--)
            //{
            //    if (p2 < 0)
            //        break;

            //    if (p1 >= 0 && nums1[p1] > nums2[p2])
            //    {
            //        nums1[p] = nums1[p1];
            //        p1--;
            //    }
            //    else
            //    {
            //        nums1[p] = nums2[p2];
            //        p2--;
            //    }
            //}

            // Complexity Analysis

            //      Time complexity : O(n + m).
            //          Same as Approach 2.

            //      Space complexity : O(1).
            //          Unlike Approach 2, we're not using an extra array.


            // 내 실패 코드
            // 접근은 맞았어. 실제로 알고리즘이 보였지만 정리가 되지 않았다.
            // 테스트를 할 때마다 콕콕 찔림
            // 돌리지 말고 테스트 하는 습관을 길러야 함

            //for (int i = nums1.Length - 1; i >= 0; i--)
            //{
            //    if (i < (nums1.Length - m) - 1)
            //    {
            //        if (nums1[m - 1] < nums2[n - 1])
            //        {
            //            nums1[i] = nums2[n - 1];
            //            n--;
            //        }
            //        else
            //        {
            //            nums1[i] = nums1[m - 1];
            //            nums1[m - 1] = nums2[n - 1];
            //            m--;
            //        }
            //    }
            //    else
            //    {
            //        if (0 < i - 1 && nums1[i - 1] > nums1[i])
            //        {
            //            int temp = nums1[i - 1];
            //            nums1[i] = nums1[i - 1];
            //            nums1[i - 1] = temp;
            //        }
            //    }
            //}

#endif

            for (int i = 0; i < nums1.Length; i++)
            {
                Console.Write("[" + nums1[i] + "]");
                if (i < nums1.Length - 1)
                    Console.Write("-");
            }

        }
    }
}
