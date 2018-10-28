using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Math
{

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestBaseConversion()
        {
            Assert.AreEqual("21", BaseConversion.ConvertToBase(7, 3));
            Assert.AreEqual("111", BaseConversion.ConvertToBase(7, 2));
            Assert.AreEqual("1000", BaseConversion.ConvertToBase(8, 2));
            Assert.AreEqual("123456", BaseConversion.ConvertToBase(123456, 10));
            Assert.AreEqual("10224262", BaseConversion.ConvertToBase(863473, 7));

            Assert.AreEqual("2f", BaseConversion.ConvertToBase(47, 16));

            Assert.AreEqual(47, BaseConversion.ConvertFromBase("2f", 16));
            Assert.AreEqual(123456, BaseConversion.ConvertFromBase("123456", 10));

            int random = 12351616;
            for (int b = 2; b < 20; b++)
            {
                Assert.AreEqual(random, BaseConversion.ConvertFromBase(BaseConversion.ConvertToBase(random, b), b));
            }
        }

        [TestMethod]
        public void TestFizzBuzz()
        {
            var fb = new MathSolution();
            var result = fb.FizzBuzz(1);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1", result[0]);
        }

        [TestMethod]
        public void TestFizzBuzzCompare()
        {
            var fb = new MathSolution();
            for (int i = 1; i < 100000000; i*=2)
            {
                var now = DateTime.Now;
                fb.FizzBuzz(i);
                var ms = DateTime.Now.Subtract(now).TotalMilliseconds;
                now = DateTime.Now;
                fb.FizzBuzzSimple(i);
                var ms2 = DateTime.Now.Subtract(now).TotalMilliseconds;
                Console.WriteLine("{0} FizzBuzz: {1}, Simple: {2}", i, ms, ms2);
            }
        }

        [TestMethod]
        public void GetPrimeCount()
        {
            var prime = new MathSolution();
            Assert.AreEqual(8, prime.CountPrimes(20));
            Assert.AreEqual(168, prime.CountPrimes(1000));
            Assert.AreEqual(1229, prime.CountPrimes(10000));
            Assert.AreEqual(41537, prime.CountPrimes(499979));
            Assert.AreEqual(1, prime.CountPrimes(3));
            Assert.AreEqual(0, prime.CountPrimes(2));
            Assert.AreEqual(4, prime.CountPrimes(10));
            Assert.AreEqual(2, prime.CountPrimes(5));
            Assert.AreEqual(5, prime.CountPrimes(13));
        }

        [TestMethod]
        public void Pow3Tests()
        {
            var pow3 = new MathSolution();
            Assert.IsFalse(pow3.IsPowerOfThree(2147483647));
            Assert.IsTrue(pow3.IsPowerOfThree(27));
            Assert.IsTrue(pow3.IsPowerOfThree(9*27*81*81*9));
        }

        [TestMethod]
        public void RomanTests()
        {
            var roman = new MathSolution();
            Assert.AreEqual(3, roman.RomanToInt("III"));
            Assert.AreEqual(4, roman.RomanToInt("IV"));
            Assert.AreEqual(58, roman.RomanToInt("LVIII"));
            Assert.AreEqual(1994, roman.RomanToInt("MCMXCIV"));
        }


        [TestMethod]
        public void Count1s()
        {
            var ones = new MathSolution();
            Assert.AreEqual(1, ones.HammingWeight(128));
            Assert.AreEqual(7, ones.HammingWeight(127));
            Assert.AreEqual(0, ones.HammingWeight(0));
            Assert.AreEqual(1, ones.HammingWeight(8));
            Assert.AreEqual(2, ones.HammingWeight(9));
        }

    }

}
