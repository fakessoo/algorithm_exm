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


#if false

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

        public static int ClimbStairs(int n)
        {
            
            // 2. Recursion with Memoization

            // Algorithm

            // In the previous approach we are redundantly(과다하게) calculating the result for every step.
            // Instead, we can store the reuslt at each step in memo array and directly returning the result from the memo array whenever that function is called again.

            // In this way we are pruning(가지치기) recursion tree with the help of memo array and reducing the size of recursion tree upto 'n'

            int[] memo = new int[n+1];
            return ClimbStairs(0, n, memo);
        }

        public static int ClimbStairs(int i, int n, int[] memo)
        {
            if (i > n)
                return 0;

            if (i == n)
                return 1;

            if (memo[i] > 0)
                return memo[i];

            memo[i] = ClimbStairs(i + 1, n, memo) + ClimbStairs(i + 2, n, memo);
            return memo[i];

            // Time complextiy : O(n). Size of recursion tree can go upto n
            // Space complexity : O(n). The depth of recursion tree can go upto n
        }

#elif true

        public static int ClimbStairs(int n)
        {
            // 3. Dynamic Programming

            // 동적계획법이란?
            // 큰 문제를 작은 문제로 나누어 푸는 문제를 일컫는 말입니다.
            // 동적계획법이란 말 때문에 어떤 부분에서 동적으로 프로그래밍이 이루어지는지 찾아볼 필요가 없습니다.
            // 바로 동적프로그래밍이란 말을 창조한 사람도 이것이 단지 멋있어서 부여한 이름이라고 합니다.

            // Divide and Conquer(분할정복)과 비슷한데요?
            // 네, 거의 비슷하지만 결정적인 차이점이 있습니다. 바로 '작은 문제가 중복되어 일어나는지 안 일어나는지' 입니다.
            // 분할정복은 큰 문제를 해결하기 어려워 단지 작은 문제로 나누어 푸는 방법입니다.
            // 특징은 작은 문제에서 반복이 일어나는 부분이 없다는 점입니다.
            // 동적프로그래밍은 어떨까요?
            // 네, '(답이 바뀌지 않는) 작은 부분문제들이 반복되는 것'을 이용해 풀어나가는 방법입니다.

            // 동적계획법 조건
            //      - 작은 문제가 반복적으로 일어나는 경우
            //      - 그 문제들의 정답이 같은 경우

            // 메모이제이션(Memoization)
            // 반복되는 문제의 결과값이 같기 때문에 한 번 계산한 값을 저장해두고 다시 사용하는 방법으로
            // 이 과정은 메모리라는 공간적 비용을 투입해 시간적 비용을 줄이는 방식입니다.

            // 동적계획법의 유형

            //      - Top-Down
            //          1. 문제를 작은문제로 나눈다.
            //          2. 작은 문제들을 푼다.
            //          3. 작은 문제들의 답으로 전체를 푼다.

            //      - Bottom-Up
            //          1. 가장 작은 문제부터 푼다.
            //          2. 문제의 크기를 점점 크게 만들어서 전체문제를 푼다.

            // Algorithm

            // As we can see this problem can be broken into subproblems, and it contains the optimal substructure property
            // i.e. its optimal solution can be constructed efficiently from optimal solutions of its subproblems,
            // we can use dynamic programming to solve this problem.

            // One can reach i^th step in one of the two ways :
            //      1. Taking a single step from (i-1)^th step.
            //      2. Taking a step of 2 from (i-2)^th step.

            // So, the total number of ways to reach
            // i^th is equal to sum of ways of reaching (i-1)^th step and ways of reaching (i-2)^th step.

            // Let dp[i] denotes(나타내다) the number of ways to reach on i^th step : 
            //  dp[i] = dp[i-1] + dp[i-2]

            if (n == 1)
                return 1;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i ++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];

            // Time complexity : O(n). Single loop upto n.
            //      내 생각 : 이것도 기존의 계산된 값을 배열에 넣고 호출하는 방식이기 때문에 O(n) 복잡도를 가지게 된다.
            // Space complexity : O(n). dp array of size n is used.

        }

#elif true

        public static int ClimbStairs(int n)
        {

            // 4. Fibonacci Number

            // Algorithm

            // in the above approach we have used dp array where dp[i] = dp[i - 1] + dp[i - 2].
            // it can be easily analysed that dp[i] is nothing but i^th fibonacci number.

            //      'Fib(n) = Fib(n - 1) + Fib(n - 2)

            // Now we just have to find n^th number of the fibonacci series
            // having 1 and 2 their first and second term respectively,
            // i.e. Fib(1) = 1 and Fib(2) = 2

            if (n == 1)
                return 1;

            int first = 1;
            int second = 2;

            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }
            return second;

            // Time complexity : O(n). Single loop upto n is required calculate n^th fibonacci number.
            // Space complexity : O(1). Constant space is used.

        }

