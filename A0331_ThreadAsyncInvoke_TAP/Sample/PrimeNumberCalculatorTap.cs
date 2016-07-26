using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0331_ThreadAsyncInvoke_TAP.Sample
{


    /// <summary>
    /// 质数计算器类.
    /// </summary>
    class PrimeNumberCalculatorTap
    {

        /// <summary>
        /// 实现 IsPrime。 
        /// 它采用三个参数：已知质数列表、要测试的数和找到的第一个约数的输出参数。 
        /// 根据质数列表，它确定测试数是不是质数。
        /// </summary>
        /// <param name="primes">已知质数列表</param>
        /// <param name="n">要测试的数</param>
        /// <param name="firstDivisor">第一个约数</param>
        /// <returns>测试数是不是质数</returns>
        private Task<bool> IsPrime(
            List<int> primes,
            int n)
        {

            return Task.Run(() =>
            {
                bool foundDivisor = false;
                bool exceedsSquareRoot = false;

                int i = 0;
                int divisor = 0;



                // Stop the search if:
                // there are no more primes in the list,
                // there is a divisor of n in the list, or
                // there is a prime that is larger than 
                // the square root of n.
                while (
                    (i < primes.Count) &&
                    !foundDivisor &&
                    !exceedsSquareRoot)
                {
                    // The divisor variable will be the smallest 
                    // prime number not yet tried.
                    divisor = (int)primes[i++];

                    // Determine whether the divisor is greater
                    // than the square root of n.
                    if (divisor * divisor > n)
                    {
                        exceedsSquareRoot = true;
                    }
                    // Determine whether the divisor is a factor of n.
                    else if (n % divisor == 0)
                    {
                        foundDivisor = true;
                    }
                }

                return !foundDivisor;
            });
        }




        /// <summary>
        /// 返回 质数的列表.
        /// </summary>
        /// <param name="numberToTest"></param>
        /// <returns></returns>
        private async Task<List<int>> BuildPrimeNumberList(int numberToTest)
        {

            List<int> primes = new List<int>();
            int n = 5;

            // Add the first prime numbers.
            primes.Add(2);
            primes.Add(3);


            // Do the work.
            // 每次循环，都调用 TaskCanceled 方法，当该方法返回 true 时它就会退出。
            while (n < numberToTest)
            {

                if (await IsPrime(primes, n))
                {
                    primes.Add(n);
                }

                // Skip even numbers.
                // 这里排除掉偶数.
                n += 2;
            }

            return primes;
        }



        public async void Calculate(int numberToTest)
        {

            List<int> primes = await BuildPrimeNumberList(
                        numberToTest);

            Console.WriteLine("{0}以内，质数的数量：{1}", numberToTest, primes.Count);

        }


    }


}
