using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    class PerfectSquares
    {
        public int NumSquares(int n)
        {
            // find candidate squares up to n
            var candidates = GetCandidates(n);

            // build queue for tracking shortest path to sum, probably some limits that could be put around candidates
            var q = new Queue<int>();
            q.Enqueue(n);
            int totalItems = 0;

            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    var curr = q.Dequeue();
                    if (curr == 0) return totalItems;
                    foreach (var candidate in candidates)
                    {
                        if (curr - candidate < 0) continue; // ignore candidates that are larger than curr value
                        if (curr > (candidate * candidate) && candidate > 1) continue; // ignore candidates smaller than sqrt (except 1), b/c otherwise a larger option exists
                        q.Enqueue(curr - candidate);
                    }
                }
                totalItems++;
            }

            throw new InvalidOperationException();
        }

        private List<int> GetCandidates(int max)
        {
            var sq = new List<int>();
            for (int i = 1; i <= Math.Sqrt(max); i++)
            {
                sq.Add(i * i);
            }
            sq.Reverse();
            return sq;
        }

    }
}
