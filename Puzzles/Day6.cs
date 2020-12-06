using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeAdvent.Puzzles
{
    public class Day6 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var totalCorrectAnswers = 0;
            var correctAnswersOfGroup = new List<char>();

            foreach (var line in input)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    correctAnswersOfGroup.AddRange(line.ToCharArray());
                }

                if (string.IsNullOrEmpty(line) || line == input.Last()) // End of group
                {
                    totalCorrectAnswers += correctAnswersOfGroup.Distinct().Count();
                    correctAnswersOfGroup = new List<char>();
                }
            }

            Console.WriteLine($"[Puzzle 1]: Total number of correct answers is {totalCorrectAnswers}");
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var totalCorrectAnswers = 0;
            var answersPerGroupMember = new List<string>();

            foreach (var line in input)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    answersPerGroupMember.Add(line);
                }

                if (string.IsNullOrEmpty(line) || line == input.Last()) // End of group
                {
                    totalCorrectAnswers += GetNumberOfQuestionsAnsweredByWholeGroup(answersPerGroupMember);
                    answersPerGroupMember = new List<string>();
                }
            }

            Console.WriteLine($"[Puzzle 2]: Total number of correct answers is {totalCorrectAnswers}");
        }

        private static int GetNumberOfQuestionsAnsweredByWholeGroup(IList<string> answersPerGroupMember)
        {
            var occerencesPerCharacter = new Dictionary<char, int>();

            foreach (var answersOfGroupMember in answersPerGroupMember)
            {
                foreach (var answer in answersOfGroupMember.ToCharArray().Distinct())
                {
                    occerencesPerCharacter.TryGetValue(answer, out var currentOrrences);
                    occerencesPerCharacter[answer] = (currentOrrences += 1);
                }
            }

            return occerencesPerCharacter.Count(kvp => kvp.Value == answersPerGroupMember.Count);
        }
    }
}
