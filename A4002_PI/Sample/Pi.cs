using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A4002_PI.Sample
{
    class Pi
    {

        //需要的位数
        public static readonly int DIGITS = 100000;
        public static readonly int LEN = 10;
        public static readonly long BASE = (long)Math.Pow(10, LEN);

        void Format(long[] pi)
        {
            long quotient = 0;
            for (int i = 0; i < pi.Length; i++)
            {
                long numerator = pi[i] + quotient;
                quotient = numerator / BASE;
                long remainder = numerator % BASE;
                if (remainder < 0)
                {
                    remainder += BASE;
                    quotient--;
                }
                pi[i] = remainder;
            }
        }

        int Divide(bool updateSum, bool positive, bool updateDividend,
          int digits, long[] sum, long[] dividend, long divisor)
        {
            long remainder = 0;
            for (int i = digits; i >= 0; i--)
            {
                long quotient = BASE * remainder + dividend[i];
                remainder = quotient % divisor;
                quotient /= divisor;
                if (updateDividend) dividend[i] = quotient;
                if (!updateSum) continue;
                if (positive) sum[i] += quotient;
                else sum[i] -= quotient;
            }
            if (updateDividend) while (digits > 0 && dividend[digits] == 0) digits--;
            return digits;
        }

        public long[] Compute(int digits)
        {
            int[] t0 = { 176, 57, 28, 239, -48, 682, 96, 12943 };
            long[] pi = new long[++digits + 1];
            long[] tmp = new long[digits + 1];
            for (long i = 0; i < t0.Length; i += 2)
            {
                Array.Clear(tmp, 0, tmp.Length);
                tmp[digits] = t0[i];
                int divisor = t0[i + 1];
                int digits2 = Divide(true, true, true, digits, pi, tmp, divisor);
                bool positive = false;
                divisor *= divisor;
                for (long step = 3; digits2 > 0; positive = !positive, step += 2)
                {
                    digits2 = Divide(false, true, true, digits2, null, tmp, divisor);
                    digits2 = Divide(true, positive, false, digits2, pi, tmp, step);
                }
            }
            Format(pi);
            return pi;
        }


    }
}
