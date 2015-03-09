using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;
using System.Collections;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input) {
            if (input == "")
                return 0;

            if (StartsWith(input))
            {
                input = StringSanitizer(input);
            }
            var s = SplitStrings(input);

            var convertednumbers = Convertednumbers(s);

            ThrowNegativeNumbersException(convertednumbers);

            return SumIntegers(convertednumbers);
        }

        private static void ThrowNegativeNumbersException(List<int> convertednumbers) {
            List<int> negativenumbers = convertednumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
                var ex = new NegativesNotAllowedException(negativenumbers.ToArray());

                throw ex;
            }
        }

        private static string StringSanitizer(string input) {
            var splitnewline = input.Split('\n');
            input = splitnewline[1];

            var removeslash = Removeslash(splitnewline);
         
            var removebrackets = Removebrackets(removeslash);
            
            var customdelimter = Customdelimter(removebrackets);

            foreach (var delimiter in customdelimter)
            {
                input = input.Replace(delimiter, ",");
            }

            
            return input;
            
        }

        private static string[] Customdelimter(string removebrackets) {
            var customdelimter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return customdelimter;
        }

        private static string Removebrackets(string removeslash) {
            var removebrackets = removeslash.Replace('[', ',').Replace(']', ',');
            return removebrackets;
        }

        private static string Removeslash(string[] splitnewline) {
            var removeslash = splitnewline[0].Substring(2);
            return removeslash;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static int SumIntegers(List<int> convertednumbers) {
            return convertednumbers.Where(x=>x<=1000).Sum();
        }

        private static List<int> Convertednumbers(string[] s) {
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
