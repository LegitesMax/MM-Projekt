using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations
{
    public class Binary : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string? key)
        {
            var result = new AlgorithmResult();
            result.Statistic.IsOutputBinary = true;

            result.Input = input;
            result.Output = Encode(input);

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
            return Helper.ConvertToBinary(input);
        }
    }
}
