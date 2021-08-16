using System;

namespace _1822_Sign_of_the_Product_of_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, -2, -3, -4, 3, 2, 1 };
            Console.WriteLine(ArraySign(nums));
        }

        public static int ArraySign(int[] nums)
        {
            // 미치겠네 문제 이해가 안돼
            // Product가 곱하기란 의미가 있네
            // 이해가 안가는거 
            // signFunc() 값을 리턴한다고 굳이 설명한 이유?? - 요 부분은 여전히 이해가 안됨
            // x가 양수면 1 음수면 -1 0이면 0인 케이스는
            // 결국 리턴값이 무슨값이 되든 반환되는거 1,-1,0만 반환되야 되는 것을 인지해야 함
            // 문제인지능력이 아직도 부족


            // positive 양수
            // negative 음수

            // even 짝수
            // odd 홀수

            int output = 0;
            int is_odd = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    return 0;
                else if (nums[i] < 0)
                    is_odd++;
            }


            if (is_odd % 2 != 0)
                output = -1;
            else
                output = 1;

            return output;
        }
    }
}
