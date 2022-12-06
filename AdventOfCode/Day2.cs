using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode
{
    internal class Day2 : Puzzle
    {
        public Day2() : base(2) { }

        private List<int[]> ParseInput(bool firstPart)
        {
            var total = new List<int[]>();
            foreach (var input in Input)
            {
                var row = input.Split(" ");
                var ret = new int[2];
                switch (row[0])
                {
                    case "A":
                        ret[0] = 1;
                        break;
                    case "B":
                        ret[0] = 2;
                        break;
                    case "C":
                        ret[0] = 3;
                        break;

                }
                switch (row[1])
                {
                    case "X":
                        ret[1] = firstPart ? 1 : -1;
                        break;
                    case "Y":
                        ret[1] = firstPart ? 2 : 0;
                        break;
                    case "Z":
                        ret[1] = firstPart ? 3 : 1;
                        break;

                }
                total.Add(ret);
            }

            return total;
        }

        private int GetScore(int[] round)
        {
            if (round[0] == round[1])
            {
                return round[1] + 3;
            }

            var shifted = round[1] == 1 ? 3 : round[1] - 1;
            if (shifted == round[0])
            {
                return round[1] + 6;
            }

            return round[1] + 0;
        }

        public override string Part1()
        {
            var score = 0;
            foreach (var round in ParseInput(true))
            {
                score += GetScore(round);
            }
            return score.ToString();
        }
        public override string Part2()
        {
            var score = 0;
            foreach (var round in ParseInput(false))
            {
                round[1] = round[0] + round[1];
                if (round[1] == 0)
                {
                    round[1] = 3;
                } 
                if (round[1] == 4)
                {
                    round[1] = 1;
                }
                score += GetScore(round);
            }
            return score.ToString();
        }
    }
}
