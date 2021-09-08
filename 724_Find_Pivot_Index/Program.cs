using System;

namespace _724_Find_Pivot_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] nums = new int[] { 1, 7, 3, 6, 5, 6 };
            // int[] nums = new int[] { 1, 2, 3 };
            // int[] nums = new int[] { 2, 1, -1 };
            int[] nums = new int[] { -1, -1, -1, -1, -1, 0 };
            // int[] nums = new int[] { -1, -1, -1, -1, 0, -1 };
            // int[] nums = new int[] { -1, -1, -1, -1, 1, 1 };
            Console.Write(PivotIndex(nums));
        }

        public static int PivotIndex(int[] nums)
        {
#if true

            // 1. Prefix Sum

            // Intuition and Algorithm

            // We need to quickly compute the sum of values to the left and the right of every index.

            //  Let's say we knew 'S' as the sum of the numbers, and we are at index 'i'.
            //  If we knew the sum of numbers 'leftsum' that are to the left of index 'i',
            //  Then the other sum to the right of the index would just be 'S - num[i] - leftsum'

            //  As such, we only need to know about 'leftsum' to check whether an index is a pivot index in constant time.
            //  Let's do that as we iterate through candidate indexes 'i', we will maintain the conrrect avlue of 'leftsum'


            int sum = 0;
            int leftsum = 0;
            
            foreach (int x in nums)
                sum += x;

            for (int i = 0; i < nums.Length; i++)
            {
                if (leftsum == (sum - leftsum - nums[i]))
                    return i;
                leftsum += nums[i];
            }
            return -1;

            //  Time complexity : O(n), where N is the length of nums.

            //  Space complexity : O(1), the space used by leftsum and S

            //  아직도 생각하는 방향이 약하다.

#elif true
            //  내코드
            //  쉽게 접근할 수 있을줄 알았는데 다양한 테스트에 걸려
            //  오류가 지속적으로 났다.
            //  알고리즘에 대한 재고심이 필요.

            int i = 0;
            int j = nums.Length - 1;
            int sum_left = nums[i];
            int sum_right = nums[j];
            int result = -1;

            while (i < j)
            {
                if (sum_left < sum_right)
                {
                    i++;
                    sum_left += nums[i];
                }
                else if (sum_left > sum_right)
                {
                    j--;
                    sum_right += nums[j];
                }
                else
                {
                    i++;
                    j--;
                    sum_left += nums[i];
                    sum_right += nums[j];
                }
            }

            if (i == j)
                result = i;

            return result;

#endif
        }
    }
}
