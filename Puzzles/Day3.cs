using System;
using System.Collections.Generic;

namespace CodeAdvent.Puzzles
{
    public class Day3 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var encounteredNumberOfTrees = FindTrees(input, 3, 1);

            Console.WriteLine($"[Puzzle 1]: Encountered {encounteredNumberOfTrees} trees.");
        }

        private long FindTrees(IList<string> input, int slopeRight, int slopeDown)
        {
            var encounteredNumberOfTrees = 0;

            var position = slopeRight;
            var lineNr = slopeDown;

            while (lineNr < input.Count)
            {
                var lineToWorkWith = GetLineToWorkWith(input[lineNr], position);

                var charOnPosition = lineToWorkWith[position];
                if (charOnPosition == '#')
                {
                    encounteredNumberOfTrees++;
                }

                position += slopeRight;
                lineNr += slopeDown;
            }

            return encounteredNumberOfTrees;
        }

        private static string GetLineToWorkWith(string originalLine, int position)
        {
            var lineToWorkWith = originalLine;

            while (lineToWorkWith.Length <= position)
            {
                lineToWorkWith += originalLine;
            }

            return lineToWorkWith;
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var slope1 = FindTrees(input, 1, 1);
            var slope2 = FindTrees(input, 3, 1);
            var slope3 = FindTrees(input, 5, 1);
            var slope4 = FindTrees(input, 7, 1);
            var slope5 = FindTrees(input, 1, 2);

            Console.WriteLine($"[Puzzle 2]: Encountered {slope1}, {slope2}, {slope3}, {slope4} and {slope5} trees. Multiplied  = {slope1 * slope2 * slope3 * slope4 * slope5}");
        }
    }
}
