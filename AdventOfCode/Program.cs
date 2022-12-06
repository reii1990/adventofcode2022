
using AdventOfCode;

Console.WriteLine("Enter day: ");
var day = int.Parse(Console.ReadLine());
Console.WriteLine("Enter part: ");
var part = int.Parse(Console.ReadLine());


Puzzle puzzle;
switch (day)
{
    case 1:
        puzzle = new Day1();
        break;
    case 2:
        puzzle = new Day2();
        break;
    case 3:
        puzzle = new Day3();
        break;
    case 4:
        puzzle = new Day4();
        break;
    default:
        throw new NotImplementedException();
}

switch(part)
{
    case 1:
        Console.WriteLine(puzzle.Part1());
        break;
    case 2:
        Console.WriteLine(puzzle.Part2());
        break;
}