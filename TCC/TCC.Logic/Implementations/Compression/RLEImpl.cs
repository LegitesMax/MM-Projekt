using System.Text;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;



namespace TCC.Logic.Implementations.Compression
{
    //Run-Length Encoding
    public class RLEImpl : BaseApplicableAlgorithm
    {
        //Man kann irgendwas einsetzen was normalerweise nie verwendet wird, am besten Ascii Steuerzeichen weil die nicht abgebildet werden können.
        private const char Marker = '\x00';

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
            try
            {
                result.Output = "TODO";
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }


            return result;
        }

        public string Encode(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var sb = new StringBuilder();
            var patterns = Helper.FindPatterns(input, 1, 4);
            int patternIndex = 0;
            int i = 0;

            while (i < input.Length)
            {
                if (patternIndex < patterns.Count && i == patterns[patternIndex].StartIndex)
                {
                    i = EncodePatternMatch(sb, input, patterns[patternIndex]);
                    patternIndex++;
                }
                else
                {
                    sb.Append(input[i]);
                    i++;
                }
            }

            return sb.ToString();
        }

        private int EncodePatternMatch(StringBuilder sb, string input, Patterns pattern)
        {
            char c = pattern.Pattern[0];
            int count = 1;
            int start = pattern.StartIndex;
            while (start + count < input.Length && input[start + count] == c)
            {
                count++;
            }

            sb.Append(c);
            sb.Append(Marker);
            sb.Append(count);

            return start + count;
        }
    }
}
