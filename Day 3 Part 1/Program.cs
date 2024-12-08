using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Day_3_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = "Input.txt";
            using (StreamReader sr = new StreamReader(file))
            {
                string input = sr.ReadToEnd();

                string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

                var total = 0;

                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches) 
                {
                    var x = int.Parse(match.Groups[1].Value);
                    var y = int.Parse(match.Groups[2].Value);

                    total += x * y;
                }

                Console.WriteLine(total.ToString());
            }
        }
    }
}


/* Regex Pattern Explained Below:

The mul matches the characters mul literally (case sensitive)

The \( matches the character '('

The \d matches a digit zero through nine in any script except ideographic scripts

The {1,3} matches the previous token between 1 and 3 times, as many times as possible, giving back as needed

The , matches the character ',' 

The \) matches the character ')'

*/

