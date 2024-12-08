﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var file = "Input.txt";

            using (StreamReader sr = new StreamReader(file))
            {
                var total = 0;
                List<int[]> reports = new List<int[]>();

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    reports.Add(line.Split(' ').Select(int.Parse).ToArray()); 
                }

                foreach (var report in reports) 
                {
                    if (isSafe(report))
                    {
                        total++;
                    }
                }

                Console.WriteLine(total);
            }
        }

        public static bool isSafe(int[] levels)
        {

            var goingUp = levels[1] > levels[0];

            for( var i = 1; i < levels.Length; i++)
            {
                var distance = levels[i] - levels[i - 1];

                if (!goingUp)
                {
                    distance = -distance;
                }

                if(distance >= 1 && distance <= 3)
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
