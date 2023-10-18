using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;

namespace LongArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int powerOf = 50;
            var s1 = "77f612aec34ab3905fdca712aecde12394834";
            var s2 = "236456CAF23747388FDEDAAB";
            var num1 = new LongInt(s1);
            var num2 = new LongInt(s2);

            var sum = num1 + num2;
            var sub = num1 - num2;
            var mult = num1 * num2;
            var div1 = num1 / num2;
            var div2 = num1 % num2;
            var pow = LongInt.Pow(num1, new LongInt(50));

            var str = "";
            str += "Sum of A and B " + Convertor.NumberIntoHexString(sum.number) + '\n';
            str += "Sub of A and B " + Convertor.NumberIntoHexString(sub.number) + '\n';
            str += "Mult of A and B " + Convertor.NumberIntoHexString(mult.number) + '\n';
            str += "Division of A and B: Q = " + Convertor.NumberIntoHexString(div1.number) + " and R = " + Convertor.NumberIntoHexString(div2.number) + '\n';
            str += $"power of A and {powerOf} " + Convertor.NumberIntoHexString(pow.number) + '\n';
            Console.WriteLine(str);
        }
    }
}