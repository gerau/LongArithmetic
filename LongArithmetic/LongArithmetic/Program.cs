namespace LongArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "71345713475716345adcadac";
            Console.WriteLine(str);
            var array = Converter.ConvertHexIntoNumber(str);
            array = array.Reverse().ToArray();
            Console.Write("\n");
            var stre = Converter.ConvertNumberIntoHex(array);
            Console.WriteLine(stre);
        }
    }
}