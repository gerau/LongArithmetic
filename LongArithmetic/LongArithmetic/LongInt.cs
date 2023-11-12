using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LongArithmetic
{
    public class LongInt
    {
        public const int SIZE = 32;
        public bool isDouble;
        public uint[] number { get; }
        public LongInt(bool isDouble = false)
        {
            this.isDouble = isDouble; 
            number = isDouble ? new uint[SIZE * 2 + 1] : new uint[SIZE];
        }
        
        public LongInt(string str, bool isDouble = false)
        {
            this.isDouble = isDouble;
            number = Convertor.HexStringIntoNumber(str, isDouble);
        }

        public LongInt(uint[] number)
        {
            if(number.Length != SIZE) number = new uint[SIZE];
            this.number = number;
        }

        public LongInt(uint number, bool isDouble = false)
        {
            this.isDouble = isDouble;
            if (isDouble)
            {
                this.number = new uint[SIZE * 2 + 1];
                this.number[0] = number;
            }
            else
            {
                this.number = new uint[SIZE];
                this.number[0] = number;
            }
        }

        public LongInt(LongInt A, bool isConvert = false)
        {
            if (isConvert)
            {
                if(A.isDouble)
                {
                    isDouble = false;
                    number = new uint[SIZE];
                    for (int i = 0; i < SIZE; i++)
                    {
                        number[i] = A.number[i];
                    }
                }
                else
                {
                    isDouble = true;
                    number = new uint[SIZE * 2 + 1];
                    for (int i = 0; i < A.number.Length; i++)
                    {
                        number[i] = A.number[i];
                    }
                }
            }
            else
            {
                isDouble = A.isDouble;
                number = A.number;
            }
           
        }
        public static LongInt operator + (LongInt A, LongInt B)
        {
            uint carry = 0;

            var C = new LongInt(A.isDouble);
            for(int i = 0 ; i < A.GetSize(); i++)
            {
                ulong temp = (ulong)A[i] + (ulong)B[i] + (ulong)carry;
                C[i] = (uint)(temp & (uint.MaxValue));
                carry = (uint)(temp >> 32);
            }
            return C;
        }

        public static LongInt operator - (LongInt A, LongInt B)
        {
            uint borrow = 0;
            var C = new LongInt(A.isDouble);
            for (int i = 0; i < A.GetSize(); i++)
            {
                long temp = (long)A[i] - (long)B[i] - borrow;
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
        public static LongInt operator * (LongInt A, uint b)
        {
            uint carry = 0;
            LongInt C = new LongInt(A.isDouble);
            for(int i = 0; i < A.GetSize(); i++)
            {
                ulong temp = (ulong)A[i]*(ulong)b + (ulong)carry;
                C[i] = (uint)(temp & uint.MaxValue);
                carry = (uint)(temp >> 32);
            }
            C[A.GetSize() - 1] = carry;
            return C;
        }
        public static LongInt operator * (LongInt A, LongInt B)
        {
            LongInt C = new LongInt(A.isDouble);
            var tempB = B;
            if (A.isDouble & !B.isDouble)
            {
                tempB = new LongInt(B, true);
            }
            for (int i = 0; i < A.GetSize(); i++)
            {
                var temp = A * tempB[i];
                temp = temp << i;
                C = C + temp;
            }
            return C;
        }

        public static LongInt operator >> (LongInt A, int b)
        {           
            LongInt C = new LongInt(A.isDouble);
            if ((b > A.GetSize() - 1) && (b < 0)) return C;
            int i = 0;
            while(b < A.GetSize())
            {
                C[i] = A[b];
                i++;
                b++;
            }
            return C;
        }

        public static LongInt operator << (LongInt A, int b)
        {
            LongInt C = new LongInt(A.isDouble);
            if ((b > A.GetSize() - 1) && (b < 0)) return C;
            int i = 0;
            while (b < A.GetSize())
            {
                C[b] = A[i];
                i++;
                b++;
            }
            return C;
        }
        public static bool operator == (LongInt A, LongInt B)
        {
            int i;
            var tempB = B;
            if (A.isDouble & !B.isDouble) 
            {
                tempB = new LongInt(B, true);
            }
            for (i = A.GetSize() - 1; i > -1; i--)
            {
                if (A[i] != tempB[i])
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
            return !(A == B);
        }

        public static bool operator < (LongInt A, LongInt B)
        {
            int i;
            for (i = A.GetSize() - 1; i > -1; i--)
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
            int i;
            for (i = A.GetSize() - 1; i > -1; i--)
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


        public static LongInt toSquare(LongInt A)
        {
            return A * A;
        }

        public static LongInt BitShiftToHigh(LongInt A,int t)
        {
            if(t <= 0 | t >= A.GetSize()*32)
            {
                return A;
            }
            int numberOfShifts = t / 32;
            int shift = t % 32;
            uint carry = 0;
            LongInt C = new LongInt(A.isDouble);
            if (shift != 0)
            {
                for (int i = 0; i < A.GetSize(); i++)
                {
                    C[i] = (A[i] << shift) + carry;
                    carry = (A[i] >> 32 - shift);
                }
                LongInt output = new LongInt(A.isDouble);
                for (int j = numberOfShifts; j < A.GetSize(); j++)
                {
                    output[j] = C[j - numberOfShifts];
                }
                return output;
            }
            else
            {
                for (int i = 0; i < A.GetSize(); i++)
                {
                    C[i] = A[i];
                    
                }
                LongInt output = new LongInt(A.isDouble);
                for (int j = numberOfShifts; j < A.GetSize(); j++)
                {
                    output[j] = C[j - numberOfShifts];
                }
                return output;
            }
        }
        public static LongInt BitShiftToLow(LongInt A, int t)
        {
            if (t <= 0 | t >= A.GetSize() * 32)
            {
                return A;
            }
            int numberOfShifts = t / 32;
            int shift = t % 32;
            uint carry = 0;
            LongInt C = new LongInt(A.isDouble);
            if (shift != 0)
            {
                for (int i = A.GetSize() - 1; i > 0; i--)
                {
                    C[i] = (A[i] >> shift) + (carry << 32 - shift);
                    carry = A[i] & (uint)shift;
                }
                C[0] = (A[0] >> shift) + (carry << 32 - shift);
                LongInt output = new LongInt(A.isDouble);
                for (int j = A.GetSize() - 1 - numberOfShifts; j > -1 ; j--)
                {
                    output[j] = C[j + numberOfShifts];
                }
                return output;
            }
            else
            {
                for (int i = A.GetSize() - 1; i > -1; i--)
                {
                    C[i] = A[i];

                }
                LongInt output = new LongInt(A.isDouble);
                for (int j = A.GetSize() - 1 - numberOfShifts; j > -1; j--)
                {
                    output[j] = C[j + numberOfShifts];
                }
                return output;
            }
        }

        public int BitLength()
        {
            if(this == Zero())
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
            var Q = new LongInt(A.isDouble);
            var R = new LongInt(A);
            while(R >= B)
            {
                var t = R.BitLength();
                var C = BitShiftToHigh(B, t - k);
                if (R < C)
                {
                    t--;
                    C = BitShiftToHigh(B, t - k);
                }
                R = R - C;
                Q = Q + BitShiftToHigh(new LongInt(1, A.isDouble), t - k);
            }
            return Q;
        }

        public static LongInt operator % (LongInt A, LongInt B)
        {

            var k = B.BitLength();
            var R = new LongInt(A);
            while (R >= B)
            {
                var t = R.BitLength();
                var C = BitShiftToHigh(B, t - k);
                if (R < C)
                {
                    t--;
                    C = BitShiftToHigh(B, t - k);
                }
                R = R - C;
            }
            return R;
        }

        public static LongInt Pow (LongInt A, LongInt B)
        {
            var C = new LongInt(1);
            var bitB = Convertor.NumberIntoBinary(B.number);
            bitB = new string(bitB.Reverse().ToArray());
            for (int i = bitB.Length - 1; i > -1; i--)
            {
                if (bitB[i] == '1')
                {
                    C = C * A;
                }
                if (i > 0)
                {
                    C = C * C;
                }
            }
            return C;
        }
        public static LongInt BinaryGCD(LongInt A, LongInt B)
        {
            var C = new LongInt(1);
            var Atemp = new LongInt(A);
            var Btemp = new LongInt(B);
            while (Atemp.IsEven() & Btemp.IsEven())
            {
                Atemp = BitShiftToLow(Atemp, 1);
                Btemp = BitShiftToLow(Btemp, 1);
                C = BitShiftToHigh(C, 1);
            }
            while (Atemp.IsEven())
            {
                Atemp = BitShiftToLow(Atemp, 1);
            }
            while (Btemp != Zero())
            {
                while (Btemp.IsEven())
                {
                    Btemp = BitShiftToLow(Btemp, 1);
                }
                var temp = Min(Atemp, Btemp);
                Btemp = AbsForSub(Atemp, Btemp);
                Atemp = temp;
            }
            C = C * Atemp;
            return C;
        }
        public static LongInt LCM(LongInt A, LongInt B)
        {
            return (A * B) / BinaryGCD(A, B);
        }

        public static LongInt BarrettReduction(LongInt A, LongInt N, LongInt M)
        {    
            var k = N.DigitLength();

            if(A < N)
            {
                return A;
            }
            LongInt Q = A >> k - 1;
            Q = Q * M;
            Q = Q >> k + 1;
            
            LongInt R = A - (Q * N);
            while(R >= N)
            {
                R = R - N;
            }
            return R;
        }
        public LongInt ModAdd(LongInt B, LongInt N, LongInt M)
        {
            if (B.DigitLength() == SIZE & this.DigitLength() == SIZE)
            {
                var C = new LongInt(this, true) + new LongInt(B, true);
                return new LongInt(BarrettReduction(C, new LongInt(N,true), new LongInt(M, true)),true);
            }
            else 
            {
                var C = this + B;
                return BarrettReduction(C, N, M);
            }
        }
        public LongInt ModSub(LongInt B, LongInt N, LongInt M)
        {
            if(this < B)
            {
                var C = B - this;
                C = BarrettReduction(C, N, M);
                C = N - C;
                return C;
            }
            else
            {
                var C = this - B;
                return BarrettReduction(C, N, M);
            }
        }
        public LongInt ModMult(LongInt B, LongInt N, LongInt M)
        {
            var Amod = new LongInt(this); var Bmod = new LongInt(B);
            var s = new Stopwatch();
            while(Amod >= N)
            {
                Amod -= N;
            }
            while(Bmod >= N)
            {
                Bmod -= N;
            }
            if(Amod.DigitLength() >= (SIZE >> 1) | Bmod.DigitLength() >= (SIZE >> 1) | Amod.isDouble | Bmod.isDouble)
            {
                var C = new LongInt(Bmod, !Bmod.isDouble) * new LongInt(Amod, !Amod.isDouble);
                return BarrettReduction(C, new LongInt(N, true), M);

            }
            else
            {
                var C = Amod * Bmod;
                return BarrettReduction(C, N, M);
            }
        }

        public static LongInt PowModBarret(LongInt A, LongInt B, LongInt N)
        {
            LongInt C = new LongInt(1, A.isDouble);
            LongInt M = Mu(N);
            var Amod = new LongInt(A);
            var s = new Stopwatch();
            while (Amod >= N)
            {
                Amod -= N;
            }
            var bitB = Convertor.NumberIntoBinary(B.number);
            bitB = new string(bitB.Reverse().ToArray());
            for (int i = bitB.Length - 1; i > -1; i--)
            {

                if (bitB[i] == '1')
                {

                    C = C.ModMult(Amod, N, M);

                }

                if (i > 0)
                {
                    C = C.ModMult(C, N, M);
                }
            }
            return C;
        }
        public int DigitLength()
        {
            int length = this.GetSize();
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
        public bool IsEven()
        {
            return number[0] % 2 == 0;
        }

        public static LongInt Mu(LongInt N) 
        {
            var length = N.DigitLength();
            var NLong = new LongInt(N, true);
            var Beta = new LongInt(1,true);
            Beta = Beta << 2 * length;
            var temp = Beta / NLong;
            return new LongInt(temp, false);
        }
        public static LongInt Min(LongInt A, LongInt B)
        {
            if(A > B)
            {
                return B;
            }
            else
            {
                return A;
            }
        }
        public static LongInt AbsForSub(LongInt A, LongInt B)
        {
            if(A > B)
            {
                return A - B;
            }
            else
            {
                return B - A;
            }
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
        public static  LongInt Zero()
        {
            return new LongInt(0);
        }
        public static LongInt One()
        {
            return new LongInt(1);
        }
        public int GetSize()
        {
            return number.Length;
        }
    }
}
