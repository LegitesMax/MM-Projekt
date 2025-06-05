using TCC.Logic.Base;
using TCC.Logic.Implementations;
using TCC.Logic.Implementations.Compression;
using TCC.Logic.Implementations.Encryption;



namespace TCC.Logic.Factory
{
    public class ApplicableAlgorithmFactory
    {
        //TODO: Add factory methods for all implementations of algorithms

        public static AlgorithmResult CreateHuffmanAlgorithm(string input)
        {
            return new HuffmanAlgorithmImpl().ComputeOutput(input, string.Empty);
        }
    }
}
