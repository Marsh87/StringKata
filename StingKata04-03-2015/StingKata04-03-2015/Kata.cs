using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingKata04_03_2015
{
    public class NegativesNotAllowed : Exception
    {
       public List<int> negativenumbers { get; set; } 
    }
    public partial class Kata
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
            var getnegativenumbers = Getnegativenumbers(convertednumbers);
            if (Any(getnegativenumbers))
            {
                ThrowNegativesNotAllowedException(getnegativenumbers);
            }

            return SumIntegers(convertednumbers);


        }

        private static void ThrowNegativesNotAllowedException(List<int> getnegativenumbers) {
            var ex = new NegativesNotAllowed();
            ex.negativenumbers = getnegativenumbers;
            throw ex;
        }

        private static List<int> Getnegativenumbers(List<int> convertednumbers) {
            List<int> getnegativenumbers = convertednumbers.Where(x => x < 0).ToList();
            return getnegativenumbers;
        }

        private static bool Any(List<int> getnegativenumbers) {
            return getnegativenumbers.Any();
        }

        private static string StringSanitizer(string input) {

            var splitnewline = input.Split('\n');
            input = splitnewline[1];

            var withoustslash = splitnewline[0].Substring(2);
            var replacebrackets = withoustslash.Replace("[", ",").Replace("]", ",");
            var delimieter = replacebrackets.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);


            foreach (var del in delimieter)
            {

                input = input.Replace(del, ",");
            }
            


            return input;
        }

        private static bool StartsWith(string input) {
            return input.StartsWith("//");
        }

        private static int SumIntegers(List<int> convertednumbers) {
            return convertednumbers.Where(x=>x<=1000).ToList().Sum();
        }

        private static List<int> Convertednumbers(string[] s) {
            List<int> convertednumbers = s.ToList().Select(x => Int32.Parse(x)).ToList();
            return convertednumbers;
        }

        private static string[] SplitStrings(string input) {
            char[] c = new[] {',','\n'};
            string[] s = input.Split(c);
            return s;
        }
    }
}
