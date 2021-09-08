using System;

namespace _1480_Running_Sum_of_1d_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            // int[] nums = new int[] { 1, 1, 1, 1, 1 };
            nums = RunningSum(nums);
            for (int i = 0; i < nums.Length; i++)
                Console.Write(nums[i] + " ");
        }

        public static int[] RunningSum(int[] nums)
        {
#if false
            
            // 1. Using Separate Space

            // Algorithm
            //  1. Define an array 'result'.
            //  2. Initialize the first element of result with the first element of the input array
            //  3. At index 'i' append the sum of the element 'nums[i]' and previous running sum 'result[i - 1]' to the 'result' array
            //  4. We repeat step 3 for all indices from 1 to n-1

            int[] result = new int[nums.Length];

            //  Initialize first element of result array with first element in nums.
            result[0] = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                //  Result at index 'i' is sum of result at 'i-1' and element at 'i'
                result[i] = result[i - 1] + nums[i];
            }
            return result;

            //  Time complexity : O(n) where n is the length of the input array. 
            //      This is because we use a single loop that iterates over the entire array to calculate the running sum.

            //  Space compleixty : O(1) since we don't use any additional space to find the running sum.
            //      Not that we do not take into consideration the space occupied by the output array.

            // 내 코드보다 좋지않음 
            //   Array 생성으로 메모리를 더 사용함

#elif true
            // 2. Using Input Array for Output
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }
            return nums;

            //  이것도 하나의 방법
            //  이것도 고려를 해보아야 하는게 피벗중심을 뒤쪽으로 모아서 처리하는 방법도 생각해보아야 함

            //  Time complexity : O(n) where n is the length of input array.

            //  Space complexity : O(1) since we don't use any additional space to find the running sum.
            //      Note that we do not take into consideration the space occupied by the output array.

#elif true

            // 내코드
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                nums[i] = sum;
            }
            return nums;

#endif
        }
    }
}
