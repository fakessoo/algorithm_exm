using System;
using System.Collections.Generic;

namespace _167_Two_Sum_II_Input_array_is_sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] result = TwoSum(numbers, target);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }

        }

        public static int[] TwoSum(int[] numbers, int target)
        {

#if true

            // 1. Two Pointers

            //  Algorithm
            //  We can apply Two Sum's solutions directly to get O(n²) time,
            //  O(1) space using brute force and O(n) time, O(n) space using hash table.
            //  However, both existing solutions do not make use of the property that the input array is sorted. We can do better.

            //  We use two indices, initially pointing to the first and the last element, respectively.
            //  Compare the sum of these two elements with 'target'.
            //  If the sum is equal to 'target', we found the exactly only solution. If it is less than target, we increase the smaller index by one.
            //  If it is greater than target, we decrease the larger index by one. 
            //  Move the indices and repeat the comparison until the solution is found.

            //  Let [..., a,b,c, ..., d,e,f, ...] be the input array that is sorted in ascending order and let the elements 'b' and 'e'
            //  be the exactly only solution.
            //  Because we are moving the smaller index from left to right, and the larger index from right to left, at some point,
            //  one of the indices must reach either 'b' or 'e'. 
            //  Without loss of generality, suppose the smaller index reaches 'b' first.
            //  At this time, the sum of these two elements must be greater than target.
            //  Based on our algorithm, we will keep moving the larger index to the left until we reach the solution.

            int low = 0;
            int high = numbers.Length - 1;

            while (low < high)
            {
                int sum = numbers[low] + numbers[high];

                if (sum == target)
                {
                    return new int[] { low + 1, high + 1 };
                }
                else if (sum < target)
                {
                    ++low;
                }
                else
                {
                    --high;
                }
            }
            return null;

#elif false
            // 이 과정은 같은 값이 존재할 수 있으므로 non-decreasing order에서 적용되지 않음
            // 아직도 머리속에 안 들어와져 있음
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int matched_idx = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                if (dic.ContainsValue(complement))
                {
                    matched_idx = i;
                    break;
                }
                dic.Add(i, numbers[i]);
            }

            if (matched_idx > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    if (dic[i] == target - numbers[matched_idx])
                    {
                        return new int[] { i + 1, matched_idx + 1 };
                    }
                }
            }
            return new int[] { };

#elif true

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (target - numbers[i] == numbers[j])
                    {
                        return new int[] { i + 1, j + 1 };
                    }
                }
            }
            return new int[] {};
#endif
        }
    }
}
