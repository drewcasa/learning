using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Math
{
    public class BaseConversion
    {

        public static string ConvertToBase(int val, int b)
        {
            var sb = new StringBuilder();
            while (val > 0)
            {
                int r = val % b;
                sb.Insert(0, ConvertToChar(r));
                val /= b;
            }
            return sb.ToString();
        }

        public static char ConvertToChar(int val)
        {
            if (val < 10) return char.Parse(val.ToString());
            val = (int)'a' + val - 10;
            return (char)val;
        }

        public static int ConvertToInt(char c)
        {
            if (char.IsDigit(c)) return c - '0';
            return (c - 'a') + 10;
        }

        public static int ConvertFromBase(string text, int b)
        {
            int val = 0;
            for (int i = 0; i < text.Length; i++)
            {
                val *= b;
                val += ConvertToInt(text[i]);
            }
            return val;
        }

    }
}
