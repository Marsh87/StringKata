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

            var convertednumbers = ConvertedStringNumbers(s);
     
            ThrowNegativeNotAllowedException(convertednumbers);

            return SumIntegers(convertednumbers);
        }

        private static void ThrowNegativeNotAllowedException(IEnumerable<int> convertednumbers) {
            var negativenumbers = convertednumbers.Where(x => x < 0).ToArray();
            if (negativenumbers.Any())
            {
                var ex = new NegativesNotAllowedException(negativenumbers);

                throw ex;
            }
        }

        private static string StringSanitizer(string input) {
            string newinput;
            var splitnewline = SplitInputOnNewline(input, out newinput);

            var withoutslash = RemoveSlash(splitnewline);
           
            var delimiters = GetDelimiter(withoutslash);

            newinput=RemoveDelimiters(delimiters, newinput);
            
            
            
            return newinput;
        }

        private static string RemoveDelimiters(string[] delimiters, string newinput) {
            var result = newinput;
            foreach (var delimiter  in  delimiters)
            {
               result =result.Replace(delimiter, ",");
            }
            return result;
        }

        private static string[] GetDelimiter(string withoutslash) {
            var replacebrackets = withoutslash.Replace('[', ',').Replace(']', ',');
            var delimiter = replacebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return delimiter;
        }

        private static string RemoveSlash(string[] splitnewline) {
            var withoutslash = splitnewline[0].Substring(2);
            return withoutslash;
        }

        private static string[] SplitInputOnNewline(string input, out string newinput) {
            var splitnewline = input.Split('\n');
            newinput = splitnewline[1];
            return splitnewline;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static int SumIntegers(IEnumerable<int> convertednumbers) {
            return convertednumbers.Where(x=>x<=1000).Sum();
        }

        private static IEnumerable<int> ConvertedStringNumbers(string[] s) {
            var convertednumbers = s.Select(x => Int32.Parse(x)).ToList();
            return convertednumbers;
        }

        private static string[] SplitStrings(string input) {
            char[] c = new[] {',','\n'};
            string[] s = input.Split(c);
            return s;
        }
    }
}
