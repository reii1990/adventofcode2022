using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal abstract class Puzzle
    {
        public string[] Input { get; set; }

        public Puzzle(int day)
        {
            Input = File.ReadAllLines($@"C:\Users\dan.torberg\source\repos\AdventOfCode\AdventOfCode\inputs\input{day}.txt");
        }

        public abstract string Part1();
        public abstract string Part2();
    }
}
