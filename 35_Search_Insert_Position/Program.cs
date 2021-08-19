using System;

namespace _35_Search_Insert_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 4, 6, 7, 8, 9 };
            int target = 6;
            Console.WriteLine(SearchInsert(nums, target));
        }

#if false

        // 최초 코드
        // 로직적으로는 이상이 없으나 여러차례 돌리는 과정에서
        // 메모리에 남아있게 되는 변수가 다음 테스트에 영향을 준다.

        public static int nums_first_cnt = 0;
        public static int nums_last_cnt = 0;

        public static int SearchInsert(int[] nums, int target)
        {
            // 정렬된 배열과 무반복값, 타겟값 찾으면 리턴인덱스 아니면 있어야 할 위치를 반환
            // O(log n)을 사용하라는 얘기는 이진검색이나 리컬시브 종류의 코드를 작성하란 얘기

            if (nums_last_cnt == 0 && nums.Length > 0)
                nums_last_cnt = nums.Length;

            if (nums[nums.Length - 1] < target)
                return nums.Length;

            // return index가 되어야 해
            int mid_cnt = (int)Math.Truncate((decimal)((nums_last_cnt - nums_first_cnt) / 2) + nums_first_cnt);
            // int mid_cnt = (int)(((nums_last_cnt - nums_first_cnt) / 2) + nums_first_cnt);

            if (nums[mid_cnt] == target || nums[mid_cnt] == target - 1 || nums[mid_cnt] == target + 1)
                return mid_cnt;
            else if (nums[mid_cnt] > target)
            {
                nums_last_cnt = mid_cnt;
                return SearchInsert(nums, target);
            }
            else if (nums[mid_cnt] < target)
            {
                nums_first_cnt = mid_cnt;
                return SearchInsert(nums, target);
            }

            return 0;

            // 지금 이 코드는 실제로 테스트시에 output이 1로 제대로 나오는데 Submit에선 0으로 빠진다 왜지?? 버그인듯
            // 테스트를 여러번 돌리는 과정에서 메모리에 올라와있는 nums_last_cnt가 뒷쪽 테스트에 영향을 준다.
        }

#elif false

        // 올림 Math.Ceiling
        // 내림 Math.Truncate
        // 반올림 Math.Round

        // 계속 오류가 나서 포기
        public static int SearchInsert (int[] nums, int target)
        {
            int last_cnt = nums.Length;
            return BinarySearch(nums, 0, last_cnt, target);
        }

        public static int BinarySearch(int[] nums, int first_cnt, int last_cnt, int target)
        {
            if (nums[nums.Length - 1] < target)
                return nums.Length;

            if (last_cnt <= first_cnt)
            {
                return first_cnt;
            }

            int mid_cnt = (int)Math.Truncate((decimal)((last_cnt - first_cnt) / 2) + first_cnt);

            if (nums[mid_cnt] == target)
                return mid_cnt;
            else if (nums[mid_cnt] > target)
                return BinarySearch(nums, first_cnt, mid_cnt, target);
            else if (nums[mid_cnt] < target)
                return BinarySearch(nums, mid_cnt, last_cnt, target);
            else
                return 0;
        }

        // 나의 접근 방식은 미들값을 계속 잘라내서 리컬시브로 돌려가며 찾으려 했으나
        // 타겟값이 없는 배열의 경우는 미들값이 들어맞지 않는 경우가 있어서 찾는데 어려움이 발생한다.
        // 양쪽 인덱스에서 읽어 들어오는 방식으로 끝을 잡아주는게 더 좋은 알고리즘이란 판단을 함

#elif true

        // Algorithm
        // Initialize the 'left' and 'right' pointer: left = 0, right = n - 1

        // While left <= right:

        //      Compare middle element of the array nums[pivot] to the target value 'target'

        //          - If the middle element is the target
        //              ex> target == nums[pivot] : return pivot.

        //          - If the target is not here:
        //              If 'target < nums[pivot]', continue to search on the left subarray. right = pivot - 1.
        //              Else continue to search on the right subarray. left = pivot + 1.

        //      Return left.

        public static int SearchInsert(int[] nums, int target)
        {
            int pivot = 0;
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (nums[pivot] == target)
                    return pivot;

                if (target < nums[pivot])
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return left;
        }

        // 이런 식의 코드도 타임 컴플렉스가 O(log N) 인가봄

#endif

    }
}
