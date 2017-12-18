using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AOC2017.Challenge
{
    public class Day02
    {
        public int Checksum1(string input)
        {

            var lines = input.Split("\r\n");
            var sheet = new List<List<int>>();
            foreach (var line in lines)
            {
                var unparsedNum = line.Split().ToList();
                var row = (from unparsed in unparsedNum where !string.IsNullOrEmpty(unparsed) && !string.IsNullOrWhiteSpace(unparsed) select int.Parse(unparsed)).ToList();
                sheet.Add(row);
            }

            var sum = 0;
            foreach (var row in sheet)
            {
                var max = row.Max();
                var min = row.Min();
                var diff = max - min;
                sum += diff;
            }
            return sum;
        }

        public int Checksum2(string input)
        {
            var lines = input.Split("\r\n");
            var sheet = new List<List<int>>();
            foreach (var line in lines)
            {
                var unparsedNum = line.Split().ToList();
                var row = (from unparsed in unparsedNum where !string.IsNullOrEmpty(unparsed) && !string.IsNullOrWhiteSpace(unparsed) select int.Parse(unparsed)).ToList();
                sheet.Add(row);
            }

            var sum = 0;
            foreach (var row in sheet)
            {
                for (int firstIndex = 0; firstIndex < row.Count; firstIndex++)
                {
                    for (int test = 0; test < row.Count; test++)
                    {
                        if (firstIndex != test)
                        {
                            if (row[firstIndex] % row[test] == 0)
                            {
                                sum += (row[firstIndex] / row[test]);
                            }
                        }
                    }
                }  
            }
            return sum;
        }
    }
}