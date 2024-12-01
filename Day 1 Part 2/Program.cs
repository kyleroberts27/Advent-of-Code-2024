using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = "Input.txt";
            using (StreamReader sr = new StreamReader(file))
            {
                string line;

                var locationIDLeftList = new List<int>();

                var locationIDRightList = new List<int>();

                var locationIDLeftCount = new Dictionary<int, int>();

                var locationIDRightCount = new Dictionary<int, int>();

                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                    if (int.TryParse(parts.First(), out var number))
                    {
                        locationIDLeftList.Add(number);
                    }

                    if (int.TryParse(parts.Last(), out number))
                    {
                        locationIDRightList.Add(number);
                        if (locationIDRightCount.ContainsKey(number))
                        {
                            locationIDRightCount[number]++;
                        }
                        else 
                        {
                            locationIDRightCount[number] = 1;
                        }
                    }

                }

                var total = 0;

                for (int i = 0; i < locationIDLeftList.Count; i++)
                {
                    if (locationIDRightCount.ContainsKey(locationIDLeftList[i]))
                    {
                        total += locationIDLeftList[i] * locationIDRightCount[locationIDLeftList[i]];
                    }
                }

                Console.WriteLine(total);
            }
        }
    }
}
