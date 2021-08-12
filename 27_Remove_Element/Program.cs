using System;

namespace _27_Remove_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{ 0,1,2,2,3,0,4,2 };
            int val = 2;
            RemoveElement(nums, val);
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }
    }
}
