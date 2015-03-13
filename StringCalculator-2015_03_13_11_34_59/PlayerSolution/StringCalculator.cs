using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input) {
            if (input == "")
                return 0;

            if (input.StartsWith("//"))
            {
                input = StringSanitizer(input);
            }

            var s = SplitStrings(input);


            var convertednumbers = ConvertNumbers(s);
            
            ThrowNegativesNotAllowedException(convertednumbers);

            return SumNumbers(convertednumbers);
        }

        private static void ThrowNegativesNotAllowedException(List<int> convertednumbers) {
            List<int> negativenumbers = convertednumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
                throw new NegativesNotAllowedException(negativenumbers.ToArray());
            }
        }

        private static string StringSanitizer(string input) {
            var splitnewline = input.Split('\n');
            input = splitnewline[1];
            var withoutslash = splitnewline[0].Substring(2);
            var removebrackets = withoutslash.Replace('[', ',').Replace(']', ',');
            var customdelimiter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);


            foreach (var delimiter in customdelimiter)
            {
                input = input.Replace(delimiter, ",");

                
            }
            return input;
        }

        private static int SumNumbers(List<int> convertednumbers) {
            return convertednumbers.Where(x=>x<=1000).Sum();
        }

        private static List<int> ConvertNumbers(string[] s) {
            List<int> convertednumbers = s.Select(x => Int32.Parse(x)).ToList();
            return convertednumbers;
        }

        private static string[] SplitStrings(string input) {
            char[] c = new[] {',','\n'};
            string[] s = input.Split(c);
            return s;
        }
    }
}
