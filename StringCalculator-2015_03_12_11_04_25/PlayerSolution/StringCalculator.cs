using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

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

            ThrowNegativeNumbers(convertednumbers);

            return SumIntegers(convertednumbers);
        }

        private static string StringSanitizer(string input) {
            var spiltnewline = Spiltnewline(input);

            input = spiltnewline[1];

            var withoutslash = WithoutSlash(spiltnewline);

            var withoutbrackets = withoutslash.Replace('[', ',').Replace(']', ',');

            var customdelimiter = withoutbrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);


            foreach (var delimiter in customdelimiter)
            {
                input = input.Replace(delimiter, ",");
  
            }
            return input;
        }

        private static void ThrowNegativeNumbers(List<int> convertednumbers) {
            List<int> negativenumbers = convertednumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
                throw new NegativesNotAllowedException(negativenumbers.ToArray());
            }
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static string WithoutSlash(string[] spiltnewline) {
            var customdelimiter = spiltnewline[0].Substring(2);
            return customdelimiter;
        }

        private static string[] Spiltnewline(string input) {
            var spiltnewline = input.Split('\n');
            return spiltnewline;
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
