using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAdvent.Puzzles
{
    public class Day2 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var numberOfValidPassword = input.Count(l => IsPasswordValidForPuzzle1(l));

            Console.WriteLine($"Found {numberOfValidPassword} valid passwords for puzzle 1");
        }

        private static bool IsPasswordValidForPuzzle1(string inputLine)
        {
            var splittedLine = inputLine.Split(" "); // Door de opbouw van de file weet ik dat er altijd 3 'delen' zijn

            // 1e deel van elke regel zijn cijfers met een - ertussen
            var expectedOccurrences = splittedLine[0].Split("-");
            var minimumRequiredApperances = int.Parse(expectedOccurrences[0]);
            var maximumAllowedApperances = int.Parse(expectedOccurrences[1]);

            // 2e deel van elke regel is het verplichte teken + dubbelepunt
            var requiredCharacter = char.Parse(splittedLine[1].Substring(0, 1));

            // 3e deel van elke regel is het paswoord zelf
            var password = splittedLine[2];

            var occurrencesOfRequiredCharacted = password.Count(c => c == requiredCharacter);

            return occurrencesOfRequiredCharacted >= minimumRequiredApperances
                && occurrencesOfRequiredCharacted <= maximumAllowedApperances;
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var numberOfValidPassword = input.Count(l => IsPasswordValidForPuzzle2(l));

            Console.WriteLine($"Found {numberOfValidPassword} valid passwords for puzzle 2");
        }

        private static bool IsPasswordValidForPuzzle2(string inputLine)
        {
            var splittedLine = inputLine.Split(" "); // Door de opbouw van de file weet ik dat er altijd 3 'delen' zijn

            // 1e deel van elke regel zijn cijfers met een - ertussen
            var occurrences = splittedLine[0].Split("-");
            var possiblePosition1 = int.Parse(occurrences[0]);
            var possiblePosition2 = int.Parse(occurrences[1]);

            // 2e deel van elke regel is het verplichte teken + dubbelepunt
            var requiredCharacter = char.Parse(splittedLine[1].Substring(0, 1));

            // 3e deel van elke regel is het paswoord zelf
            var password = splittedLine[2];

            var charOnPosition1 = char.Parse(password.Substring(possiblePosition1 - 1, 1));
            var charOnPosition2 = char.Parse(password.Substring(possiblePosition2 - 1, 1));

            return (charOnPosition1 == requiredCharacter && charOnPosition2 != requiredCharacter)
                || (charOnPosition1 != requiredCharacter && charOnPosition2 == requiredCharacter);
        }
    }
}
