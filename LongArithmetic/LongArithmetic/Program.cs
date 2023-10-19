using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;

namespace LongArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs1 = { "077f612aec34ab3905fdca712aecde12394834",
                "0d8096aa33c5e6a93916fb36b3d713beb8e2276433f89bf7f5d6974021695720",
                "0b10037272cf8a43f4c280244c580092b8f06858f70316b949c389f2b8fe2b76d0f9ca21b898",
                "0fdad0f51b26f335c20535e774597bb8ee6a407f82d0609d1f26f488ea3aed0de2318a984fcd9b5c6",
                "01dffd61a19751e050cb66e88545d59da1a9825ac2019f5b256c63545a812a9d0bde827860d639c8a5977c64a8c9a1e17805b"};
            string[] inputs2 = {"0b159b7283e51f8bec6a01189c6735334",
                "0ff135f6c6311a32e28e26cbf05f923bc71bd0b42c64dd1f50ba9282",
                "01232b98164297f017f4b0840ccbc648ca20167eddc0bc1b156a1646a4848",
                "07b06f577de31599e535a552ba0b9c1c7a46a8c9e8d660f9277f3907129a7fee58d6ea3",
                "0a69fc4d5736a49d9b2a40c7a08c569a1607007d5174b5f222909b5d39afbad90b519d1f9f131273ca88f876e57aecdc88"};
            for (int i = 0; i < 5; i++)
            {
                int powerOf = 50;
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
                var pow = LongInt.Pow(num1, new LongInt(50));

                var sumb = numb1 + numb2;
                var subb = numb1 - numb2;
                var multb = numb1 * numb2;
                var div1b = numb1 / numb2;
                var div2b = numb1 % numb2;
                var powb = BigInteger.Pow(numb1, 50);

                var str = "";
                str += $"A = {s1}, B = {s2}\n";
                str += $"Sum of A and B: {Convertor.NumberIntoHexString(sum.number)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(sum.number) == sumb.ToString("X").TrimStart('0')} \n{sumb.ToString("X")}\n";
                str += $"Sub of A and B : {Convertor.NumberIntoHexString(sub.number)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(sub.number) == subb.ToString("X").TrimStart('0')} \n{subb.ToString("X")}\n";
                str += $"Mult of A and B: {Convertor.NumberIntoHexString(mult.number)} is equal to BigInteger operations: {Convertor.NumberIntoHexString(mult.number) == multb.ToString("X").TrimStart('0')} \n {multb.ToString("X")}\n";
                str += $"Division of A and B: Q = {Convertor.NumberIntoHexString(div1.number)}, is equal to BigInteger: {Convertor.NumberIntoHexString(div1.number) == div1b.ToString("X").TrimStart('0')}\n {div1b.ToString("X")}\n";
                str += $"and R =  {Convertor.NumberIntoHexString(div2.number)} is equal to BigInteger: {Convertor.NumberIntoHexString(div2.number) == div2b.ToString("X")}\n{div2b.ToString("X").TrimStart('0')}\n";
                str += $"power of A and {powerOf}:  {Convertor.NumberIntoHexString(pow.number)}  is equal to BigInteger: {Convertor.NumberIntoHexString(pow.number) == powb.ToString("X").TrimStart('0')}\n{powb.ToString("X")}\n";
                Console.WriteLine(str);
            }
        }
    }
}