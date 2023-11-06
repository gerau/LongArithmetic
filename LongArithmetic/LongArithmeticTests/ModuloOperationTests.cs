using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongArithmeticTests
{
    public class ModuloOperationTests
    {
        LongInt num1; LongInt num2; LongInt num3; LongInt mod; LongInt M;
        [SetUp] 
        public void SetUp() 
        {

            num1 = new LongInt( Generator.GenerateNewHex(100));
            num2 = new LongInt(Generator.GenerateNewHex(100));
            num3 = new LongInt(Generator.GenerateNewHex(100));
            mod = new LongInt(Generator.GenerateNewHex(100));
            M = LongInt.Mu(mod);
        }
        [Test]
        public void AssociativityAddTest()
        {
            var numMultRight = num1.ModAdd(num2, mod, M).ModMult(num3, mod, M);
            var numMultLeft = num3.ModMult(num1.ModAdd(num2,mod,M), mod, M);
            var numMult = num1.ModMult(num3, mod, M).ModAdd(num2.ModMult(num3,mod,M),mod,M);
            Assert.IsTrue((numMultRight.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultLeft.ToString()) & (numMult.ToString() == numMultRight.ToString()));
        }
        [Test]
        public void MultAndAddingTest()
        {
            var numberAdd = new LongInt(0);
            for (int i = 0; i < 428; i++)
            {
                numberAdd = numberAdd.ModAdd(num1, mod, M);
            }
            var numberMult = num1.ModMult( new LongInt(428), mod,M);
            Assert.That(numberAdd.ToString(), Is.EqualTo(numberMult.ToString()));
        }
        [Test]
        public void PhiTest()
        {
            var prime = new LongInt(1);
            var num = new LongInt(Generator.GenerateNewHex(40));
            prime = prime << 30;
            prime = prime - LongInt.One();
            if(LongInt.BinaryGCD(prime, num) == LongInt.One())
            {
                Assert.That((LongInt.PowModBarret(num, prime - LongInt.One(), prime)).ToString(), Is.EqualTo(LongInt.One().ToString() ));
            }
        }
    }
}
