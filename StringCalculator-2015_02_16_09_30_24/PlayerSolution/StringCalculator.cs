using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {  
       
        public int Add(string input) {

            if (input == "")
                return 0;

            
            input = Sanitizer(input);

            string[] s = Spiltstring(input);
            for (int i = 0; i <s.Count(); i++)
            {
                if (Convert.ToInt32(s[i])<0)
                {
                    throw new NegativesNotAllowedException();
                }

                
            }
 
       return  Sum(Spiltstring(input));
           
            
            
            
 
            
            




        }

        private static char Defaultseperator {
            get { return ','; }
        }

        public int Addtwonumbers(string input) {
            int sum = 0;
            string one = input.Substring(0, 1);
            string two = input.Substring(2, 1);
          return  sum = Convert.ToInt32(one) + Convert.ToInt32(two);
            
        }

        public string[]  Spiltstring(string input) {
            char[] c = { Defaultseperator,'\n' };

           string[] s = input.Split(c);
            return s;

        }

        public int Sum(string[] s) {
            int sum = 0;
            for (int i = 0; i < s.Count(); i++)
            {
                sum += Convert.ToInt32(s[i]);

            }

            return sum;
            
        }

        public string Sanitizer(string input) {
            if (input.StartsWith("//"))
            {
                input = input.Replace(input[2], Defaultseperator);
                input = input.Substring(4);
            }
            return input;
        }

    }
}
