using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;

namespace LongArithmeticTests
{
    public class Tests
    {
        string number1;
        string number2;
        string power;
        int powerOf = 0;

        [SetUp]
        public void Setup()
        {
            var rand = new Random();
            var r = rand.Next(150, 200);
            var p = rand.Next(1,10);
            powerOf = rand.Next(5, 10);
            power = "0" + Generator.GenerateNewHex(rand.Next(60, 90));
            number1 += ("0" + Generator.GenerateNewHex(r));
            number2 += ("0" + Generator.GenerateNewHex(r - p));
            
        }

        [Test]
        public void Addition()
        {
            var n1 = new LongInt(number1);
            var n2 = new LongInt(number2);

            var n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            var n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

            var out1 = n1 + n2;
            var out2 = n3 + n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut1 == strOut2);
        }
        [Test]
        public void Substraction()
        {
            var n1 = new LongInt(number1);
            var n2 = new LongInt(number2);

            var n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            var n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

            var out1 = n1 - n2;
            var out2 = n3 - n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut1 == strOut2);
        }
        [Test]
        public void Multiply()
        {
            var n1 = new LongInt(number1);
            var n2 = new LongInt(number2);

            var n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            var n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

            var out1 = n1 * n2;
            var out2 = n3 * n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut1 == strOut2);
        }
        [Test]
        public void Divide()
        {
            var n1 = new LongInt(number1);
            var n2 = new LongInt(number2);

            var n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            var n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

            var out1 = n1 / n2;
            var out2 = n3 / n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut1 == strOut2);
        }
        [Test]
        public void Modulo()
        {
            var n1 = new LongInt(number1);
            var n2 = new LongInt(number2);

            var n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            var n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

            var out1 = n1 % n2;
            var out2 = n3 % n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut1 == strOut2);
        }
        [Test]
        public void PowerOf()
        {
            var n1 = new LongInt(power);


            var n3 = BigInteger.Parse(power, NumberStyles.HexNumber);


            var out1 = LongInt.Pow(n1,new LongInt((uint)powerOf));
            var out2 = BigInteger.Pow(n3, powerOf);
            
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.IsTrue(strOut2.Contains(strOut1));
        }

    }
}