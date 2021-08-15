using System;

namespace _26_Remove_Duplicates_from_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{ 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine("Result : " + RemoveDuplicates(nums));
        }

        public static int RemoveDuplicates(int[] nums)
        {
            // 반복된 k를 삭제하는 경우 첫번째 k가 남는다
            // return value 는 반복된 총 개수
            // non-decreasing order라는것은 정렬은 되있으나 반복된 수가 존재하는 정렬을 가리킴
            // compare check 
            // 메모리 할당은 한번으로 끝나야 함 = Space Complexity : O(1)
            // Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

            if (nums.Length == 0) 
                return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

    }
}
