using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.MathQuestions
{

    [TestClass]
    public class Tests
    {
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

    }

}
