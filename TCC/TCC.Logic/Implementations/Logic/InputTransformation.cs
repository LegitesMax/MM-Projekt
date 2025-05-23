using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Implementations.Logic
{
    public class InputTransformation
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

    }
}
