using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace LongArithmetic
{
    internal class Program
    {
        static void CountAverageTime(int k)
        {
            (long, long, long) averageTimeForMu = (0,0,0);
            (long, long, long) averageTimeForAdding = (0,0,0);
            (long, long, long) averageTimeForSub = (0, 0, 0);
            (long, long, long) averageTimeForMult = (0, 0, 0);
            (long, long, long) averageTimeForPower = (0, 0, 0);
            (long, long, long) averageTimeForGCD = (0, 0, 0);
            (long, long, long) averageTimeForLCM = (0, 0, 0);
            int numOfIteration = 32;
            switch (k)
            {
                case 1:
                    for (int i = 0; i < numOfIteration; i++)
                    {
                        var first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModAdd(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForAdding.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("1");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModAdd(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForAdding.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("2");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8 - 1));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8 - 1));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8 - 1));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModAdd(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForAdding.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("3");
                    }
                    Console.WriteLine($"Ticks for adding in average for short, mid and long num:{averageTimeForAdding.Item1 / numOfIteration}, {averageTimeForAdding.Item2 / numOfIteration}, {averageTimeForAdding.Item3 / numOfIteration}");
                    break;
                case 2:
                    for (int i = 0; i < numOfIteration; i++)
                    {
                        var first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModSub(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForSub.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("1");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModSub(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForSub.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("2");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModSub(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForSub.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("3");
                    }
                    Console.WriteLine($"Ticks for sub in average for short, mid and long num:{averageTimeForSub.Item1 / numOfIteration}, {averageTimeForSub.Item2 / numOfIteration}, {averageTimeForSub.Item3 / numOfIteration}");
                    break;
                case 3:
                    for (int i = 0; i < numOfIteration; i++)
                    {
                        var first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModMult(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForMult.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("1");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModMult(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForMult.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("2");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        first.ModMult(second, modulo, Mu);
                        stopwatch.Stop();
                        averageTimeForMult.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("3");
                    }
                    Console.WriteLine($"Ticks for adding in Mult for short, mid and long num:{averageTimeForMult.Item1 / numOfIteration}, {averageTimeForMult.Item2 / numOfIteration}, {averageTimeForMult.Item3 / numOfIteration}");
                    break;
                case 4:
                    for (int i = 0; i < numOfIteration / 4; i++)
                    {
                        var first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var second = new LongInt(Generator.GenerateNewHex(4));
                        var modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.PowModBarret(first, second, modulo);
                        stopwatch.Stop();
                        averageTimeForPower.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("1");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        second = new LongInt(Generator.GenerateNewHex(4));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 4));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.PowModBarret(first, second, modulo);
                        stopwatch.Stop();
                        averageTimeForPower.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("2");

                        first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        second = new LongInt(Generator.GenerateNewHex(4));
                        modulo = new LongInt(Generator.GenerateNewHex(LongInt.SIZE * 8));
                        stopwatch.Start();
                        Mu = LongInt.Mu(modulo);
                        stopwatch.Stop();
                        averageTimeForMu.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.PowModBarret(first, second, modulo);
                        stopwatch.Stop();
                        averageTimeForPower.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        Console.WriteLine("3");
                    }
                    Console.WriteLine($"Ticks for adding in pow for short, mid and long num:{averageTimeForPower.Item1 * 4 / numOfIteration}, {averageTimeForPower.Item2 * 4 / numOfIteration}, {averageTimeForPower.Item3 * 4 / numOfIteration}");
                    break;
                case 5:
                    for (int i = 0; i < numOfIteration; i++)
                    {
                        var first = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var second = new LongInt(Generator.GenerateNewHex(LongInt.SIZE));
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        
                        LongInt.BinaryGCD(first, second);
                        stopwatch.Stop();
                        var gcd = stopwatch.ElapsedTicks;
                        averageTimeForGCD.Item1 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.LCM(first, second);
                        stopwatch.Stop();
                        averageTimeForLCM.Item1 += stopwatch.ElapsedTicks + gcd; stopwatch.Restart();

                        stopwatch.Start();

                        LongInt.BinaryGCD(first, second);
                        stopwatch.Stop();
                        gcd = stopwatch.ElapsedTicks;
                        averageTimeForGCD.Item2 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.LCM(first, second);
                        stopwatch.Stop();
                        averageTimeForLCM.Item2 += stopwatch.ElapsedTicks + gcd; stopwatch.Restart();

                        Console.WriteLine("2");

                        stopwatch.Start();

                        LongInt.BinaryGCD(first, second);
                        stopwatch.Stop();
                        gcd = stopwatch.ElapsedTicks;
                        averageTimeForGCD.Item3 += stopwatch.ElapsedTicks; stopwatch.Restart();
                        stopwatch.Start();
                        LongInt.LCM(first, second);
                        stopwatch.Stop();
                        averageTimeForLCM.Item3 += stopwatch.ElapsedTicks + gcd; stopwatch.Restart();
                        Console.WriteLine("3");
                    }
                    Console.WriteLine($"Ticks for  gcd for short, mid and long num:{averageTimeForGCD.Item1 / numOfIteration}, {averageTimeForGCD.Item2 / numOfIteration}, {averageTimeForGCD.Item3 / numOfIteration}");
                    Console.WriteLine($"Ticks for  lcm for short, mid and long num:{averageTimeForLCM.Item1 / numOfIteration}, {averageTimeForLCM.Item2 / numOfIteration}, {averageTimeForLCM.Item3 / numOfIteration}");
                    break;
            }   
            
            Console.WriteLine($"Ticks for Mu in average for short, mid and long num:{averageTimeForMu.Item1 / numOfIteration }, {averageTimeForMu.Item2 / numOfIteration}, {averageTimeForMu.Item3 / numOfIteration }");
        }
        static void Main(string[] args)
        {
            var num1 = new LongInt("a96022d8878e3e19eab6bf304c76219cfc1b443033160c4a1b802464c5d935d6");
            var num2 = new LongInt("1fd5f8cf8518a4b11e6ab1baf9e9697cf4daa556577a62e5d8789c4a85905bfc");
            var num3 = new LongInt("7606330b4b408a78d95778db6fd5976a8be6d86133ff582f8bed97d91467642f");

            Console.WriteLine(num1); Console.WriteLine(num2);

            var powb = LongInt.PowModBarret(num1, new LongInt(Generator.GenerateNewHex(3)), num3);
            Console.WriteLine(powb);
            var M = LongInt.Mu(num3);
            var mulM = num1.ModMult(num2, num3, M);
            Console.WriteLine($"modulo mult {mulM}");
            var addM = num1.ModAdd(num2, num3, M);
            Console.WriteLine($"modulo add  {addM}");
            var subM = num1.ModSub(num2, num3, M);
            Console.WriteLine($"modulo sub  {subM}");
            var gcd = LongInt.BinaryGCD(num1, num2);
            Console.WriteLine($"gcd {gcd}");
            var lcm = LongInt.LCM(num1, num2);
            Console.WriteLine($"lcm {lcm}");

        }
    }
}