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
            if(input=="")
            return 0;


            if (input.StartsWith("//"))
            {
                input = StringSanitizer(input);
            }

            var s = SplitStrings(input);

            var convertedNumbers = ConvertedNumbers(s);

            ThrowNegativeNumbersException(convertedNumbers);


            return SumIntegers(convertedNumbers);

        }

        private static void ThrowNegativeNumbersException(List<int> convertedNumbers) {
            List<int> NegativeNumbers = convertedNumbers.Where(x => x < 0).ToList();
            if (NegativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(NegativeNumbers.ToArray());
            }
        }

        private static string StringSanitizer(string input) {
            var splitnewline = input.Split('\n');

            input = splitnewline[1];

            var removeslashes = splitnewline[0].Substring(2);


            var removebraackets = removeslashes.Replace('[', ',').Replace(']', ',');

            var customdelimiter = removebraackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < customdelimiter.Length; i++)
            {
                input = input.Replace(customdelimiter[i], ",");
            }

            
            return input;
        }

        private static int SumIntegers(List<int> convertedNumbers) {
            return convertedNumbers.Where(x=>x<=1000).Sum();
        }

        private static List<int> ConvertedNumbers(string[] s) {
            List<int> convertedNumbers = s.Select(x => Int32.Parse(x)).ToList();
            return convertedNumbers;
        }

        private static string[] SplitStrings(string input) {
            string[] s = input.Split(',', '\n');
            return s;
        }
    }
}
