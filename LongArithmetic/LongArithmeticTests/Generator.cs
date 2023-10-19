using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LongArithmeticTests
{
    internal static class Generator
    {
        public static string GenerateNewHex(int n)
        {
            var rand = new Random();
            var output = "";
            for(int i =0 ; i < n - 1; i++)
            {
                var r = rand.Next(0,15);
                output += Convertor.DigitIntoHexSymbol((uint)r);
            }
            output += Convertor.DigitIntoHexSymbol((uint)rand.Next(1, 15));
            return output;
        }
    }
}
