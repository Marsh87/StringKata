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
            if (IfEmptyString(input))
            {
                return 0;
            }

            if (input.StartsWith("//"))
            {
                input = StringSanitizer(input);
            }
            var s = SplitStrings(input);

            var convertedNumbers = ConvertedNumbers(s);

            ThrowNegativesNotAllowedException(convertedNumbers);

            return SumNumbers(convertedNumbers);


        }

        private static void ThrowNegativesNotAllowedException(List<int> convertedNumbers) {
            var NegativeNumbers = GetNegativeNumbers(convertedNumbers);
            if (NegativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(NegativeNumbers.ToArray());
            }
        }

        private static List<int> GetNegativeNumbers(List<int> convertedNumbers) {
            List<int> NegativeNumbers = convertedNumbers.Where(x => x < 0).ToList();
            return NegativeNumbers;
        }

        private static string StringSanitizer(string input) {
            var splitnewline = Splitnewline(input);

            input = splitnewline[1];

            var removeslashes = Removeslashes(splitnewline);

            var removebrackets = removeslashes.Replace('[', ',').Replace(']', ',');

            var customdelimiter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);



            for (int i = 0; i <customdelimiter.Length; i++)
            {

                input = input.Replace(customdelimiter[i], ",");

            }



            return input;
        }

        private static string Removeslashes(string[] splitnewline) {
            var removeslashes = splitnewline[0].Substring(2);
            return removeslashes;
        }

        private static string[] Splitnewline(string input) {
            var splitnewline = input.Split('\n');
            return splitnewline;
        }

        private static int SumNumbers(List<int> convertedNumbers) {
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

        private static bool IfEmptyString(string input) {
            return input=="";
        }
    }
}
