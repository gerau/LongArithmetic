using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;

namespace LongArithmeticTests
{
    public class Tests
    {
        LongInt n1; LongInt n2; BigInteger n3; BigInteger n4;
        string power;
        int powerOf = 0;

        [SetUp]
        public void Setup()
        {
            var rand = new Random();
            var r = rand.Next(30, 250);
            var p = rand.Next(8,15);
            powerOf = rand.Next(5, 10);
            power = "0" + Generator.GenerateNewHex(rand.Next(60, 90));
            var number1 = "0" + Generator.GenerateNewHex(r);
            var number2 = "0" + Generator.GenerateNewHex(r - p);


            n1 = new LongInt(number1);
            n2 = new LongInt(number2);
            n3 = BigInteger.Parse(number1, NumberStyles.HexNumber);
            n4 = BigInteger.Parse(number2, NumberStyles.HexNumber);

        }

        [Test]
        public void Addition()
        {
            var out1 = n1 + n2;
            var out2 = n3 + n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void Substraction()
        {
            var out1 = n1 - n2;
            var out2 = n3 - n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void Multiply()
        {
            var out1 = n1 * n2;
            var out2 = n3 * n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void Divide()
        {
            var out1 = n1 / n2;
            var out2 = n3 / n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void Modulo()
        {
            var out1 = n1 % n2;
            var out2 = n3 % n4;
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void PowerOf()
        {

            var out1 = LongInt.Pow(n1,new LongInt((uint)powerOf));
            var out2 = BigInteger.Pow(n3, powerOf);
            
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void GCD()
        {
            var out1 = LongInt.BinaryGCD(n1, n2);
            var out2 = BigInteger.GreatestCommonDivisor(n3, n4);
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }
        [Test]
        public void LCM()
        {
            var out1 = LongInt.LCM(n1, n2);
            var out2 = n3 * n4 / BigInteger.GreatestCommonDivisor(n3, n4);
            var strOut1 = out1.ToString();
            var strOut2 = out2.ToString("X");
            strOut2 = strOut2.TrimStart('0');
            Assert.That(strOut1, Is.EqualTo(strOut2));
        }

    }
}