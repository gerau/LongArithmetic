using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArithmetic
{
    internal static class Convertor
    {
        public static uint ConvertHexSymbolIntoDigit(char c)
        {
            if ("0123456789".Contains(c))
            {
                return (uint)c - 48;
            }
            else if ("ABCDEF".Contains(c))
            {
                return (uint)c - 55;
            }
            else if ("abcdef".Contains(c))
            {
                return (uint)c - 87;
            }
            throw new ArgumentException();
        }
        public static char ConvertDigitIntoHexSymbol(uint i)
        {
            if ((i >= 0) && (i < 9))
            {
                return (char)(48 + i);
            }
            else if ((i >= 10) && (i < 16))
            {
                return (char)(55 + i);
            }
            throw new ArgumentException();
        }
        public static UInt32[] ConvertHexIntoNumber(string str)
        {
            var array = new UInt32[(str.Length / 8) + 1];
            var strReverse = new string(str.Reverse().ToArray());
            int cell = -1;
            for (int i = 0; i < strReverse.Length; i++)
            {
                uint j = (uint)i % 8;
                if (j == 0)
                {
                    cell++;
                }
                uint powerOfTwo = (uint)Math.Pow(2, (double)(4 * j));
                uint hexSymbol = ConvertHexSymbolIntoDigit(strReverse[i]);
                array[cell] += hexSymbol * powerOfTwo;
            }
            return array;
        }
        public static string ConvertNumberIntoHex(UInt32[] array)
        {
            string output = string.Empty;
            var ar = array.Reverse().ToArray();
            foreach (UInt32 number in ar)
            {
                for (int i = 0; i < 8; i++)
                {
                    uint powerOfTwo = (uint)Math.Pow(2, (double)(4 * i));
                    uint temp = number / powerOfTwo;
                    temp = temp % 16;
                    output += ConvertDigitIntoHexSymbol(temp);
                }
            }
            output = new string(output.Reverse().ToArray());
            return output;
        }
    }
}
