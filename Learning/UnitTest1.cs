using Learning.QueuesAndStacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Learning
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void BruteForce_100()
        {
            int capacity = 2;

            for (int i = 0; i < 13; i++)
            {
                var map = BuildDependencies(capacity, 50);
                var start = DateTime.Now;
                var sorted = TopologicalSort.BruteForceSort(map);
                var totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;

                Console.WriteLine($"{totalMS}ms to sort {capacity} objects using BruteForce.");
                capacity *= 2;
            }
        }

        [TestMethod]
        public void DepthFirst_Tests()
        {
            int capacity = 2;

            for (int i = 0; i < 10; i++)
            {
                var map = BuildDependencies(capacity, 50);
                var start = DateTime.Now;
                var sorted = TopologicalSort.DepthFirstSort(map);
                var totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;

                Console.WriteLine($"{totalMS}ms to sort {capacity} objects using DFS.");
                capacity *= 2;
            }
        }

        [TestMethod]
        public void DepthFirst_TestsBuildGraphOnly()
        {
            int capacity = 2;

            for (int i = 0; i < 13; i++)
            {
                var map = BuildDependencies(capacity, 50);
                var start = DateTime.Now;
                var sorted = TopologicalSort.DepthFirstSort(map);
                var totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;

                Console.WriteLine($"{totalMS}ms to sort {capacity} objects using DFS.");
                capacity *= 2;
            }
        }

        [TestMethod]
        public void BuildGraph_Compare()
        {
            int capacity = 2;

            for (int i = 0; i < 13; i++)
            {
                var map = BuildDependencies(capacity, 50);
                var start = DateTime.Now;
                GraphNode.BuildGraph(map);
                var totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine($"{totalMS}ms to build graph with {capacity} objects.");

                start = DateTime.Now;
                GraphNode.BuildGraphFaster(map);
                totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine($"{totalMS}ms to build graph faster with {capacity} objects.");

                capacity *= 2;
            }
        }

        [TestMethod]
        public void KVP_Key_Compare()
        {
            int capacity = 2;
            int size = 0;

            for (int i = 0; i < 15; i++)
            {
                var map = BuildDependencies(capacity, 50);

                var start = DateTime.Now;
                foreach (var kvp in map) size += kvp.Value.Count;
                var totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine($"{totalMS}ms to iterate kvp with {capacity} objects.");

                start = DateTime.Now;
                foreach (var key in map.Keys) size += map[key].Count;
                totalMS = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine($"{totalMS}ms to iterate with key only {capacity} objects.");

                capacity *= 2;
            }
        }

        [TestMethod]
        public void CountIslands()
        {
            var grid = GetGrid(new string[]
            {
                "10001",
                "00111",
                "00000",
            });
            var islands = new Solution();

            Assert.AreEqual(2, islands.NumIslands(grid));
        }

        [TestMethod]
        public void CountIslands_WithPeninsula()
        {
            var grid = GetGrid(new string[]
            {
                "10101",
                "00111",
                "11100",
            });
            var islands = new Solution();

            Assert.AreEqual(2, islands.NumIslands(grid));
        }

        [TestMethod]
        public void CountIslands_WithOutline()
        {
            var grid = GetGrid(new string[]
            {
                "11111",
                "10001",
                "11111",
            });
            var islands = new Solution();

            Assert.AreEqual(1, islands.NumIslands(grid));
        }

        [TestMethod]
        public void CountIslands_OneRow()
        {
            var grid = GetGrid(new string[]
            {
                "10101011110000011000000111111",
            });
            var islands = new Solution();

            Assert.AreEqual(6, islands.NumIslands(grid));
        }

        [TestMethod]
        public void OpenLock_Simple()
        {
            var locker = new Solution();
            var moves = locker.OpenLock(new string[] { "1011" }, "2001");

            Assert.AreEqual(3, moves);
        }

        [TestMethod]
        public void OpenLock_NoSolution()
        {
            var locker = new Solution();
            var deadEnds = new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" };
            var moves = locker.OpenLock(deadEnds, "8888");

            Assert.AreEqual(-1, moves);
        }

        [TestMethod]
        public void OpenLock_OneDeadend()
        {
            var locker = new Solution();
            var deadEnds = new string[] { "0201", "0101", "0102", "1212", "2002" };
            var moves = locker.OpenLock(deadEnds, "0542");

            Assert.AreEqual(11, moves);
        }

        [TestMethod]
        public void PerfectSquareSums()
        {
            var sq = new PerfectSquares();
            var parts = sq.NumSquares(7168);

            Assert.AreEqual(4, parts);
        }

        [TestMethod]
        public void PerfectSquareSums_1()
        {
            var sq = new PerfectSquares();
            var parts = sq.NumSquares(1);

            Assert.AreEqual(1, parts);
        }

        [TestMethod]
        public void PerfectSquareSums_7()
        {
            var sq = new PerfectSquares();
            var parts = sq.NumSquares(7);

            Assert.AreEqual(4, parts);
        }

        [TestMethod]
        public void PerfectSquareSums_121()
        {
            var sq = new PerfectSquares();
            var parts = sq.NumSquares(121);

            Assert.AreEqual(1, parts);
        }

        [TestMethod]
        public void PerfectSquareSums_12()
        {
            var sq = new PerfectSquares();
            var parts = sq.NumSquares(12);

            Assert.AreEqual(3, parts);
        }

        [TestMethod]
        public void OpenLock_Complex()
        {
            var locker = new Solution();
            var deadEnds = new string[] { "4515", "4184", "9093", "6799", "6594", "8484",
            "8048", "2886", "5609", "9801", "7845", "2631", "3962", "5601", "5049", "3916",
            "7222", "5699", "3980", "0814", "2386", "8880", "4524", "5329", "6242", "9184",
            "5357", "1288", "5446", "9771", "5492", "0361", "8679", "2808", "1184", "0228",
            "6448", "9083", "5730", "3379", "9890", "5713", "2642", "0772", "0141", "8765",
            "4448", "7356", "5382", "8138", "0272", "0802", "7944", "6245", "1345", "6805",
            "6945", "3377", "6741", "0945", "0925", "1471", "1118", "3708", "8332", "6887",
            "9130", "0851", "5177", "6032", "1906", "0767", "5974", "3592", "4967", "2620",
            "7959", "3805", "4836", "8641", "9805", "6141", "1023", "5291", "6808", "8466",
            "6259", "4084", "8880", "0043", "7394", "6369", "0313", "3293", "5254", "3827",
            "1728", "5495", "5927", "3680", "5454", "1305", "3366", "8174", "2717", "1069",
            "3785", "9181", "6171", "1462", "8859", "4333", "5795", "8883", "9881", "1287",
            "6416", "5760", "4390", "6260", "9788", "6191", "1510", "2553", "0222", "7214",
            "5214", "2943", "9615", "4492", "5632", "7093", "5869", "4177", "3542", "2433",
            "3518", "0105", "5266", "8033", "3094", "5221", "2240", "5874", "3742", "8687",
            "5202", "7932", "4512", "4106", "0234", "3863", "8154", "3076", "7452", "9081",
            "1189", "9847", "6463", "5475", "2125", "8509", "8193", "7885", "0611", "5479",
            "4371", "4168", "8870", "1871", "0248", "9145", "7032", "4093", "1429", "5415",
            "5261", "4482", "7241", "7373", "6043", "3156", "1828", "0741", "4792", "7642",
            "8921", "3979", "8445", "2710", "5027", "0658", "6168", "2434", "4568", "6790",
            "5356", "5643", "8948", "2831", "2411", "0043", "4042", "2651", "6041", "8557",
            "8253", "2634", "0559", "9254", "9501", "3215", "0234", "3108", "3363", "8688",
            "1513", "7747", "3846", "3542", "6671", "9677", "4598", "7304", "8313", "1036",
            "5811", "3279", "7115", "3157", "7761", "3256", "3379", "4807", "2475", "8576",
            "3612", "6157", "1266", "8635", "9429", "9897", "8048", "2654", "3145", "5204",
            "8731", "9154", "6673", "7213", "0608", "1045", "6692", "0452", "3947", "6488", "0525",
                "5531", "0312", "7363", "5876", "2713", "0484", "2299", "3052", "4392", "0464", "2755", "7416", "5527", "1276", "2077",
            "3723", "0142", "0653", "9606", "0916", "6882", "6575", "2024", "6250", "1711", "3381",
                "7703", "1626", "6859", "1526", "0514", "6271", "3438", "2880", "9874", "5837", "6547", "4960", "0712", "9390", "6207",
            "1437", "1131", "2253", "9308", "0665", "6334", "6648", "4997", "1583", "4590", "1032",
                "4791", "8445", "2328", "8440", "1369", "2595", "8853", "0797", "1989", "3119", "5246", "5964", "7501", "2464", "7716",
            "2772",
            "8257", "6181", "7195", "5138", "2185", "8121", "1753", "5144", "1776", "3221", "3883",
                "5573", "7268", "7162", "5602", "3035", "5843", "1417", "1823", "9366", "6477", "0108", "5719", "8666", "8901", "7289",
            "2498", "2219", "4520", "2951", "7929", "5504", "0797", "7586", "5306", "2656", "7479",
                "6606", "4227", "7727", "4449", "2299", "0142", "5099", "3898", "7005", "4275", "3692", "1905", "5540", "8365", "8971",
            "9541", "7449", "6146", "2844", "1026", "7639", "2614", "0796", "5920", "4633", "9839",
                "9761", "5748", "5524", "1332", "5586", "3026", "9057", "1498", "8197", "0692", "7714", "6334", "7656", "1649", "2989",
            "4393", "6227", "5183", "6328", "9864", "5972", "2203", "7032", "3643", "2429", "0981",
                "4729", "0501", "9624", "1464", "2619", "7712", "6739", "9171", "0899", "9731", "1058", "7006", "1859", "4002", "5325",
            "1039", "0466", "2060", "4203", "8816", "8867", "1797", "9832", "6489", "4771", "9789",
                "0271", "7684", "6345", "0825", "9022", "4285", "8081", "9435", "0946", "4466", "6551", "4722", "3580", "5484", "5191",
            "4582", "0220", "1580", "0045", "8701", "3895", "1795", "0614", "3118", "4836", "2101",
                "2072", "7090", "9275", "8715", "1303", "4864", "1116", "6102", "2818", "9196", "1222", "3481", "1709", "6145", "2349",
            "3395", "5314", "3404", "4626", "3770", "7762", "8413", "7310", "9659", "0892", "9920",
                "7195", "7049", "7443", "5505", "3400", "2275", "0669", "6024" };

            var moves = locker.OpenLock(deadEnds, "4894");

            Assert.AreEqual(11, moves);
        }

        [TestMethod]
        public void MyQueueTests()
        {
            var q = new MyCircularQueue(3);

            Assert.AreEqual(true, q.EnQueue(1));
            Assert.AreEqual(true, q.EnQueue(2));
            Assert.AreEqual(true, q.EnQueue(3));
            Assert.AreEqual(false, q.EnQueue(4));

            Assert.AreEqual(3, q.Rear());
            Assert.IsTrue(q.IsFull());
            Assert.IsTrue(q.DeQueue());
            Assert.IsTrue(q.EnQueue(4));
            Assert.AreEqual(4, q.Rear());
        }

        [TestMethod]
        public void StackTest()
        {
            var stack = new MinStack();

            stack.Push(4);
            Assert.AreEqual(4, stack.GetMin());
            Assert.AreEqual(4, stack.Top());
            stack.Push(2);
            Assert.AreEqual(2, stack.GetMin());
            stack.Pop();
            Assert.AreEqual(4, stack.GetMin());
            Assert.AreEqual(4, stack.Top());
        }

        [TestMethod]
        public void BracketParserTests()
        {
            var parser = new BracketParser();

            Assert.IsTrue(parser.IsValid("()"));
            Assert.IsTrue(parser.IsValid("()[]{}"));
            Assert.IsTrue(parser.IsValid("((([])))"));
            Assert.IsTrue(parser.IsValid(""));

            Assert.IsFalse(parser.IsValid("{"));
            Assert.IsFalse(parser.IsValid("{}}"));
            Assert.IsFalse(parser.IsValid("({)}"));
        }

        [TestMethod]
        public void DailyTempsTests()
        {
            var temps = new Solution();
            var input = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            var expected = new int[] { 1, 1, 4, 2, 1, 1, 0, 0 };

            var results = temps.DailyTemperatures(input);

            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }

        [TestMethod]
        public void DailyTemps_SingleDay()
        {
            var temps = new Solution();
            var results1 = temps.DailyTemperatures(new int[] { 50 });

            Assert.AreEqual(1, results1.Length);
            Assert.AreEqual(0, results1[0]);
        }

        [TestMethod]
        public void CloneUndirectedGraphTests()
        {
            var root = new UndirectedGraphNode(1);
            var node2 = new UndirectedGraphNode(2);
            root.neighbors.Add(node2);
            node2.neighbors.Add(root);
            var node3 = new UndirectedGraphNode(3);
            root.neighbors.Add(node3);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(root);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node3);

            var clone = root.CloneGraph(root);

            Assert.IsNotNull(clone);
            Assert.AreEqual(2, clone.neighbors.Count);
        }

        [TestMethod]
        public void RPNTests()
        {
            var rpn = new Solution();
            var result = rpn.EvalRPN(new string[] { "2", "1", "+", "3", "*" });
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void TargetSums()
        {
            var rpn = new Solution();
            var result = rpn.FindTargetSumWays(new int[] { 6, 2, 2, 4, 4 }, 6);
            Assert.AreEqual(5, result);
        }

        [TestMethod]

        public char[,] GetGrid(string[] strings)
        {
            var grid = new char[strings.Length, strings[0].Length];

            for (int i = 0; i < strings.Length; i++)
                for (int j = 0; j < strings[i].Length; j++)
                    grid[i, j] = strings[i][j];
            return grid;
        }

        public Dictionary<string, HashSet<string>> BuildDependencies(int count, int fillRate = 50)
        {
            var map = new Dictionary<string, HashSet<string>>();
            var rand = new Random();

            for (int i = count; i > 0; i--)
            {
                var deps = new HashSet<string>();

                for (int j = 1; j < i; j++)
                    if (rand.Next(100) < fillRate) deps.Add(j.ToString());
                map[i.ToString()] = deps;
            }

            return map;
        }

    }
}
