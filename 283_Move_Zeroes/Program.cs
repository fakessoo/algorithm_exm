using System;

namespace _283_Move_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = new int[] { 2, 1 };
            int[] nums = new int[] { 0, 1, 0, 3, 12 };
            // int[] nums = new int[] { 0, 0, 1 };
            MoveZeroes(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
        public static void MoveZeroes(int[] nums)
        {
#if false
            //  난 개고생 했는데
            //  요 코드는 현타 오네 ㅋㅋ 엄청 간단하게 잡아버림

            // 2. Space Optimal, Operation Sub-Optimal
            int lastNonZeroFoundAt = 0;

            //  If the current element is not 0, then we need to 
            //  append it just in front of last non 0 element we found.
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != 0)
                {
                    nums[lastNonZeroFoundAt++] = nums[i];
                }
            }

            //  After we have finished processing new elements,
            //  all the non-zero elements are already at beginning of array.
            //  We just need to fill remaining array with 0's
            for (int i = lastNonZeroFoundAt; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

            //  Space complexity : O(1). Only constant space is used.
            //  Time complexity : O(n). However, the total number of operations are still sub-optimal.
            //  The total operations (array writes) that code does is 'n'(Total number of elements)

#elif true

            int temp = 0;
            // 3. Optimal
            for (int lastNonZeroFoundAt = 0, cur = 0; cur < nums.Length; cur++)
            {
                if (nums[cur] != 0)
                {
                    temp = nums[lastNonZeroFoundAt];
                    nums[lastNonZeroFoundAt] = nums[cur];
                    nums[cur] = temp;
                    lastNonZeroFoundAt++;
                }
            }

            //  Space complexity : O(1), Only constant space is used.
            //  Time complexity : O(n). However, the total number of oerpartions are optimal. 
            //  The total operations (array writes) that code does is Number of non-0 elements.
            //  This give us a much better best-case (when most of them elements are 0) complexity than last solution.
            //  However, the worst-case (when all elemtns are non-0) complexity for both algorithms is same.

#elif true

            //  내코드
            //  정리도 안되고 맘에 안듬

            int i = 0;
            int j = nums.Length - 1;
            int k, l = 0;
            int temp = 0;

            while (i < j)
            {
                if (nums[i] == 0)
                {
                    k = i;
                    l = k + 1;
                    while (k < j)
                    {
                        while (nums[l] == 0 && l < j)
                        {
                            l++;
                        }
                        temp = nums[l];
                        nums[l] = nums[k];
                        nums[k] = temp;
                        k++;
                    }
                    j--;
                }
                i++;
            }

#endif
        }
    }
}
