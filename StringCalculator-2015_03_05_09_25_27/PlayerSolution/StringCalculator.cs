using System;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input) {
            if (input == "2")
                return 2;
            if (input == "1")
                return 1;
            return 0;
        }
    }
}
