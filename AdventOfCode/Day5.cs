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
    internal class Day5 : Puzzle
    {
        private (List<Stack<string>> stacks, IEnumerable<int[]> instructions) ParseInput()
        {
            var parsedInput = new List<int[][]>();

            var stacks = ParseStacks();
            var instructions = ParseInstructions();
            return (stacks, instructions);
        }

        private IEnumerable<int[]> ParseInstructions()
        {
            return Input.Skip(10).Select(row =>
            {
                return row.Replace("move ", String.Empty).Replace(" from ", ",").Replace(" to ", ",").Split(",").Select(v => int.Parse(v)).ToArray();
            });
        }

        private List<Stack<string>> ParseStacks()
        {
            var stacks = Enumerable.Range(0, 9).Select(_ => new Stack<string>()).ToList();

            for (var row = 7; row >= 0; row--)
            {
                for (var i = 0; i < 9; i++)
                {
                    var stackVal = Input[row].Substring(i * 4, 3).Replace("[", "").Replace("]", "").Trim();
                    if (stackVal != string.Empty)
                    {
                        stacks[i].Push(stackVal);
                    }
                }
            }

            return stacks;
        }

        public string Execute(bool firstPart)
        {
            var parsedInput = ParseInput();
            foreach (var instruction in parsedInput.instructions)
            {
                var toMove = Enumerable.Range(0, instruction[0]).Select(_ => parsedInput.stacks[instruction[1] - 1].Pop()).ToList();
                if (!firstPart)
                {
                    toMove.Reverse();
                }
                foreach (var item in toMove)
                {
                    parsedInput.stacks[instruction[2] - 1].Push(item);
                }
            }

            return string.Join("", parsedInput.stacks.Select(stack => stack.Pop()));
        }

        public override string Part1()
        {
            return Execute(true);
        }
        public override string Part2()
        {
            return Execute(false);
        }
    }
}
