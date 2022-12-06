using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode
{
    internal class Day4 : Puzzle
    {
        private List<int[][]> ParseInput(bool firstPart)
        {
            var parsedInput = new List<int[][]>();

            foreach(var row in Input)
            {
                var parts = row.Split(",");
                var first = parts[0].Split("-");
                var second = parts[1].Split("-");

                parsedInput.Add(new int[][] { new int[] { int.Parse(first[0]), int.Parse(first[1]) }, new int[] { int.Parse(second[0]), int.Parse(second[1]) } });
            }

            return parsedInput;
        }


        public override string Part1()
        {
            var score = 0;
            foreach (var pair in ParseInput(true))
            {
                var first = Enumerable.Range(pair[0][0], pair[0][1] - pair[0][0] + 1);
                var second = Enumerable.Range(pair[1][0], pair[1][1] - pair[1][0] + 1);

                var intersection = first.Intersect(second);
                if (intersection.Count() == Math.Min(first.Count(), second.Count()))
                {
                    score++;
                }
            }
            return score.ToString();
        }
        public override string Part2()
        {
            var score = 0;
            foreach (var pair in ParseInput(true))
            {
                var first = Enumerable.Range(pair[0][0], pair[0][1] - pair[0][0] + 1);
                var second = Enumerable.Range(pair[1][0], pair[1][1] - pair[1][0] + 1);

                var intersection = first.Intersect(second);
                if (intersection.Any())
                {
                    score++;
                }
            }
            return score.ToString();
        }
    }
}
