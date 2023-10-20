using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArithmeticTests
{
    public class BasicАxiomsTests
    {
        string number1;
        string number2;
        string number3;
        [SetUp]
        public void SetUp() 
        {
            number1 = Generator.GenerateNewHex(100);
            number2 = Generator.GenerateNewHex(97);
            number3 = Generator.GenerateNewHex(95);
        }
        [Test]
        public void MultAndAddingTest()
        {
            var num = new LongInt(number1);
            var numberAdd = new LongInt(0);
            for(int i = 0 ; i < 428; i++) 
            {
                numberAdd = numberAdd + num;            
            }
            var numberMult = num * 428;
            Assert.That(numberAdd.ToString(), Is.EqualTo(numberMult.ToString()));
        }

        [Test]
        public void AssociativityAddTest() 
        {
            var num1 = new LongInt(number1);
            var num2 = new LongInt(number2);
            var num3 = new LongInt(number3);
            var numMultRight = (num1 + num2) * num3;
            var numMultLeft = num3 * (num1 + num2);
            var numMult = num1 * num3 + num2 * num3;
            Assert.IsTrue((numMultRight.ToString() == numMultLeft.ToString()) &(numMult.ToString() == numMultLeft.ToString())&(numMult.ToString() == numMultRight.ToString()));
        }

        [Test]
        public void AssociativitySubTest()
        {
            var num1 = new LongInt(number1);
            var num2 = new LongInt(number2);
            var num3 = new LongInt(number3);
            var numMultRight = (num1 - num2) * num3;
            var numMultLeft = num3 * (num1 - num2);
            var numMult = num1 * num3 - num2 * num3;
            Assert.IsTrue((numMultRight.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultRight.ToString()));
        }
        [Test]
        public void Test4()
        {
            var num1 = new LongInt(number1);
            var num2 = new LongInt(number2);
            var num3 = new LongInt(number3);
            var numMultRight = (num1 * num2) * num3;
            var numMultLeft = num3 * (num1 * num2);
            var numMult = num1 * num3 * num2;
            Assert.IsTrue((numMultRight.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultRight.ToString()));
        }
        [Test]
        public void MultAndPowerTest()
        {
            var num = new LongInt(number1);
            var numMult = new LongInt(number1);
            for (int i = 0; i < 19; i++)
            {
                numMult = numMult * num;
            }
            var numberMult = LongInt.Pow(num,new LongInt(20));
            Assert.That(numMult.ToString(), Is.EqualTo(numberMult.ToString()));
        }
        [Test]
        public void CommutativeMultTest()
        {
            var num1 = new LongInt(number1);
            var num2 = new LongInt(number2);
            var num3 = num1 * num2;
            var num4 = num2 * num1;
            Assert.That(num3.ToString(), Is.EqualTo(num4.ToString()));
        }
    }
}
