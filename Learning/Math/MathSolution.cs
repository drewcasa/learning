using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.Math
{
    public class MathSolution
    {
        public IList<string> FizzBuzz(int n)
        {
            var output = new string[n];

            // set all fizz
            for (int i = 2; i < n; i += 3)
                output[i] = "Fizz";
            // set all buzz + fizzBuzz
            for (int i = 4; i < n; i += 15)
            {
                output[i] = "Buzz";
                if (i % 3 == 0) output[i] = "FizzBuzz";
                if (i + 5 < n)
                {
                    output[i + 5] = "Buzz";
                    if (i + 10 < n) output[i + 10] = "FizzBuzz";
                }
            }
            // set all remaining
            for (int i = 0; i < n; i++)
                if (output[i] == null)
                    output[i] = (i + 1).ToString();
            return output;
        }

        public IList<string> FizzBuzzSimple(int n)
        {
            var output = new string[n];

            // set all fizz
            for (int i = 1; i <= n; i++)
            {
                bool fizz = (i % 3) == 0;
                bool buzz = (i % 5) == 0;

                if (fizz)
                    output[i - 1] = buzz ? "FizzBuzz" : "Fizz";
                else if (buzz)
                    output[i - 1] = "Buzz";
                else
                    output[i - 1] = i.ToString();
            }

            return output;
        }

        public int CountPrimes(int n)
        {
            // use array to track which nums are prime
            if (n < 12) return ShortCircuit(n);
            bool[] notPrime = new bool[n + 5];
            int count = 5;

            // we'll skip all multiples of 2s and 3s, but have to still mark 5s, 7s, 11s
            for (int j = 3; j * 5 < n; j++) notPrime[j * 5] = true;
            for (int j = 3; j * 7 < n; j++) notPrime[j * 7] = true;
            for (int j = 3; j * 11 < n; j++) notPrime[j * 11] = true;

            // visit each int, marking each multiple as not prime
            for (int i = 13, i2 = 17; i < n; i += 6, i2 += 6)
            {
                if (!notPrime[i]) count++;  
                if (!notPrime[i2] && i2 < n) count++;

                // start at 5 b/c 2,3,4 already ignored by loop
                for (int j = 5; j * i < n; j += 2) notPrime[j * i] = true;
                for (int j = 5; j * i2 < n; j += 2) notPrime[j * i2] = true;
            }

            return count;
        }

        private int ShortCircuit(int n)
        {
            // 2, 3, 5, 7, 11 are primes
            if (n <= 2)
                return 0;
            else if (n <= 3)
                return 1;
            else if (n <= 5)
                return 2;
            else if (n <= 7)
                return 3;
            else if (n <= 11)
                return 4;

            throw new InvalidOperationException();
        }

        public int CountPrimesLessMem(int n)
        {
            if (n < 12) return ShortCircuit(n);
            var primes = new List<int> { 2, 3, 5, 7, 11 };

            // consider blocks of 6, starting at 12.
            // only spot 1 and 5 are possibly prime. 0,2,4 are even, 0,3 are multiples of 3
            for (int i = 13; i < n; i += 6)
            {
                IsPrime(i, primes);
                IsPrime(i + 4, primes); // doing inline keeps primes ordered
            }

            // remove last check if it exceeds n
            if (primes[primes.Count - 1] >= n) return primes.Count - 1;

            return primes.Count;
        }

        private void IsPrime(int n, List<int> primes)
        {
            // prime is divisible by itself and 1
            // to optimize, only consider odd #s

            // only check existing primes as divisors, anything non-prime has a smaller multiple that was already checked
            int sqrt = (int)System.Math.Sqrt(n);
            for (int i = 2; i < primes.Count && primes[i] <= sqrt; i++)
                if (n % primes[i] == 0) return;

            primes.Add(n);
        }

        public bool IsPowerOfThree(int n)
        {
            if (n < 1) return false;
            while (n % 9 == 0)
                n /= 9;

            return n == 1 || n == 3;
        }

        /*
         * Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000
        */
        public int RomanToInt(string s)
        {
            // create map with values
            var map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            int sum = map[s[s.Length - 1]];

            for (int i = 0; i < s.Length - 1; i++)
            {
                // if next value is higher, subtract this one
                if (map[s[i]] < map[s[i + 1]])
                    sum -= map[s[i]];
                else
                    sum += map[s[i]];
            }

            return sum;
        }

        public int HammingWeight(uint n)
        {
            // return num of 1's
            int weight = 0;

            while (n > 0)
            {
                if (n % 2 == 1) weight++;
                n /= 2;
            }

            return weight;
        }

        /// <summary>
        /// Given a 32-bit signed integer, reverse digits of an integer.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            // add digits to result 
            bool isNeg = x < 0;

            // pop back into result, checking overflow
            long result = 0;
            while (x != 0)
            {
                int digit = x % 10;
                x /= 10; // shift right a digit
                result = result * 10 + digit; // shift left a digit and add next digit
                if (isNeg && result < int.MinValue) return 0;
                if (!isNeg && result > int.MaxValue) return 0;
            }

            // return 
            return (int)result;
        }

        /// <summary>
        /// Find median of two sorted arrays of differing lengths.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double FindMedian(int[] a, int[] b)
        {
            if (a.Length > b.Length)
                return FindMedianDiffLength(a, b);
            else
                return FindMedianDiffLength(b, a);
        }

        private double FindMedianDiffLength(int[] l, int[] s)
        {
            // get total and left half size
            int total = l.Length + s.Length;
            int leftCount = (total + 1) / 2; // includes median if odd

            // shorter array index (points to element not in left side)
            int si = s.Length / 2;

            // longer array index
            int li = leftCount - (si + 2);

            // diff will track how far we move the indices
            int diff = leftCount / 2;

            do
            {
                if (IsSmallerHeavy(l, s, li, si))
                {
                    // cap at si, so we check the first element (this is one-time)
                    if (diff > si && si > 0)
                    {
                        li += si;
                        si = 0;
                    }
                    else
                    {
                        li += diff;
                        si -= diff;
                    }
                }
                else if (IsLargerHeavy(l, s, li, si))
                {
                    li -= diff;
                    si += diff;
                }
                else
                {
                    break;
                }

                diff /= 2;
            } while (true);

            // now that si, li are set, determine median
            int m1 = l[li];
            int m2 = si < 0 || si >= s.Length ? l[li + 1] : s[si];
            if (total % 2 == 1)
                return System.Math.Max(m1, m2);
            else
                return 0.0;
        }

        private bool IsSmallerHeavy(int[] l, int[] s, int li, int si)
        {
            if (si < 0) return false; // s is ignored rn
            // if smaller array's current element is larger than larger array's next, it's too heavy
            return (s[si] > l[li + 1]);
        }

        private bool IsLargerHeavy(int[] l, int[] s, int li, int si)
        {
            if (si < 0) return false; // s is ignored rn

            // if smaller array has element larger than it should, return true
            if (si == -1) return false;
            return (l[li] > s[si + 1]);
        }

    }
}
