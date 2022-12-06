namespace AdventOfCode
{
    internal class Day3 : Puzzle
    {
        private List<IEnumerable<int>[]> ParseInput(bool firstPart)
        {
            var parsedInput = new List<IEnumerable<int>[]>();
            if (firstPart)
            {
                foreach (var input in Input)
                {
                    var firstCompartment = input.Substring(0, input.Length / 2);
                    var secondCompartment = input.Substring(input.Length / 2);

                    parsedInput.Add(new IEnumerable<int>[] { Prioritize(firstCompartment.ToArray()), Prioritize(secondCompartment.ToArray()) });
                }

                return parsedInput;
            }

            var currentGroup = new List<IEnumerable<int>>();
            foreach(var input in Input)
            {
                currentGroup.Add(Prioritize(input.ToArray()));
                if (currentGroup.Count == 3)
                {
                    parsedInput.Add(currentGroup.ToArray());
                    currentGroup = new List<IEnumerable<int>>();
                }
            }

            return parsedInput;
        }

        private IEnumerable<int> Prioritize(char[] items)
        {
            return items.Select(c => c < 91 ? c - 38 : c - 96);
        }

        private int GetPriority(IEnumerable<int>[] group)
        {
            IEnumerable<int> intersection = group.First();
            foreach (var items in group.Skip(1))
            {
                intersection = intersection.Intersect(items);
            }

            return intersection.Sum();
        }

        public override string Part1()
        {
            var score = 0;
            foreach (var rucksack in ParseInput(true))
            {
                score += GetPriority(rucksack);
            }
            return score.ToString();
        }

        public override string Part2()
        {
            var score = 0;
            foreach (var group in ParseInput(false))
            {
                score += (GetPriority(group));
            }
            return score.ToString();
        }
    }
}
