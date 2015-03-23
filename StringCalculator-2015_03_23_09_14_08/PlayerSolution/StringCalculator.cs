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
            if (EmptyString(input))
                return 0;

            if (StartsWith(input))
            {
                input = StringSanitizer(input);
            }

            var s = SplitString(input);
            
            var convertedNumbers = CovertedNumbers(s);

            ThrowNegativesNotAllowedException(convertedNumbers);

            return SumIntegers(convertedNumbers);
        }

        private static void ThrowNegativesNotAllowedException(List<int> convertedNumbers) {
            List<int> negativenumbers = convertedNumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
                throw new NegativesNotAllowedException(negativenumbers.ToArray());
            }
        }

        private static string StringSanitizer(string input) {
            var splitnewline = input.Split('\n');
            input = splitnewline[1];

            var removeslashes = splitnewline[0].Substring(2);

            var removebrackets = removeslashes.Replace('[', ',').Replace(']', ',');

            var customdelimter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <customdelimter.Length; i++)
            {
                input = input.Replace(customdelimter[i], ",");

                
            }
            
            
            return input;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static int SumIntegers(List<int> convertedNumbers) {
            return convertedNumbers.Where(x=>x<=1000).Sum();
        }

        private static List<int> CovertedNumbers(string[] s) {
            List<int> covertedNumbers = s.Select(x => Int32.Parse(x)).ToList();
            return covertedNumbers;
        }

        private static string[] SplitString(string input) {
            string[] s = input.Split(',','\n');
            return s;
        }

        private static bool EmptyString(string input) {
            return input == "";
        }
    }
}
