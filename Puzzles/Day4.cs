using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeAdvent.Puzzles
{
    public class Day4 : AbstractPuzzle<string>
    {
        protected override void SolvePuzzle1(IList<string> input)
        {
            var passports = GetPassports(input);

            var numberOfValidPassports = passports.Count(p => p.AllRequiredFieldsFilled());

            Console.WriteLine($"[Puzzle 1]: Valid passports {numberOfValidPassports} out of {passports.Count}");
        }

        protected override void SolvePuzzle2(IList<string> input)
        {
            var passports = GetPassports(input);

            var numberOfValidPassports = passports.Count(p => p.AllRequiredFieldsValid());

            Console.WriteLine($"[Puzzle 2]: Valid passports {numberOfValidPassports} out of {passports.Count}");
        }

        private static IList<Passport> GetPassports(IList<string> input)
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

            return passports;
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

            public bool AllRequiredFieldsFilled()
            {
                return Byr != null
                    && Iyr != null
                    && Eyr != null
                    && Hgt != null
                    && Hcl != null
                    && Ecl != null
                    && Pid != null;
            }

            public bool AllRequiredFieldsValid()
            {
                return IsByrValid()
                    && IsIyrValid()
                    && IsEyrValid()
                    && IsHgtValid()
                    && IsHclValid()
                    && IsEclValid()
                    && IsPidValid();
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

            private bool IsPidValid()
            {
                return Pid != null && Pid.Length == 9 && int.TryParse(Pid, out var result);
            }

            private bool IsEclValid()
            {
                var allowedValues = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                return allowedValues.Contains(Ecl);
            }

            private bool IsHclValid()
            {
                var regex = new Regex("^#([a-fA-F0-9]{6})$");

                return Hcl != null
                    && regex.IsMatch(Hcl);
            }

            private bool IsHgtValid()
            {
                if (Hgt != null)
                {
                    if (Hgt.EndsWith("cm"))
                    {
                        var length = int.Parse(Hgt.Substring(0, Hgt.Length - 2));
                        return 150 <= length && length <= 193;
                    }
                    else if (Hgt.EndsWith("in"))
                    {
                        var length = int.Parse(Hgt.Substring(0, Hgt.Length - 2));
                        return 59 <= length && length <= 76;
                    }
                }

                return false;
            }

            private bool IsEyrValid()
            {
                return int.TryParse(Eyr, out var year)
                    && 2020 <= year
                    && year <= 2030;
            }

            private bool IsIyrValid()
            {
                return int.TryParse(Iyr, out var year)
                    && 2010 <= year
                    && year <= 2020;
            }

            private bool IsByrValid()
            {
                return int.TryParse(Byr, out var year)
                    && 1920 <= year
                    && year <= 2002;
            }
        }
    }
}
