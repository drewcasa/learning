using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    public class Solution
    {
        public int NumIslands2(char[,] grid)
        {
            // track active islands, only need to know start/end index of each island on previous row
            var prevIslands = new Dictionary<int, int>();
            var islands = new Dictionary<int, int>();
            int totalIslands = 0;

            // iterate across rows, then down columns, tracking each active island as we go
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                int landStart = -1;
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    // if water
                    if (grid[row, col] == '0')
                    {
                        // if tracking island
                        if (landStart >= 0)
                        {
                            islands[landStart] = col - 1;
                            landStart = -1; // reset land index
                        }
                    }
                    // else land
                    else
                    {
                        if (landStart == -1) landStart = col; // start tracking new island

                        // if overlaps with previous
                        if (prevIslands.ContainsKey(col)) prevIslands.Remove(col); // remove prev overlapping island
                    }
                }
                if (landStart >= 0)
                {
                    // track last island
                    islands[landStart] = grid.GetLength(1) - 1;
                }

                // find overlapping islands
            }
            return totalIslands;
        }

        public int NumIslands(char[,] grid)
        {
            int count = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] == '1')
                        count += Visit(grid, i, j);
            return count;
        }

        private int Visit(char[,] grid, int row, int col)
        {
            // if outside bounds or not island, return
            if (row < 0 || row >= grid.GetLength(0)) return 0;
            if (col < 0 || col >= grid.GetLength(1)) return 0;
            if (grid[row, col] != '1') return 0;

            // mark this spot as visited
            grid[row, col] = 'x';

            // find adjacent land
            Visit(grid, row - 1, col); // N
            Visit(grid, row, col - 1); // W
            Visit(grid, row, col + 1); // E
            Visit(grid, row + 1, col); // S

            return 1;
        }

        public int OpenLock(string[] deadends, string target)
        {
            var used = new HashSet<string>(deadends);
            var q = new Queue<string>();
            int movesCount = 0;
            QueueMove(used, "0000", q);

            while (q.Count > 0)
            {
                // check each element in queue, adding only unused moves
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    string curr = q.Dequeue();
                    if (curr == target) return movesCount;

                    // queue 8 possible moves
                    QueueMoves(used, curr, q);
                }
                movesCount++;
            }

            return -1;
        }

        private void QueueMoves(HashSet<string> ends, string curr, Queue<string> q)
        {
            var chars = curr.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i]++;
                if (chars[i] > '9') chars[i] = '0'; // loop
                QueueMove(ends, new string(chars), q);

                chars[i] = curr[i];
                chars[i]--;
                if (chars[i] < '0') chars[i] = '9'; // loop
                QueueMove(ends, new string(chars), q);

                chars[i] = curr[i];
            }
        }

        private void QueueMove(HashSet<string> used, string move, Queue<string> q)
        {
            if (!used.Contains(move))
            {
                used.Add(move);
                q.Enqueue(move);
            }
        }

    }
}
