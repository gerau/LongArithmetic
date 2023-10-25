using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LongArithmetic
{
    public class LongInt
    {
        public const int SIZE = 256;
        public uint[] number { get; }
        public LongInt()
        {
            number = new uint[SIZE];
        }

        public LongInt(string str)
        {
            number =  Convertor.HexStringIntoNumber(str);
        }

        public LongInt(uint[] number)
        {
            if(number.Length != SIZE) number = new uint[SIZE];
            this.number = number;
        }

        public LongInt(uint number)
        {
            this.number = new uint[SIZE];
            this.number[0] = number;
        }

        public LongInt(LongInt A)
        {
            this.number = A.number;
        }

        public static LongInt operator + (LongInt A, LongInt B)
        {
            uint carry = 0;
            var C = new LongInt();
            for(int i = 0 ; i < A.number.Length; i++)
            {
                ulong temp = (ulong)A[i] + (ulong)B[i] + carry;
                C[i] = (uint)(temp & (uint.MaxValue));
                carry = (uint)(temp >> 32);
            }
            return C;
        }

        public static LongInt operator - (LongInt A, LongInt B)
        {
            uint borrow = 0;
            var C = new LongInt();
            for (int i = 0; i < A.number.Length; i++)
            {
                Int64 temp = (Int64)A[i] - (Int64)B[i] - borrow;
                if(temp >= 0)
                {
                    C[i] = (uint)temp;
                    borrow = 0;
                }
                else
                {
                    C[i] = (uint)(uint.MaxValue + temp + 1);
                    borrow = 1;
                }
            }
            if(borrow == 1)
            {
                throw new Exception("Error: The larger number is subtracted from the smaller one");
            }
            return C;
        }

        public static bool operator == (LongInt A, LongInt B)
        {
            int i = 0;
            for (i = A.number.Length - 1; i > -1; i--)
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

        public static bool operator != (LongInt A, LongInt B)
        {
            int i = A.number.Length - 1;
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

        public static LongInt operator * (LongInt A, uint b)
        {
            uint carry = 0;
            LongInt C = new LongInt();
            for(int i = 0; i < A.number.Length; i++)
            {
                ulong temp = (ulong)A[i]*(ulong)b + (ulong)carry;
                C[i] = (uint)(temp & uint.MaxValue);
                carry = (uint)(temp >> 32);
            }
            C[A.number.Length - 1] = carry;
            return C;
        }

        public static LongInt operator >> (LongInt A, int b)
        {           
            LongInt C = new LongInt();
            if ((b > SIZE - 1) && (b < 0)) return C;
            int i = 0;
            while(b < SIZE)
            {
                C[i] = A[b];
                i++;
                b++;
            }
            return C;
        }

        public static LongInt operator << (LongInt A, int b)
        {
            LongInt C = new LongInt();
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

        public static bool operator < (LongInt A, LongInt B)
        {
            int i = SIZE - 1;
            for (i = A.number.Length - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1) return false;
            else return A[i] < B[i] ? true : false; 
        }

        public static bool operator > (LongInt A, LongInt B)
        {
            return B < A;
        }

        public static bool operator <= (LongInt A, LongInt B)
        {
            int i = SIZE - 1;
            for (i = A.number.Length - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1) return true;
            else return A[i] < B[i] ? true : false;
        }

        public static bool operator >= (LongInt A, LongInt B)
        {
            return B <= A;
        }

        public static LongInt operator * (LongInt A, LongInt B)
        {
            LongInt C = new LongInt();
            for(int i = 0; i < SIZE; i++)
            {
                var temp = A * B[i];
                temp = temp << i;
                C = C + temp;
            }
            return C;
        }

        public static LongInt toSquare(LongInt A)
        {
            return A * A;
        }

        public static LongInt BitShiftToHigh(LongInt A,int t)
        {
            if(t <= 0)
            {
                return A;
            }
            int numberOfShifts = t / 32;
            int shift = t % 32;
            uint carry = 0;
            LongInt C = new LongInt();
            if (shift != 0)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    C[i] = (A[i] << shift) + carry;
                    carry = (A[i] >> 32 - shift);
                }
                LongInt output = new LongInt();
                for (int j = numberOfShifts; j < SIZE; j++)
                {
                    output[j] = C[j - numberOfShifts];
                }
                return output;
            }
            else
            {
                for (int i = 0; i < SIZE; i++)
                {
                    C[i] = A[i];
                    
                }
                LongInt output = new LongInt();
                for (int j = numberOfShifts; j < SIZE; j++)
                {
                    output[j] = C[j - numberOfShifts];
                }
                return output;
            }
            
        }

        public int BitLength()
        {
            if(this == LongInt.Zero())
            {
                return 0;
            }
            int i = DigitLength();
            i--;
            int length = i*32;
            uint temp = number[i];
            while (temp != 0)
            {
                temp = temp >> 1;
                length++;
            }
            return length;
           
        }

        public static LongInt operator / (LongInt A, LongInt B)
        {
            var k = B.BitLength();
            var Q = new LongInt();
            var R = new LongInt(A);
            while(R >= B)
            {
                var t = R.BitLength();
                var C = LongInt.BitShiftToHigh(B, t - k);
                if (R < C)
                {
                    t--;
                    C = LongInt.BitShiftToHigh(B, t - k);
                }
                R = R - C;
                Q = Q + LongInt.BitShiftToHigh(new LongInt(1), t - k);
            }
            return Q;
        }

        public static LongInt operator %(LongInt A, LongInt B)
        {

            var k = B.BitLength();
            var R = new LongInt(A);
            while (R >= B)
            {
                var t = R.BitLength();
                var C = LongInt.BitShiftToHigh(B, t - k);
                if (R < C)
                {
                    t--;
                    C = LongInt.BitShiftToHigh(B, t - k);
                }
                R = R - C;
            }
            return R;
        }

        public static LongInt Pow(LongInt A, LongInt B)
        {
            var C = new LongInt(1);
            var bitB = Convertor.NumberIntoBinary(B.number);
            for (int i = bitB.Length - 1; i > -1; i--)
            {
                if (bitB[i] == '1')
                {
                    C = C * A;
                }
                if (i > 0)
                {
                    C = toSquare(C);
                }
            }
            return C;
        }
        public int DigitLength()
        {
            int length = SIZE;
            while (number[length - 1] == 0)
            {
                length--;
                if (length == 0)
                {
                    break;
                }
            }
            return length;
        }

        public uint this[int i]
        {
            get { return number[i]; }
            set { number[i] = value; }
        }
        public override string ToString()
        {
            return Convertor.NumberIntoHexString(number);
        } 
        public static LongInt Zero()
        {
            return new LongInt(0);
        }
        public static LongInt One()
        {
            return new LongInt(1);
        }
    }   
}
