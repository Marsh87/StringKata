using System;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input) {

            if (input.Length == 3)
            {
                int one = Int32.Parse(input.Substring(0, 1));
                int two = Int32.Parse(input.Substring(2, 1));
                int sum = one + two;
                return sum;

            }

            if(input=="")
            return 0;
            return  Int32.Parse(input);

        }
    }
}
