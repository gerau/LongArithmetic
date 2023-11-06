namespace LongArithmetic
{ 
    internal class LongLongInt
    {
        public const int SIZE = LongInt.SIZE*2 + 2;
        public uint[] number { get; }
        public LongLongInt()
        {
            number = new uint[SIZE];
        }
        public LongLongInt(uint number)
        {
            this.number = new uint[SIZE];
            this.number[0] = number;
        }
        public LongLongInt(LongInt A)
        {
            number = new uint[SIZE];
            for(int i = 0; i < A.number.Length; i++)
            {
                number[i] = A.number[i];
            }
        }

        public LongLongInt(LongLongInt A)
        {
            this.number = A.number;
        }
        public static LongLongInt operator +(LongLongInt A, LongLongInt B)
        {
            uint carry = 0;
            var C = new LongLongInt();
            for (int i = 0; i < A.number.Length; i++)
            {
                ulong temp = (ulong)A[i] + (ulong)B[i] + (ulong)carry;
                C[i] = (uint)(temp & (uint.MaxValue));
                carry = (uint)(temp >> 32);
            }
            return C;
        }

        public static LongLongInt operator -(LongLongInt A, LongLongInt B)
        {
            uint borrow = 0;
            var C = new LongLongInt();
            for (int i = 0; i < A.number.Length; i++)
            {
                Int64 temp = (Int64)A[i] - (Int64)B[i] - borrow;
                if (temp >= 0)
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
            if (borrow == 1)
            {
                throw new Exception("Error: The larger number is subtracted from the smaller one");
            }
            return C;
        }

        public static bool operator ==(LongLongInt A, LongLongInt B)
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

        public static bool operator !=(LongLongInt A, LongLongInt B)
        {
            return !(A == B);
        }

        public static LongLongInt operator *(LongLongInt A, uint b)
        {
            uint carry = 0;
            LongLongInt C = new LongLongInt();
            for (int i = 0; i < A.number.Length; i++)
            {
                ulong temp = (ulong)A[i] * (ulong)b + (ulong)carry;
                C[i] = (uint)(temp & uint.MaxValue);
                carry = (uint)(temp >> 32);
            }
            C[A.number.Length - 1] = carry;
            return C;
        }

        public static LongLongInt operator >>(LongLongInt A, int b)
        {
            LongLongInt C = new LongLongInt();
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

        public static LongLongInt operator <<(LongLongInt A, int b)
        {
            LongLongInt C = new LongLongInt();
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

        public static bool operator <(LongLongInt A, LongLongInt B)
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

        public static bool operator >(LongLongInt A, LongLongInt B)
        {
            return B < A;
        }

        public static bool operator <=(LongLongInt A, LongLongInt B)
        {
            int i;
            for (i = SIZE - 1; i > -1; i--)
            {
                if (A[i] != B[i])
                {
                    break;
                }
            }
            if (i == -1) return true;
            else return A[i] < B[i] ? true : false;
        }

        public static bool operator >=(LongLongInt A, LongLongInt B)
        {
            return B <= A;
        }

        public static LongLongInt operator *(LongLongInt A, LongLongInt B)
        {
            LongLongInt C = new LongLongInt();
            for (int i = 0; i < SIZE; i++)
            {
                var temp = A * B[i];
                temp = temp << i;
                C = C + temp;
            }
            return C;
        }
        public static LongLongInt BitShiftToHigh(LongLongInt A, int t)
        {
            if (t <= 0 | t >= SIZE * 32)
            {
                return A;
            }
            int numberOfShifts = t / 32;
            int shift = t % 32;
            uint carry = 0;
            LongLongInt C = new LongLongInt();
            if (shift != 0)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    C[i] = (A[i] << shift) + carry;
                    carry = (A[i] >> 32 - shift);
                }
                LongLongInt output = new LongLongInt();
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
                LongLongInt output = new LongLongInt();
                for (int j = numberOfShifts; j < SIZE; j++)
                {
                    output[j] = C[j - numberOfShifts];
                }
                return output;
            }
        }
        public static LongLongInt BitShiftToLow(LongLongInt A, int t)
        {
            if (t <= 0 | t >= SIZE * 32)
            {
                return A;
            }
            int numberOfShifts = t / 32;
            int shift = t % 32;
            uint carry = 0;
            LongLongInt C = new LongLongInt();
            if (shift != 0)
            {
                for (int i = SIZE - 1; i > 0; i--)
                {
                    C[i] = (A[i] >> shift) + (carry << 32 - shift);
                    carry = A[i] & (uint)shift;
                }
                C[0] = (A[0] >> shift) + (carry << 32 - shift);
                LongLongInt output = new LongLongInt();
                for (int j = SIZE - 1 - numberOfShifts; j > -1; j--)
                {
                    output[j] = C[j + numberOfShifts];
                }
                return output;
            }
            else
            {
                for (int i = SIZE - 1; i > -1; i--)
                {
                    C[i] = A[i];

                }
                LongLongInt output = new LongLongInt();
                for (int j = SIZE - 1 - numberOfShifts; j > -1; j--)
                {
                    output[j] = C[j + numberOfShifts];
                }
                return output;
            }
        }

        public int BitLength()
        {
            if (this == Zero())
            {
                return 0;
            }
            int i = DigitLength();
            i--;
            int length = i * 32;
            uint temp = number[i];
            while (temp != 0)
            {
                temp = temp >> 1;
                length++;
            }
            return length;

        }

        public static LongLongInt operator /(LongLongInt A, LongLongInt B)
        {
            var k = B.BitLength();
            var Q = new LongLongInt();
            var R = new LongLongInt(A);
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
                Q = Q + BitShiftToHigh(new LongLongInt(1), t - k);
            }
            return Q;
        }

        public static LongLongInt operator %(LongLongInt A, LongLongInt B)
        {

            var k = B.BitLength();
            var R = new LongLongInt(A);
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
        public static LongInt BarrettReduction(LongLongInt A, LongLongInt N, LongLongInt M)
        {
            var k = N.DigitLength();

            LongLongInt Q = A >> k - 1;
            Q = Q * M;
            Q = Q >> k + 1;

            LongLongInt R = A - (Q * N);
            while (R >= N)
            {
                R = R - N;
            }
            return new LongInt(R);
        }
        public static LongLongInt Mu(LongInt N)
        {
            var length = N.DigitLength();
            var NLong = new LongLongInt(N);
            var Beta = new LongLongInt(1);
            Beta = Beta << 2 * length;
            var temp = Beta / NLong;
            return temp;
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
        public bool IsEven()
        {
            return number[0] % 2 == 0;
        }
        public uint this[int i]
        {
            get { return number[i]; }
            set { number[i] = value; }
        }
        public override string ToString()
        {
            return Convertor.NumberIntoHexString(number, true);
        }
        public static LongLongInt Zero()
        {
            return new LongLongInt(0);
        }
        public static LongLongInt One()
        {
            return new LongLongInt(1);
        }
    }
}
