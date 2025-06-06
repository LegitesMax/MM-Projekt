using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Implementations.Logic
{
    public class Helper
    {
        public static string ConvertToBinary(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            StringBuilder binaryOutput = new StringBuilder();

            foreach (var item in input)
            {
                string binaryChar = Convert.ToString(item, 2).PadLeft(8, '0');
                binaryOutput.Append(binaryChar + " ");
            }

            return binaryOutput.ToString().TrimEnd();
        }
        public static List<Patterns> FindPatterns(string input, int patternLength, int minRepeats)
        {
            var matches = new List<Patterns>();

            if (string.IsNullOrEmpty(input) || patternLength <= 0 || minRepeats <= 1 || input.Length < patternLength * minRepeats)
                return matches;

            for (int i = 0; i <= input.Length - patternLength * minRepeats; i++)
            {
                string segment = input.Substring(i, patternLength);
                int count = 1;
                int j = i + patternLength;

                while (j + patternLength <= input.Length && input.Substring(j, patternLength) == segment)
                {
                    count++;
                    j += patternLength;
                }

                if (count >= minRepeats)
                {
                    matches.Add(new Patterns(segment, i));
                    i = j - 1;
                }
            }

            return matches;
        }
        public static List<Histogramm> CreateHistogram(string input)
        {
            var res = new List<Histogramm>();

            foreach (char c in input)
            {
                bool found = false;

                for (int i = 0; i < res.Count && !found; i++)
                {
                    if (res[i].Character == c)
                    {
                        res[i].Count++;
                        found = true;
                    }
                }

                if (!found)
                {
                    res.Add(new Histogramm
                    {
                        Character = c,
                        Count = 1
                    });
                }
            }

            res.Sort((x, y) => (x.Count.CompareTo(y.Count)));
            return res;
        }
        public static string Generate(int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var bytes = new byte[length];
            var chars = new char[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            for (int i = 0; i < length; i++)
            {
                chars[i] = alphabet[bytes[i] % alphabet.Length];
            }

            return new string(chars);
        }
        public static bool HasIntegerSquareRoot(int number)
        {
            if (number < 0) return false; 

            double sqrt = Math.Sqrt(number);
            return sqrt == Math.Floor(sqrt);
        }

    }
}