#elif false

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


        // 풀이

        // 계단이 1개나 2개일 경우, 간단하게 f(n) = n 이라는 솔루션이 나옵니다.

        // f(1) : 1가지
        // 1계단

        // f(2) : 2가지
        // 1 + 1
        // 2

        // 계단이 3개일 경우, 처음 시작할 때 1계단 또는 2계단을 오르도록 할 수 있습니다.
        // 처음에 1계단을 올랐다면, 나머지 2개의 계단을 오르기 위해 2가지 방법이 있을 것이고,
        // 처음에 2계단을 올랐다면, 남은 1개의 계단을 오르기 위해 1가지 방법이 있을 것입니다.

        // 다시 말해, 3개의 계단을 오르는 것은 처음에 1계단을 오른 후 나머지 2계단을 오르는 경우의 수와, 
        // 처음에 2계단을 오른 후 나머지 1계단을 오르는 경우의 수를 합한 것과 같습니다.

        // f(3) : 3가지
        // 1 + 1 + 1
        // 1 + 2
        // 2 + 1

        // 따라서, 다음 식이 성립됩니다 : 
        // f(3) = f(3-1) + f(3-2) 
        //      = f(2) + f(1) 
        //      = 2 + 1 = 3 

        // 총 3가지 방법이 나옵니다.

        // 다음으로, 계단이 4개일 경우는 어떨까요?
        // f(4) : 5가지
        // 1 + 1 + 1 + 1
        // 1 + 1 + 2
        // 1 + 2 + 1
        // 2 + 1 + 1
        // 2 + 2

        // 마찬가지로, 처음에 1개를 오른 후 나머지 3개를 오르는 경우의 수와, 
        // 처음에 2개를 오른 후 나머지 2개를 오르는 경우의 수를 합하면 됩니다.

        // 즉, f(4) = f(4-1) + f(4-2)
        //          = f(3) + f(2)
        //          = f(3-1) + f(3-2) + f(2)
        //          = f(2) + f(1) + f(2)
        //          = 3 + 2 = 5
        // 총 5가지 방법이 나옵니다.

        // 이 규칙에 대한 식을 세우면 다음과 같습니다.

        // f(n) = n, {n = 1, 2}
        //      = f(n - 1) + f(n - 2), {n >= 3}

        // 규칙을 찾았으니 그 규칙대로 재귀 함수를 만들면 되겠다고 생각해서 다음과 같이 코드를 짜봤습니다.

        public static int ClimbStairs(int n)
        {
            return doClimbStairs(n);
        }

        public static int doClimbStairs(int n)
        {
            // Edge case
            if (n == 1 || n == 2)
                return n;

            // f(n) = f(n-1) + f(n-2)
            return doClimbStairs(n - 1) + doClimbStairs(n - 2);
        }

        // 괜찮아 보였습니다. '겹치는 계산이 엄청나게 많다는 것을 알기 전 까지는요.'

        // 코딩을 마치고 테스트 케이스에 1,2 같은 edge case는 물론이고,
        // 5, 7, 10등 그보다 큰 몇가지 숫자를 넣어도 테스트를 잘 통과했습니다.

        // 그런데 문제는, 조금 더 큰 case를 테스트 해보려고 100을 넣었더니
        // Time exceeding 오류가 나는 것이었습니다.

        // 문제를 파악하기 위해 f(n)을 계산하기 위해 필요한 함수 결과인
        // f(n-1)과 f(n-2)를 f(n)의 자식으로 하여 트리의 형태로 그려보았습니다.
        // Naive(순진한)하게 코드를 작성했을 때는 몰랐던 문제점들이 나타났습니다.

        // f(6)
        // f(4)                           | f(5)
        // f(2)         - f(3)            | f(3)          - f(4)
        //              | f(1) - f(2)     | f(1) - f(2)   | f(2) - f(3)
        //                                                       | f(1) - f(2) 

        // 잘 보면, f(1)은 총 3번, f(2)는 총 5번, f(3)는 총 3번, f(4)는 총 2번 불렸습니다.
        // 그러니까, 한 번만 계산해도 될 것을 몇 번이고 계속 같은 계산을 했던 것입니다.
        // f(6)의 경우라서 망정이지, f(20)에선 얼마나 끔찍한 일이 일어났을까요?

        // 이게 얼마나 큰 실수인지, 대략적인 시간 복잡도를 구해봅시다.
        // 이진 트리이기 때문에, 각 부모 노드가 2개의 자식 노드를 만드므로,
        // 시간 복잡도는 O(2ⁿ)이 됩니다. 쉽게 말하자면, n이 주어졌을때
        // doClimbStiars(int n)의 함수가 2ⁿ번 호출된다는 뜻입니다.

        // O(2ⁿ)은 알고리즘적으로 봤을때 최악에 가까운 시간복잡도입니다.

        // n = 10을 기점으로 2ⁿ, n 사이의 간격이 급격히 벌어지고,
        // n = 100 이상되면 어떻게 될지는 그림에서 보듯 뻔합니다.
        // n²도 성능이 좋지않은 축에 속하지만 (로직에 따라 어쩔 수 없는 상황은 있겠지만)
        // 그보다 훨씬 시간복잡도가 높은 2ⁿ은 얼마나 느릴지 상상도 할 수 없습니다.

        // 이런 경우, 시간 측면에서 문제가 있을 뿐만 아니라,
        // Call stack에 함수 call이 계속 쌓이게 되어, Stack overflow 문제가 발생할 가능성이 매우 큽니다.

#elif false

        // 해결

        // 해결법은 한 번 계산한 것을 다시 계산하지 않도록 계산 결과를 저장하는 것입니다.
        // 흔히 이걸 메모해놓고 나중에 사용하는 것과 비슷하다고 해서 Memoization 기법이라고 부릅니다.

        // f(6)를 그렸던 그림을 다시 참고해 봅시다. 여기서 우리는 f(1), f(2), ... f(6)의 계산 결과를 한 번만 수행하고,
        // 수행 결과를 길이 6짜리의 배열에 저장하여 나중에 필요할 때 꺼내주면 됩니다.

        // Memoization을 이용해 개선한 알고리즘의 솔루션입니다.

        public static int ClimbStairs(int n)
        {
            return 0;
        }

        public static int doClimbStairs(int n, int[] memo)
        {
            if (memo[n] > 0)
                return memo[n];

            // memo[n] = f(n-2) + f(n-1)
            memo[n] = doClimbStairs(n - 2, memo) + doClimbStairs(n - 1, memo);
            return memo[n];
        }

#endif

    }
}
