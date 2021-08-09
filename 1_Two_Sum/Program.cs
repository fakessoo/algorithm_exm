using System;
using System.Collections.Generic;

namespace _1_Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;
            TwoSum(nums, target);
        }

        public static int[] TwoSum(int[] nums, int target)
        {

#if false

            // time complexity : O(n)

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if(nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
#elif false

            Dictionary<int, int> dict = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement) && dict.GetValueOrDefault(complement) != i)
                {
                    return new int[] { i, dict.GetValueOrDefault(complement) };
                }
            }

            return null;

#elif true

            // for문 2개 돌려서 가는건 쉬움
            // 최적화를 위해 1개로 갈 방법으로 구성해야 함 time complexity : O(1)

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict.GetValueOrDefault(nums[i]), i };
                }
                dict.Add(nums[i], i);
            }
            return null;

#endif
        }
    }
}
