using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArithmetic
{
    internal class LongIntBit 
    {
        public const int SIZE = LongInt.SIZE*32;
        public bool[] number { get; }
        public LongIntBit()
        {
            number = new bool[SIZE];
        }

        public LongIntBit(LongInt num)
        {
            number = Convertor.NumberIntoBits(num.number);
        }
        public LongIntBit(LongIntBit A)
        {
            number = A.number;
        }

        public static LongIntBit operator + (LongIntBit A, LongIntBit B)
        {
            bool carry = false;
            var C = new LongIntBit();
            for (int i = 0; i < SIZE; i++)
            {
                C[i] = A[i] ^ B[i] ^ carry;
                carry = (A[i] & B[i]) ^ (A[i] & carry) ^ (B[i] & carry);  
            }
            return C;
        }

        public static LongIntBit operator - (LongIntBit A, LongIntBit B)
        {
            bool borrow = false;
            var C = new LongIntBit();
            for (int i = 0; i < SIZE; i++)
            {
                C[i] = A[i] ^ B[i] ^ borrow;
                borrow = (!A[i] & B[i]) | (!(A[i] ^ B[i]) & borrow);
            }
            if (borrow == true)
            {
                throw new Exception("Error: The larger number is subtracted from the smaller one");
            }
            return C;
        }

        public static bool operator == (LongIntBit A, LongIntBit B)
        {
            int i = 0;
            for (i = SIZE - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1)
            {
                return true;
            }

            return false;
        }

        public static bool operator != (LongIntBit A, LongIntBit B)
        {
            int i = SIZE - 1;
            while (A[i] == B[i])
            {
                i--;
            }
            if (i == -1)
            {
                return false;
            }
            return true;
        }

        public static LongIntBit operator >> (LongIntBit A, int b)
        {
            LongIntBit C = new LongIntBit();
            if ((b > SIZE - 1) && (b < 0)) return C;
            int i = 0;
            while (b < SIZE)
            {
                C[i] = A[b];
                i++;
                b++;
            }
            return C;
        }
        public static LongIntBit operator << (LongIntBit A, int b)
        {
            LongIntBit C = new LongIntBit();
            if ((b > SIZE - 1) && (b < 0)) return C;
            int i = 0;
            while (b < SIZE)
            {
                C[b] = A[i];
                i++;
                b++;
            }
            return C;
        }
        public static bool operator < (LongIntBit A, LongIntBit B)
        {
            int i = SIZE - 1;
            for (i = SIZE - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1) return false;
            else return B[i];
        }

        public static bool operator > (LongIntBit A, LongIntBit B)
        {
            return B < A;
        }

        public static bool operator <= (LongIntBit A, LongIntBit B)
        {
            int i = SIZE - 1;
            for (i = SIZE - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1) return true;
            else return B[i];
        }
        public static bool operator >= (LongIntBit A, LongIntBit B)
        {
            return B <= A;
        }
       
        public int BitLength()
        {
            int length = SIZE;
            while (!number[length - 1])
            {
                length--;
                if (length == 0)
                {
                    break;
                }
            }
            return length;
        }

        public static LongIntBit returnPowerOfTwo(int k)
        {
            var A = new LongIntBit();
            if(k < 0 | k > SIZE - 1)
            {
                return A;
            }
            A[k] = true;
            return A;
        }
        public bool this[int i]
        {
            get { return number[i]; }
            set { number[i] = value; }
        }
    }
}
