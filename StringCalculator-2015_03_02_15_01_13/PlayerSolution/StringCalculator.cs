using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public class NegativesNOTAllowed : Exception
        {
            public List<int> NegativeNumbers { get; set; } 
        }


        public int Add(string input) {
            if (input == "")
                return 0;

            if (StartsWith(input))
            {
                input = StringSanitizer(input);
            }

            var s = SpltiStrings(input);

            var negatives = GetNegatives(s);

            if (negatives.Any())
            {
                CheckNegatives(negatives);
            }
            var getnumberslessthan1000 = Getnumberslessthan1000(s);

            return Sum(getnumberslessthan1000);

           
        }

        private static List<int> Getnumberslessthan1000(string[] s) {
            List<int> numbers = ConvertString(s);
            List<int> getnumberslessthan1000 = new List<int>();
            foreach (var item in numbers)
            {
                if (item <= 1000)
                {
                    getnumberslessthan1000.Add(item);
                }
            }
            return getnumberslessthan1000;
        }

        private static void CheckNegatives(List<int> negatives) {
            var ex = new NegativesNOTAllowed();
            ex.NegativeNumbers = negatives.ToList();
            throw ex;
        }

        private static List<int> GetNegatives(string[] s) {
            List<int> negatives = new List<int>();
            negatives = ConvertString(s).Where(x => x < 0).ToList();
            return negatives;
        }

        private static string StringSanitizer(string input) {
            //string[] splitnewline = input.Split('\n');
            //input = splitnewline[1];
            //var withoutslash = splitnewline[0].Substring(2);
            //var customdelimiter = withoutslash.Replace('[', ',').Replace(']', ',');
            //var delimiter = customdelimiter.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


            //foreach (var del in delimiter)
            //{
            //    input = input.Replace(del, ",");
            //}

            //return input;
            var splitnewline = input.Split('\n');
            input = splitnewline[1];
            var withoutslash = splitnewline[0].Substring(2);


            var customdelimiter = withoutslash.Replace("[", ",").Replace("]", ",");
            var delimitierlist = customdelimiter.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var delimiter in delimitierlist)
            {
                input = input.Replace(delimiter, ",");
            }
            return input;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private int Sum(List<int> convertString) {
            return convertString.Sum();
        }

        private static List<int> ConvertString(string[] s) {
            return s.ToList().Select(x => Int32.Parse(x)).ToList();
        }

        private static string[] SpltiStrings(string input) {
            char[] c = new[] {',','\n'};
            string[] s = input.Split(c,StringSplitOptions.RemoveEmptyEntries);
            return s;
        }
    }
}
