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

            if (StartsWith(input))
            {
                input = StringSanitizer(input);
            }
            var s = SplitStrings(input);

            var convertednumbers = Convertednumbers(s);

            
            ThrowNegativesNotAllowedException(convertednumbers);

            return SumIntegers(convertednumbers);

        }

        private static void ThrowNegativesNotAllowedException(List<int> convertednumbers) {
            List<int> negativenumbers = convertednumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
                throw new NegativesNotAllowedException(negativenumbers.ToArray());
            }
        }

        private static string StringSanitizer(string input) {
            var splitnewline = Splitnewline(input);
            input = splitnewline[1];

            var removeslashes = Removeslashes(splitnewline);

            var removebrackets = removeslashes.Replace('[', ',').Replace(']', ',');

            var customdelimiter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < customdelimiter.Length; i++)
            {
                input = input.Replace(customdelimiter[i], ",");

                
            }

            return input;
        }

        private static string Removeslashes(string[] splitnewline) {
            var removeslashes = splitnewline[0].Substring(2);
            return removeslashes;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static string[] Splitnewline(string input) {
            var splitnewline = input.Split('\n');
            return splitnewline;
        }

        private static int SumIntegers(List<int> convertednumbers) {
            return convertednumbers.Where(x=>x<=1000).Sum();
        }

        private static List<int> Convertednumbers(string[] s) {
            List<int> convertednumbers = s.Select(x => Int32.Parse(x)).ToList();
            return convertednumbers;
        }

        private static string[] SplitStrings(string input) {
            string[] s = input.Split(',','\n');
            return s;
        }
    }
}
