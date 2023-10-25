using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArithmetic
{
    public static class Convertor
    {
        public static uint HexSymbolIntoDigit(char c) 
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
            throw new ArgumentException("Incorrect symbol");
        }

        public static char DigitIntoHexSymbol(uint i, bool isSmall = false)
        {
            if ((i >= 0) && (i < 10))
            {
                return (char)(48 + i);
            }
            else if ((i >= 10) && (i < 16))
            {
                if (isSmall)
                {
                    return (char)(87 + i);
                }
                else
                {
                    return (char)(55 + i);
                }
            }
            throw new ArgumentException("Incorrect number");
        }

        public static uint[] HexStringIntoNumber(string str)
        {
            var array = new uint[LongInt.SIZE];
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
                uint hexSymbol = HexSymbolIntoDigit(strReverse[i]);
                array[cell] += hexSymbol * powerOfTwo;
            }
            return array;
        }

        public static string NumberIntoHexString(uint[] array, bool isSmall = false)
        {
            string output = string.Empty;
            var reverseArray = array.Reverse().ToArray();
            foreach (uint number in reverseArray)
            {
                var str = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    uint powerOfTwo = (uint)Math.Pow(2, (double)(4 * i));
                    uint temp = number / powerOfTwo;
                    temp = temp % 16;
                    str += DigitIntoHexSymbol(temp,isSmall);
                }
                str = new string(str.Reverse().ToArray());
                output += str;
            }
            output = output.TrimStart('0');
            return output;
        }

        public static string BitIntoBitString(bool[] array)
        {
            string output = string.Empty;
            var ar = array.Reverse().ToArray();
            foreach(bool n in ar)
            {
                output += n ? "1" : "0";
            }
            output = output.TrimStart('0');
            return output;
        }

        public static bool[] NumberIntoBits(uint[] array)
        {
            var output = new bool[array.Length * 32];
            int i = 0;
            foreach (uint number in array)
            {

                for (int j = 0; j < 32; j++)
                {
                    uint powerOfTwo = (uint)Math.Pow(2, (double)(j));
                    uint temp = number / powerOfTwo;
                    temp = temp % 2;
                    output[j + i*32] = temp == 1;
                }
                i++;
            }
            return output;
        }

        public static uint[] BitsIntoNumber(bool[] array)
        {
            var output = new uint[array.Length/32];
            for (int i = 0; i < output.Length; i++)
            {
                for(int j = 0; j < 32; j++)
                {
                    uint powerOfTwo = (uint)Math.Pow(2, (double)(j));
                    output[i] += array[j + i*32] ? powerOfTwo : 0;
                }
            }
            return output;
        }
        public static string NumberIntoBinary(uint[] array)
        {
            string output = string.Empty;
            var reverseArray = array.Reverse().ToArray();
            foreach (uint number in reverseArray)
            {
                var str = string.Empty;
                for (int i = 0; i < 32; i++)
                {
                    uint powerOfTwo = (uint)Math.Pow(2, (double)(i));
                    uint temp = number / powerOfTwo;
                    temp = temp % 2;
                    str += $"{temp}";
                }
                str = new string(str.Reverse().ToArray());
                output += str;
            }
            output = output.TrimStart('0');
            return output;
        }
    }
}
