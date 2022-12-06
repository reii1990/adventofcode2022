
using AdventOfCode;

Console.WriteLine("Enter day: ");
var day = int.Parse(Console.ReadLine());
Console.WriteLine("Enter part: ");
var part = int.Parse(Console.ReadLine());

Puzzle? puzzle = (Puzzle?)Activator.CreateInstance("AdventOfCode", $"AdventOfCode.Day{day}")?.Unwrap();

if (puzzle == null)
{
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