using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input) {
            
            if (input.Length==3)
            {
                int sum = 0;
            int one = Convert.ToInt32(input.Substring(0, 1));
            int two = Convert.ToInt32(input.Substring(2, 1));
             sum = one + two;
             return sum;
        }

           

            if (input == "")
                return 0;


            return Int32.Parse(input);
        }
    }
}
