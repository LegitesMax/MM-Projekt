using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations.Compression
{
    public class LZWImpl : BaseApplicableAlgorithm
    {
        
        private const int DEFAULT_MAX_TABLE_SIZE = 4096; //Tablelimit 4096=12bit (4096 entries)
        private const int INITIAL_RANGE = 256; //Standard ASCII range


        public override AlgorithmResult ComputeOutput(string input, string? key)
        {
            var result = new AlgorithmResult();

            result.Input = input;
            try
            {
                result.Output = Encode(input);
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }

            return result;
        }

        public override AlgorithmResult ComputeOutputDe(string input, string? key)
        {
            var result = new AlgorithmResult();
            result.Input = input;

            if (string.IsNullOrWhiteSpace(input)) 
            {
                result.Output = string.Empty;
                return result;
            }

            try
            {
                result.Output = Decode(input);
            }
            catch (Exception ex)
            {
                result.Output = $"Error during LZW decoding: {ex.Message}";
            }
            return result;

        }
        private string Encode(string input)
        {
            LzwCodeTable codeTable = new LzwCodeTable(INITIAL_RANGE, DEFAULT_MAX_TABLE_SIZE);

            string prefix = string.Empty;
            List<int> outputCodes = new List<int>();

            foreach (char currentChar in input)
            {
                string suffix = currentChar.ToString();
                string pattern = prefix + suffix;

                if (codeTable.TryGetCode(pattern) != null)
                {
                    prefix = pattern;
                }
                else
                {
                    outputCodes.Add(codeTable.GetCode(prefix));

                    if (!codeTable.IsFull)
                    {
                        codeTable.Add(pattern);
                    }

                    prefix = suffix; 
                }
            }

            if (!string.IsNullOrEmpty(prefix))
            {
                outputCodes.Add(codeTable.GetCode(prefix));
            }

            return string.Join(" ", outputCodes);
        }


        private string Decode(string encodedInput)
        {
            List<int> codes;
            
             codes = encodedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();
            

            if (codes.Count == 0)
                return string.Empty;

            LzwCodeTable decodeTable = new LzwCodeTable(INITIAL_RANGE, DEFAULT_MAX_TABLE_SIZE);
            StringBuilder decodedOutput = new StringBuilder();

            int previousCode = codes[0];
            string previousString = decodeTable.TryGetString(previousCode);
            decodedOutput.Append(previousString);

            for (int i = 1; i < codes.Count; i++)
            {
                int currentCode = codes[i];
                string currentString = decodeTable.TryGetString(currentCode);

                if (currentString != null)
                {
                }
                else if (currentCode == decodeTable.CurrentNextCode && !decodeTable.IsFull)
                {
                    currentString = previousString + previousString[0];
                }

                decodedOutput.Append(currentString);

                if (!string.IsNullOrEmpty(currentString) && !decodeTable.IsFull)
                {
                    decodeTable.Add(previousString + currentString[0]);
                }

                previousString = currentString;
            }

            return decodedOutput.ToString();
        }
    }
}
