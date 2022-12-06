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
    internal class Day6 : Puzzle
    {
        private string ParseInput()
        {
            return Input[0];
        }

        public bool SequenceHasDuplicates(string input, int index, int sequenceLength)
        {
            var seq = input.Substring(index, sequenceLength);

            for (var i = 0; i < seq.Length; i++)
            {
                if (seq.Remove(i, 1).Contains(seq[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public override string Part1()
        {
            var parsedInput = ParseInput();

            for (var i = 0; i < parsedInput.Length; i++)
            {
                if (!SequenceHasDuplicates(parsedInput, i, 4))
                {
                    return (i + 4).ToString();
                }
            }

            return "Result not found";
        }

        public override string Part2()
        {
            var parsedInput = ParseInput();

            for (var i = 0; i < parsedInput.Length; i++)
            {
                if (!SequenceHasDuplicates(parsedInput, i, 14))
                {
                    return (i + 14).ToString();
                }
            }

            return "Result not found";
        }
    }
}
