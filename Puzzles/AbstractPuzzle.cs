using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent.Puzzles
{
    public abstract class AbstractPuzzle<T>
    {
        private readonly string _fileDataLocation = "D:\\Play\\CodeAdvent\\Puzzles\\input\\";
        private readonly string _puzzleInputFile;

        protected AbstractPuzzle()
        {
            _puzzleInputFile = _fileDataLocation + this.GetType().Name + ".txt";
        }

        public void Solve()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("********************************************************");
            Console.WriteLine($"Solving puzzles for {this.GetType().Name}:");
            var input = GetInput();

            SolvePuzzle1(input);
            SolvePuzzle2(input);
        }

        protected IList<T> GetInput()
        {
            var logFile = File.ReadAllLines(_puzzleInputFile);

            return logFile.Select(l => ConvertToExpectedType(l)).ToList();
        }

        protected abstract void SolvePuzzle1(IList<T> input);

        protected abstract void SolvePuzzle2(IList<T> input);

        private static T ConvertToExpectedType(string inputLine)
        {
            return (T)Convert.ChangeType(inputLine, typeof(T));
        }
    }
}
