using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.SortSearch
{

    public class VersionControl
    {
        public int Count = 0;
        public int FirstBad = 7;

        protected bool IsBadVersion(int version)
        {
            Count++;
            Console.Write("  {0}", version);
            return version >= FirstBad;
        }

        public int FirstBadVersion(int n)
        {
            // binary search is fastest
            // we're trying to find the split point

            // 1. split n
            // 2. if mid-point is good, move good forward
            //    if mid-point is bad, move bad back
            // 3. repeat until good+1==bad
            int good = 0;
            int bad = n;

            while (good + 1 < bad)
            {
                int mid = good + (bad - good) / 2;
                if (IsBadVersion(mid))
                    bad = mid;
                else
                    good = mid;
            }

            return bad;
        }


    }


}
