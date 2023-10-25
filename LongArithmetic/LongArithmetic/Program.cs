using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace LongArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs1 = { "0f7f612aec34ab3905",
                "0d8096aa33c5e6",
                "0b10037272cf8a43f4c280244c580092b8f06858f70316b949c32",
                "0fdad0f51b26f335c20535e774597bb8ee6a407f82d0609d1f26f488ea3123",
                "01dffd61a19751e050cb66e88545d59da1a9825ac2019f5b256c63545a812a9d0bde"};
            string[] inputs2 = {"0b159b7283e51f8b",
                "0ff135f6c6",
                "01232b98164297f017f4b0840ccbc648ca20167eddc0bc1b156",
                "07b06f577de31599e535a552ba0b9c1c7a46a8c9e8d660f9277f3907129a",
                "0a69fc4d5736a49d9b2a40c7a08c569a1607007d5174b5f222909b5d39afbad90b5"};
            for (int i = 0; i < 5; i++)
            {
                 uint powerOf = 13;
                 var s1 = inputs1[i];
                 var s2 = inputs2[i];


                 var num1 = new LongInt(s1);
                 var num2 = new LongInt(s2);

                 var numb1 = BigInteger.Parse(s1, NumberStyles.AllowHexSpecifier);
                 var numb2 = BigInteger.Parse(s2, NumberStyles.AllowHexSpecifier);

                 var sum = num1 + num2;
                 var sub = num1 - num2;
                 var mult = num1 * num2;
                 var div1 = num1 / num2;
                 var div2 = num1 % num2;
                 var pow = LongInt.Pow(num1, new LongInt(powerOf));

                 var sumb = numb1 + numb2;
                 var subb = numb1 - numb2;
                 var multb = numb1 * numb2;
                 var div1b = numb1 / numb2;
                 var div2b = numb1 % numb2;
                 var powb = BigInteger.Pow(numb1, (int)powerOf);

                 var str = "";
                 str += $"A = {s1}, B = {s2}\n";
                 str += $"Sum of A and B: {Convertor.NumberIntoHexString(sum.number,true)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(sum.number) == sumb.ToString("X").TrimStart('0')} \n";
                 str += $"Sub of A and B : {Convertor.NumberIntoHexString(sub.number, true)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(sub.number) == subb.ToString("X").TrimStart('0')}\n";
                 str += $"Mult of A and B: {Convertor.NumberIntoHexString(mult.number, true)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(mult.number) == multb.ToString("X").TrimStart('0')}\n";
                 str += $"Division of A and B: Q = {Convertor.NumberIntoHexString(div1.number, true)}, is equal to BigInteger: {Convertor.NumberIntoHexString(div1.number) == div1b.ToString("X").TrimStart('0')}\n";
                 str += $"and R =  {Convertor.NumberIntoHexString(div2.number, true)} is equal to BigInteger: {Convertor.NumberIntoHexString(div2.number) == div2b.ToString("X").TrimStart('0')}\n";
                 str += $"power of A and {powerOf}:  {Convertor.NumberIntoHexString(pow.number, true)}  is equal to BigInteger: {Convertor.NumberIntoHexString(pow.number) == powb.ToString("X").TrimStart('0')}\n";
                 Console.WriteLine(str);
            }
        }
    }
}