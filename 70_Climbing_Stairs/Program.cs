using System;

namespace _70_Climbing_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine(ClimbStairs(n));
        }


#if true

        public static int ClimbStairs(int n)
        {
            // Algorithm

            // In this brute force approach we take all possible step combinations i.e. 1 and 2 at every step.
            // Ay every step we are calling the function 'climbStairs' for step 1 and 2, 
            // and return the sum of returned values of both functions.

            // climbStairs(i, n) = climbStairs(i + 1, n) + climbStairs(i + 2, n)

            // where 'i' defines the current step and 'n' defines the destination step.

            return ClimbStairs(0, n);
        }

        public static int ClimbStairs(int i, int n)
        {
            if (i > n)
                return 0;

            if (i == n)
                return 1;

            return ClimbStairs(i+1, n) + ClimbStairs(i+2, n);
        }

#elif false


        public int ClimbStairs(int n)
        {

            // return : 몇 가지의 방법으로 오를 수 있는가

            // 알고리즘
            // 최대 오를수 있는 횟수는 2

            // input : 5 

            // 1st + 1st + 1st + 1st + 1st

            // [2st] + 1st + 1st + 1st
            // 1st + [2st] + 1st + 1st
            // 1st + 1st + [2st] + 1st
            // 1st + 1st + 1st + [2st]

            // [2st + 2st] + 1st
            // 1st + [2st + 2st]
            // [2st] + 1st + [2st]

            // 5 / 2 = 2.5 

            // return 8

            // 못 풀겠다

            return 0;
        }

#endif



    }
}
