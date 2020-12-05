using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAdvent.Puzzles
{
    public class Day5 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var max = input.Select(GetSeatId).Max();

            Console.WriteLine($"[Puzzle 1]: Max seatId: {max}");
        }

        private int GetSeatId(string line)
        {
            var rowDefinition = line.Substring(0, 7);
            var columnDefinition = line.Substring(7, 3);

            var rowNumber = Calculate(rowDefinition, 0, 127);
            var columnNumber= Calculate(columnDefinition, 0, 7);

            return (rowNumber * 8) + columnNumber;
        }

        private int Calculate(string definition, int lower, int upper)
        {
            foreach (var character in definition)
            {
                (lower, upper) = GetCorrectHalf(lower, upper, character);
            }

            if (lower != upper)
            {
                throw new Exception("Error in determination of column number");
            }

            return lower;
        }

        private (int lower, int upper) GetCorrectHalf(int inputLowerRange, int inputUpperRange, char definition)
        {
            var halfOfRange = (double)(inputUpperRange - inputLowerRange) / 2;

            switch (definition)
            {
                case 'R':
                case 'B':
                    var newLowerRange = inputLowerRange + (int)Math.Ceiling(halfOfRange);

                    return (newLowerRange, inputUpperRange);
                case 'L':
                case 'F':
                    var newUpperRange = inputLowerRange + (int) Math.Floor(halfOfRange);

                    return (inputLowerRange, newUpperRange);

                default:
                    throw new Exception("Unknown definition");
            }
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var allSeatIds = input.Select(GetSeatId);

            var firstSeat = allSeatIds.Min();
            var lastSeat = allSeatIds.Max();

            var dd = allSeatIds.Where(id => id != firstSeat
                                         && id != lastSeat
                                         && (!allSeatIds.Contains(id + 1)
                                          || !allSeatIds.Contains(id - 1))).ToList();

            Console.WriteLine($"[Puzzle 2]: Max seatId: {dd.Min()+1}");
        }
    }
}
