using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeAdvent.Puzzles
{
    public class Day4 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var passports = new List<Passport>();

            var passport = new Passport();

            foreach (var line in input)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var keyValuePairs = line.Split(" ");
                    passport.Set(keyValuePairs);
                }

                if (string.IsNullOrEmpty(line) || line == input.Last())
                {
                    // End of passport
                    passports.Add(passport);

                    // Already create a new passport
                    passport = new Passport();
                }
            }

            var numberOfValidPassports = passports.Count(p => p.IsValid());

            Console.WriteLine($"[Puzzle 1]: Valid passports {numberOfValidPassports} out of {passports.Count}");
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            Console.WriteLine("[Puzzle 2]: TODO");
        }

        private class Passport
        {
            public string Byr { get; private set; }
            public string Iyr { get; private set; }
            public string Eyr { get; private set; }
            public string Hgt { get; private set; }
            public string Hcl { get; private set; }
            public string Ecl { get; private set; }
            public string Pid { get; private set; }
            public string Cid { get; private set; }

            public bool IsValid()
            {
                return Byr != null
                    && Iyr != null
                    && Eyr != null
                    && Hgt != null
                    && Hcl != null
                    && Ecl != null
                    && Pid != null;
            }

            public void Set(string[] keyValuePairs)
            {
                foreach (var kvp in keyValuePairs)
                {
                    SetKeyValuePair(kvp.Split(":"));
                }
            }

            private void SetKeyValuePair(string[] keyValuePair)
            {
                var key = keyValuePair[0];
                var value = keyValuePair[1];

                switch (key)
                {
                    case "byr":
                        Byr = value;
                        break;
                    case "iyr":
                        Iyr = value;
                        break;
                    case "eyr":
                        Eyr = value;
                        break;
                    case "hgt":
                        Hgt = value;
                        break;
                    case "hcl":
                        Hcl = value;
                        break;
                    case "ecl":
                        Ecl = value;
                        break;
                    case "pid":
                        Pid = value;
                        break;
                    case "cid":
                        Cid = value;
                        break;

                    default:
                        throw new Exception("Unknown key");
                }
            }
        }
    }
}
