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
            int[] result = TwoSum(nums, target);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        public static int[] TwoSum(int[] nums, int target)
        {

#if true

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

#elif false

            // for문 2개 돌려서 가는건 쉬움
            // 최적화를 위해 1개로 갈 방법으로 구성해야 함 time complexity : O(1)

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict.GetValueOrDefault(complement), i };
                }
                dict.Add(nums[i], i);
            }
            return null;

#endif
        }
    }
}
