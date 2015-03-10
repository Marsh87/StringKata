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
           
            ThrowNegativesNotAllowedException(convertednumbers);

            return SumIntegers(convertednumbers);
        }

        private static void ThrowNegativesNotAllowedException(List<int> convertednumbers) {
            List<int> negativenumbers = convertednumbers.Where(x => x < 0).ToList();
            if (negativenumbers.Any())
            {
               
                var ex= new NegativesNotAllowedException(negativenumbers.ToArray());
                throw ex;
            }
        }

        private static string StringSanitizer(string input) {

            var splitnewline = Splitnewline(input);

            input = splitnewline[1];
            
            var witoutslash = Witoutslash(splitnewline);
            
            var withoutbrackets = Withoutbrackets(witoutslash);

            
            var customedelimiter = Customedelimiter(withoutbrackets);


            foreach (var delimiter in customedelimiter)
            {
                input = input.Replace(delimiter, ",");

            }
            return input;

        }

        private static string[] Customedelimiter(string withoutbrackets) {
            var customedelimiter = withoutbrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return customedelimiter;
        }

        private static string Withoutbrackets(string witoutslash) {
            var withoutbrackets = witoutslash.Replace('[', ',').Replace(']', ',');
            return withoutbrackets;
        }

        private static string Witoutslash(string[] splitnewline) {
            var witoutslash = splitnewline[0].Substring(2);
            return witoutslash;
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
