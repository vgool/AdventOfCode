using System;
using System.Collections.Generic;

namespace CodeAdvent.Puzzles
{
    public class Day8 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var lineNumber = 0;
            var accumulator = 0;

            var alreadyExecutedLines = new List<int>();

            while (lineNumber < input.Count)
            {
                if (alreadyExecutedLines.Contains(lineNumber))
                {
                    // This is the second time this line is called..
                    break;
                }
                alreadyExecutedLines.Add(lineNumber);

                var (operation, argument) = GetOperationAndArgument(input, lineNumber);

                lineNumber += GetLineNumberAddition(operation, argument);
                accumulator += GetAccumulatorAddition(operation, argument);
            }

            Console.WriteLine($"[Puzzle1]: Accumulator {accumulator}");
        }

        private int GetLineNumberAddition(string operation, int argument)
        {
            switch (operation)
            {
                case "acc":
                case "nop":
                    return 1;

                case "jmp":
                    return argument;

                default:
                    throw new Exception("Unknown operation");
            }
        }

        private int GetAccumulatorAddition(string operation, int argument)
        {
            return operation.Equals("acc") ? argument : 0;
        }

        private static (string operation, int argument) GetOperationAndArgument(IList<string> input, int index)
        {
            var line = input[index];

            var operation = line.Substring(0, 3);
            var argument= int.Parse(line.Substring(4)); // To the end of the string

            return (operation, argument);
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var lineNumber = 0;
            var accumulator = 0;
            var foundIncorrectLine = false;

            while (lineNumber < input.Count)
            {
                var (operation, argument) = GetOperationAndArgument(input, lineNumber);

                switch (operation)
                {
                    case "acc":
                        accumulator += argument;
                        lineNumber++;
                        break;

                    case "jmp":
                        if (!foundIncorrectLine && WouldReachEnd(input, lineNumber + 1))
                        {
                            // Would reach the end if changed to nop... so increase the lineNumber as would have done at nop.
                            lineNumber++;
                            foundIncorrectLine = true;
                        }
                        else
                        {
                            // Would not reach the end if changed to nop, so continue with the regular behavior
                            lineNumber += argument;
                        }
                        break;

                    case "nop":
                        if (!foundIncorrectLine && WouldReachEnd(input, lineNumber + argument))
                        {
                            // Would reach the end if changed to jmp... so increase the lineNumber as would have done at nop.
                            lineNumber += argument;
                            foundIncorrectLine = true;
                        }
                        else
                        {
                            // Would not reach the end if changed to jmp, so continue with the regular behavior
                            lineNumber++;
                        }
                        break;
                    default:
                        throw new Exception("Unknown operation");
                }
            }

            Console.WriteLine($"[Puzzle2]: Accumulator {accumulator}");
        }

        private bool WouldReachEnd(IList<string> input, int lineNumber)
        {
            var alreadyExecutedLines = new List<int>();

            while (lineNumber < input.Count)
            {
                if (alreadyExecutedLines.Contains(lineNumber))
                {
                    // This is the second time this line is called..
                    return false;
                }
                alreadyExecutedLines.Add(lineNumber);

                var (operation, argument) = GetOperationAndArgument(input, lineNumber);

                lineNumber += GetLineNumberAddition(operation, argument);
            }

            return true;
        }
    }
}
