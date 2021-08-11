using System;

namespace _53_Maximum_Subarray
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Program pr = new Program();
            pr.MaxSubArray(nums);
        }

        public int MaxSubArray(int[] nums)
        {

#if false
            // Brute Force

            // 1. Initialize a variable 'maxSubarray = -infinity' to keep track of the best subarray.
            // We need to use negative infinity, not 0, because it is possible that there are only negative numbers in the array.

            // 2. Use a for loop that considers each index of the array as a starting point.

            // 3. For each starting point, create a variable 'currentSubarray = 0'.
            // Then loop through the array from the starting index, adding each element to currentSubarray.
            // Every time we add an element it represents a possible subarray
            //  - so continuously update maxSubArray to contain the maximum out of the currentSubarray and itself

            // 4. Return maxSubarray.

            int maxSubarray = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                // 시작 포인트를 찾기위한 첫번째 루프
                int currentSubarray = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    // 지정된 시작 포인트를 기준으로 Sum값을 구함 
                    // 결국 첫번째 배열부터 하나씩 빠진 Sum값을 구해서 Max값과 비교하여 높은값을 남기는 방식
                    currentSubarray += nums[j];
                    maxSubarray = Math.Max(maxSubarray, currentSubarray);
                }
            }

            return maxSubarray;

            // Time complexity : O(N²), where N is the length of nums.
            // We use 2 nested 'for' loops, with each loop iterating through nums.

            // Space complexity : O(1)
            // No matter how big the input is, we are only ever using 2 variables: 'ans' and 'currentSubarray'

#elif false

            // Dynamic Programming, Kadane's Algorithm

            // 언제라도 maximum 또는 minimum 문제가 나오면 DP를 고려하라

            // 1. Initialize 2 integer variables. Set both of them equal to the first value in the array.
            //      'currentSubarray' will keet the running count of the current subarray we are focusing on.
            //      'maxSubarray' will be our final return value. Continuously update it whenever we find a bigger subarray.

            // 2. Iterate through the array, starting with the 2nd element (as we used the first element to initialize our variables).
            //  For each numbers, add it to the 'currentSubarray' we are building. 
            //  If 'currentSubarray' becomes negative, we know it isn't worth keeping, so throw it away.
            //  Remember to update 'maxSubarray' every time we find a new maximum. 

            // 3. Return 'maxSubarray'

            // Initialize our variables using the first element.
            int currentSubarray = nums[0];
            int maxSubarray = nums[0];

            // Start with the 2nd element since we already used the first one.
            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];

                // If current_subarray is negative, then throw it away. Otherwise, keep adding to it.
                currentSubarray = Math.Max(num, currentSubarray + num);
                maxSubarray = Math.Max(currentSubarray, maxSubarray);
            }

            return maxSubarray;

            // Time complexity : O(N), where N is the length of the nums.
            // Space complexity : O(1)
            //      No matter how long the input is. we are only ever using 2 variables: 'currentSubarray' and 'maxSubarray'.

#elif true

            // Divide and Conquer (Advanced)
            // 각개전투

            // 1. Define a helper function that we will use for recursion

            //      - this function will take an input 'left' and 'right', which defines the bounds of the array.
            //          The return value of this function will be the best possible subarray for the array that fits between left and right.

            //      - if 'left > right', we have an empty array. return negative infinity.

            //      - Find the midpoint of our array.
            //          This is (left + right) / 2, rounded down, Using this midpoint,
            //          find the best possible subarray that uses elements form both sides of the array with algorithm detailed in the animation above.

            //      - The best subarray using elements from both sides is only 1 of 3 possibilities. 
            //          We still need to find the best subarray using only the left or right halves.
            //          So, call this function again, once with the left half, and once with the right half.

            //      - Return the largest of the 3 values - the best left half sum, the best right half sum, and the best combined sum.

            //  2. Call our helper function with the entire input array ( left = 0, right = length - 1 ). This is our final answer, so return it.

            numsArray = nums;

            // Our helper function si designed to solve this problem for 
            // any array - so just call it using the entire input!
            return findBestSubarray(0, numsArray.Length - 1);

            // Time complexity : O(N logN), where N is the length of nums
            //      On or first call to 'findBestSubarray', we use for loops to visit every element of nums.
            //      Then, we split the array in half and call 'findBestSubarray' with each half, which combined is every element of nums again.
            //      Then, both those halves will be split in half, and 4 more calls to 'findBestSubarray' will happen, each with a quarter of 'nums'.
            //      As you can see, every time the array is split, we still need to handle every element of the original input 'nums'.
            //      We have to do this log N times since that's how many times an array can be split in half.

            //  Space complexity : O(log N), where N is the length of 'nums'.
            //      The extra space we use relative to input size is solely occupied by the recursion stack.
            //      Each time the array gets split in half, another call of 'findBestSubarray' will be added to the recursion stack,
            //      until calls start to get resolved by the base case - remember, the base case happends at an empty array, which occurs after log N calls.

#endif
        }

        private int[] numsArray;
        private int findBestSubarray(int left, int right)
        {
            // Base case - empty array
            if (left > right)
            {
                return int.MinValue;
            }

            int mid = (int) Math.Floor(Decimal.Divide(left + right, 2));
            int curr = 0;
            int bestLeftSum = 0;
            int bestRightSum = 0;

            // Iterate from the middle to the beginning.
            for (int i = mid - 1; i >= left; i--)
            {
                curr += numsArray[i];
                bestLeftSum = Math.Max(bestLeftSum, curr);
            }

            // Reset curr and iterate from the middle to the end
            curr = 0;
            for (int i = mid + 1; i <= right; i++)
            {
                curr += numsArray[i];
                bestRightSum = Math.Max(bestRightSum, curr);
            }

            // The bestCombinedSum uses the middle element and the best
            // possible sum from each half.
            int bestCombinedSum = numsArray[mid] + bestLeftSum + bestRightSum;

            // Find the best subarray possible from both halves.
            int leftHalf = findBestSubarray(left, mid - 1);
            int rightHalf = findBestSubarray(mid + 1, right);

            // The largest of the 3 is the answer for any given input array.
            return Math.Max(bestCombinedSum, Math.Max(leftHalf, rightHalf));
        }
    }
}
