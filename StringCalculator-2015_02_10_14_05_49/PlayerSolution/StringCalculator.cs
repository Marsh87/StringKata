using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        private const char DefultSeperator = ',';
        private const char NewLine = '\n';


        public int Add(string input) {
            if (input == "")
                return 0;
            if (IfStartsWith(input))
                
                    input = Sanitizer(input);
                
            CheckNegative(input);


            return Sum(SplitString(input));
        }

        private string[] SplitString(string input) {
            char[] c = {NewLine, DefultSeperator};

            string[] s = input.Split(c);
            var list = new List<string>();            
            return s;
        }

        private void CheckNegative(string input) {
            string[] s = SplitString(input);
            for (int i = 0; i < s.Count(); i++)
            {
                if (Convert.ToInt32(s[i]) < 0)
                    throw new NegativesNotAllowedException();
            }
        }

        private string Sanitizer(string input) {
            char customDelimiter = input[2];
            input = input.Replace(customDelimiter, DefultSeperator);
            input = input.Substring(4);
            return input;
        }

        private int Sum(string[] s) {
            int sum = 0;

            for (int i = 0; i < s.Count(); i++)
            {
                sum += ConvertInput(s[i]);
            }

            return sum;
        }

        private int ConvertInput(string input) {
            return Convert.ToInt32(input);
        }

        private bool IfStartsWith(string input) {
            bool startsWith = input.Contains("//");
            return startsWith;
        }
    }
}