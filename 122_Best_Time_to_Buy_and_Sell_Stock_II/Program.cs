using System;

namespace _122_Best_Time_to_Buy_and_Sell_Stock_II
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            // int[] prices = new int[] { 1, 7, 2, 3, 6, 7, 6, 7 };
            Console.Write(MaxProfit(prices));
        }

        public static int MaxProfit(int[] prices)
        {

            //  내 코드
            //  이번 케이스에서 브루트 포스도 제대로 짜지 못했다.
            //  아직도 알고리즘에 이해가 부족하다는 반증

            // brute force

            //int profit = 0;
            //for (int i = 0; i < prices.Length; i++)
            //{
            //    int target = prices[i];
            //    for (int j = i + 1; j < prices.Length; j++)
            //    {
            //        int compare = prices[j];
            //        if (profit > (compare - target))
            //        {
            //            profit = (compare - target);
            //        }
            //    }
            //}
#if true

            return calculate(prices, 0);

#elif false

            // 와 이건 미친 알고리즘

            // 2. Peak Valley(계곡, 골짜기, 움푹 패인 곳, 최저점) Approach

            //  Algorithm

            //  Say the given array is:
            //  [7, 1, 5, 3, 6, 4]
            //  If we plot the numbers of the given array on a graph, we get:

            //  - Peak & Valley Points Feacher.

            //  If we analyze the graph, we notice that the points of interest are the consecutive valleys and peaks.

            //  Mathmatically sepaking : TotalProfit = sigma_i(height(peak_i) - (height(valley_j))

            //  The key point is we need to consider every peak immediately following a valley to maximize the profit, In case we skip one of the peaks
            //  (trying to obtain more profit), we will end up losing the profit over one of the tansactions leading to an overall lesser profit.

            //  For example, in the above case, if we skip 'peak_i' and 'valley_j' trying to obtain more profit by considering points with more difference in heights,
            //  the net profit obtained will always be lesser than the one obtained by including them, since 'C' will always be lsser than 'A + B'.

            //  C : Minimum Valley + Maximum Peak
            //  A + B : Multiple Heights between valleys and peaks

            int i = 0;
            int valley = prices[0];
            int peak = prices[0];
            int maxprofit = 0;

            while (i < prices.Length -1)
            {
                while (i < prices.Length - 1 && prices[i] >= prices[i+1])
                {
                    i++;
                }
                valley = prices[i];
                while (i < prices.Length - 1 && prices[i] <= prices[i+1])
                {
                    i++;
                }
                peak = prices[i];
                maxprofit += peak - valley;
            }

            return maxprofit;

            // Time complexity : O(n), Single pass.
            // Space complexity : O(1). Constant space required.

#elif false
            
            //  이건 진짜 더 미친 케이스
            //  위의 생각도 대단한데 거기에 더 심플하게 만들어버림

            // 3. Simple One Pass

            //  Algorithm

            //  This solution forllows the logic used in Approach 2 itself, but with only a slight variation(변화, 차이).
            //  In this case, instead of looking for every peak following a valley, 
            //  we can simply go on crawling over the slope(경사지) and keep on adding the profit obtained from every consecutive transaction.
            //  in the end, we will using the peaks and valleys effectively, 
            //  but we need not track the costs corresponding(상응하는, 비슷한) to the peaks and valley along(..에 따라, 함께) with the maximun profit,
            //  but we can directly keep on adding the difference between the consecutive numbers of the array if the second number is larger than the first one,
            //  and at the total sum we obtain will be the maximum profit.
            //  This approach will simplify the solution.
            //  This can be made clearer by taking this example.
            
            //  [1, 7, 2, 3, 6, 7, 6, 7]

            //  The graph corresponding to this array is:

            //  부분별로 profit을 증가하는 경사각만큼 적용한 값을 구한 계산의 합이 최종 Profit과 일치함을 보여주는 그래프

            //  From the above graph, we can observe taht the sum 'A + B + C' is equal 
            //  to the difference D corresponding to the difference between the heights of the consecutive peak and valley.

            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;

            //  Time complexity : O(n). Single pass.
            //  Space complexity : O(1). Constant space needed.
#endif 


        }

        public static int calculate(int[] prices, int s)
        {

            // 1. Brute Force

            // In this case, we simply calculate the profit conrresponding to all the possible sets of transactions 
            // and find out the maximum profit out of them.

            if (s >= prices.Length)
                return 0;

            int max = 0;
            for (int start = s; start < prices.Length; start++)
            {
                int maxProfit = 0;
                for (int i = start + 1; i < prices.Length; i++)
                {
                    if (prices[start] < prices[i])
                    {
                        int profit = calculate(prices, i + 1) + (prices[i] - prices[start]);
                        if (profit > maxProfit)
                            maxProfit = profit;
                    }
                }

                if (maxProfit > max)
                {
                    max = maxProfit;
                }
            }

            return max;

            //  Time complexity : O(nⁿ) Recursive function is called nⁿ times
            //  Space complexity : O(n) Depth of recursion is n

        }
    }
}
