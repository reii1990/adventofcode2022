using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1 : Puzzle
    {
        public Day1() : base(1) { }

        private List<int> ParseInput()
        {
            var total = new List<int>();
            int current = 0; 
            foreach (var input in Input)
            {
                if (input == string.Empty)
                {
                    total.Add(current);
                    current = 0;
                } 
                else
                {
                    current += int.Parse(input);
                }
            }

            return total;
        }

        public override string Part1()
        {
            var parsedInput = ParseInput();
            return parsedInput.Max().ToString();
        }
        public override string Part2()
        {
            var parsedInput = ParseInput();
            parsedInput.Sort();
            parsedInput.Reverse();
            return parsedInput.Take(3).Sum().ToString();
        }
    }
}
