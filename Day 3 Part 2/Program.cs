using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = "Input.txt";
            using (StreamReader sr = new StreamReader(file))
            {
                string input = sr.ReadToEnd();

                string pattern = @"(do\(\))|(don't\(\))|(mul\((\d{1,3}),(\d{1,3})\))";

                bool enable = true;

                var total = 0;

                MatchCollection matches = Regex.Matches(input, @"(do\(\))|(don't\(\))|(mul\((\d{1,3}),(\d{1,3})\))");

                foreach (Match match in matches)
                {
                    if (match.Groups[1].Value == "do()")
                    {
                        enable = true;
                    }
                    else if (match.Groups[2].Value == "don't()") 
                    {
                        enable = false;
                    }
                    else if (match.Groups[3].Value != null && enable)
                    {
                        var x = int.Parse(match.Groups[4].Value);
                        var y = int.Parse(match.Groups[5].Value);

                        total += x * y;
                    }
                }

                Console.WriteLine(total.ToString());
            }
        }
    }
}

/* Regex Pattern Explained Below:

(do\(\)) 
    do matches the characters 'do'
    \( matches the character '('
    \) matches the character ')'

(don't\(\)) 
    don't matches the characters 'don't''
    \( matches the character '('
    \) matches the character ')'


The mul matches the characters mul literally (case sensitive)

The \( matches the character '('

The \d matches a digit zero through nine in any script except ideographic scripts

The {1,3} matches the previous token between 1 and 3 times, as many times as possible, giving back as needed

The , matches the character ',' 

The \) matches the character ')'

*/


