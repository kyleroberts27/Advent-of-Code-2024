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
