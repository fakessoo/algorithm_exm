using System;

namespace _66_Plus_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[] { 9, 9 };
            int[] result = PlusOne(digits);
            foreach (int obj in result)
            {
                Console.WriteLine(obj);
            }
        }

        public static int[] PlusOne(int[] digits)
        {

#if false
            // 최초 코드

            // 123 배열의 마지막 수에 +1을 한다
            // 만약 배열의 마지막 수가 9이면 0으로 변하고 
            // 배열의 마지막 -1의 수에 +1을 한다.

            // 덧셈을 로직화 하란 뜻
            int pivot = digits.Length - 1;
            int left_val = 0;
            int[] digits_plus_one = new int[digits.Length + 1];

            while (pivot >= 0)
            {
                if (digits[pivot] + 1 == 10)
                {
                    left_val = 1;
                    digits[pivot] = 0;
                    digits_plus_one[pivot + 1] = 0;
                }
                else
                {
                    left_val = 0;
                    digits[pivot] = (digits[pivot] + 1) % 10;
                    break;
                }

                if (pivot == 0 && left_val == 1)
                {
                    digits_plus_one[pivot] = 1;
                    return digits_plus_one;
                }
                pivot--;
            }

            return digits;

#elif false

            // 내 코드 최적화

            int pivot = digits.Length - 1;
            int[] digits_plus_one = new int[digits.Length + 1]; 
            // 요것으로 인해서 불필요한 메모리를 잡고있는 상황이 됨

            while (pivot >= 0)
            {
                if (digits[pivot] < 9)
                {
                    digits[pivot] = digits[pivot] + 1;
                    break;
                }
                else
                {
                    digits[pivot] = 0;
                    digits_plus_one[pivot + 1] = 0;

                    if (pivot == 0)
                    {
                        digits_plus_one[pivot] = 1;
                        return digits_plus_one;
                    }
                }
                pivot--;
            }

            return digits;

#elif true

            // Algorithm

            // Move along the input array starting from the end of array
            // Set all the nines at the end of array to zero
            // If we meet a not-nine digit, we would increase it by one. The job is done - return digits.
            // We're here because all the digits were equal to nine. Now they have all been set to zero.
            // We then append the digit 1 in front of the other digits and return the result.

            int n = digits.Length;

            // move along the input array starting from the end.
            for (int idx = n - 1; idx >= 0; --idx)
            {
                // set all the nines at the end of array to zeros
                if (digits[idx] == 9)
                {
                    digits[idx] = 0;
                }
                // here we have the rightmost not-nine
                else
                {
                    digits[idx]++;
                    return digits;
                }
            }

            // we're here because all the digits are nines
            digits = new int[n + 1];
            digits[0] = 1;
            return digits;

            // int의 기본은 0이기 때문에 생성때 부터 0이 들어가있게 되고 첫자만 1로 변경하면 원하는 array를 가질 수 있음

            // Let N be the number of elements in the input list.

            //      - Time complexity : O(N) since it's not more than one pass along the input list.
            //      - Space complexity : O(N)
            //              - Although we perform the operation in-place(i.e. on the input list itself), in the worst senario,
            //              we would need to allocate an intermediate space to hold the result, which contains the N+1 elements,
            //              Hence the overall space complexity of the algorithm is O(N)

#endif
        }
    }
}
