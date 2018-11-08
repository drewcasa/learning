using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.SortSearch
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;

            // find middle
            int start = 0;
            int end = nums.Length - 1;
            do
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            } while (start <= end);

            return -1;
        }

        public int MySqrt(int x)
        {
            // bad math, but it'll work
            int start = 0;
            int end = x;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if ((mid * (long)mid <= (long)x))
                {
                    if ((mid + 1) * (long)(mid + 1) > (long)x)
                        return mid;
                    else
                        start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1; // shouldn't happen unless bad maths
        }

        /// <summary>
        /// Return an index of a peak, which is higher than neighbors.
        /// Edges are lower, so a peak could exist at either edge.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comp = CompareToNeighbors(nums, mid);
                if (comp == 0) return mid;

                if (comp < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        /// <summary>
        /// 0 == peak, -1 == move left, 1 == move right
        /// </summary>
        private int CompareToNeighbors(int[] nums, int index)
        {
            if (index > 0 && nums[index] < nums[index - 1])
                return -1;
            if (index < (nums.Length - 1) && nums[index] < nums[index + 1])
                return 1;
            return 0;
        }

        public int FindMin(int[] nums)
        {
            // find the spot where we rotated
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right = mid; // can't subtract 1 b/c could cut off min
            }

            return nums[left];
        }

        public int SearchRotated(int[] nums, int target)
        {
            // find the spot where we rotated
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (IsInRange(nums[left], nums[mid], target))
                    right = mid - 1; // mid is checked, so we can start from next index over
                else
                    left = mid + 1;
            }

            return -1;
        }

        private bool IsInRange(int left, int right, int target)
        {
            // 5, 1, 3
            // inclusive of edges
            if (left > right) // inflexion
                return (target >= left || target <= right);
            else // normal
                return (target >= left && target <= right);
        }

    }
}
