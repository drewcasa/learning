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
            int totalItems = 1;

            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    // pull current item
                    var curr = q.Dequeue();
                    
                    // further optimization if we remove 1 from the candidates list, only enqueue when we're down to < 4
                    foreach (var candidate in candidates)
                    {
                        if (curr - candidate == 0) return totalItems; // shortest path achieved
                        if (curr - candidate < 0) continue; // ignore candidates that are larger than curr value
                        if (curr > (candidate * candidate)) continue; // ignore candidates smaller than sqrt (except 1), b/c otherwise a larger option exists
                        q.Enqueue(curr - candidate);
                    }

                    // if less than 4, only candidate is 1, and this is more optimal
                    if (curr == 1) return totalItems;
                    if (curr < 4) q.Enqueue(curr - 1);
                }
                totalItems++;
            }

            throw new InvalidOperationException();
        }

        private List<int> GetCandidates(int max)
        {
            // get candidates squares from max -> 4, assuming larger values will find match quicker
            var sq = new List<int>();
            for (int i = (int)Math.Sqrt(max); i > 1; i--)
                sq.Add(i * i);
            return sq;
        }

    }
}
