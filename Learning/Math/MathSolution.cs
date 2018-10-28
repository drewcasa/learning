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

    }
}
