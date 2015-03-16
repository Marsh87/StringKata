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

            if (StartsWith(input))
            {
                input = StringSanitizer(input);
            }

            var s = SplitStrings(input);

            var convertednumbers = Convertednumbers(s);
            
            ThrowNegativesNotAllowed(convertednumbers);

            return SumIntegers(convertednumbers);
        }

        private static void ThrowNegativesNotAllowed(List<int> convertednumbers) {
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

            var replacebrackets = Replacebrackets(removeslashes);

            var customdelimiter = Customdelimiter(replacebrackets);


            foreach (var delimiter in customdelimiter)
            {
                input = input.Replace(delimiter, ",");
   
            }
            return input;
        }

        private static string[] Customdelimiter(string replacebrackets) {
            var customdelimiter = replacebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return customdelimiter;
        }

        private static string Replacebrackets(string removeslashes) {
            var replacebrackets = removeslashes.Replace('[', ',').Replace(']', ',');
            return replacebrackets;
        }


        private static string Removeslashes(string[] splitnewline) {
            var removeslashes = splitnewline[0].Substring(2);
            return removeslashes;
        }

        private static string[] Splitnewline(string input) {
            var splitnewline = input.Split('\n');
            return splitnewline;
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
