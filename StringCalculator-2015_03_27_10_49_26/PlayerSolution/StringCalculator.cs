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

            var splitStrings = SplitStrings(input);

            var converteListNumbersList = ConverteListNumbersList(splitStrings);

            List<int> negativeNumberList = converteListNumbersList.Where(x =>x < 0).ToList();

            if (negativeNumberList.Any())
            {
                throw new NegativesNotAllowedException(negativeNumberList.ToArray());
            }


            return SumNumbers(converteListNumbersList);




        }

        private static string StringSanitizer(string input) {
            var splitnewline = Splitnewline(input);

            input = splitnewline[1];

            var withoutslash = Withoutslash(splitnewline);

            var removebrackets = withoutslash.Replace('[', ',').Replace(']', ',');

            var customdelimiter = removebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i <customdelimiter.Length; i++)
            {

                input = input.Replace(customdelimiter[i], ",");
            }

            
            
            return input;
        }

        private static string Withoutslash(string[] splitnewline) {
            var withoutslash = splitnewline[0].Substring(2);
            return withoutslash;
        }

        private static string[] Splitnewline(string input) {
            var splitnewline = input.Split('\n');
            return splitnewline;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static int SumNumbers(List<int> converteListNumbersList) {
            return converteListNumbersList.Where(x=>x<=1000).Sum();
        }

        private static List<int> ConverteListNumbersList(string[] splitStrings) {
            List<int> converteListNumbersList = splitStrings.Select(x => Int32.Parse(x)).ToList();
            return converteListNumbersList;
        }

        private static string[] SplitStrings(string input) {
            string[] splitStrings = input.Split(',','\n');
            return splitStrings;
        }

        private static bool EmptyString(string input) {
            return input == "";
        }
    }
}
