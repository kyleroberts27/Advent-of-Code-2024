using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Day_1
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
                    }

                }

                locationIDLeftList.Sort();

                locationIDRightList.Sort();

                var total = 0;

                for (int i = 0; i < locationIDLeftList.Count; i++)
                {
                    total += Math.Abs(locationIDLeftList[i] - locationIDRightList[i]);
                }

                Console.WriteLine(total);


            }
        }

    }
}
