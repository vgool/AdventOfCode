using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAdvent.Puzzles
{
    public class Day1 : AbstractPuzzle<int>
    {
        protected override void SolvePuzzle1(IList<int> input)
        {
            foreach (var i in input)
            {
                var x = input.FirstOrDefault(inp => (i + inp) == 2020);
                if (x > 0)
                {
                    Console.WriteLine($"Found {i} and {x}, which makes the answer: {i * x}");
                    return;
                }
            }
        }

        protected override void SolvePuzzle2(IList<int> input)
        {
            foreach (var first in input)
            {
                foreach (var second in input)
                {
                    var third = input.FirstOrDefault(i => (first + second + i) == 2020);
                    if (third > 0)
                    {
                        Console.WriteLine($"Found {first}, {second} and {third}, which makes the answer: {first * second * third}");
                        return;
                    }
                }
            }
        }
    }
}
