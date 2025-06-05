using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Compression
{
    public class XOR : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string? key)
        {
            var result = new AlgorithmResult();
            result.Input = input;

            List<int> encodedValues = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char inputChar = input[i];
                char keyChar = key![i % key.Length]; // Schlüssel wird wiederholt
                int xorValue = inputChar ^ keyChar;
                encodedValues.Add(xorValue);
            }

            // Rückgabe als kommagetrennte Zahlenkette
            result.Output = string.Join(",", encodedValues);
            return result;
        }

        public override AlgorithmResult ComputeOutputDe(string input, string? key)
        {
            var result = new AlgorithmResult();
            result.Input = input;

            string[] parts = input.Split(',');
            List<char> decodedChars = new List<char>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i], out int value))
                {
                    char keyChar = key[i % key.Length];
                    char decodedChar = (char)(value ^ keyChar);
                    decodedChars.Add(decodedChar);
                }
            }

            //Rückgabe ohne Komma
            result.Output = string.Join("", decodedChars.ToArray());
            return result;
        }
    }
}
