using TCC.Logic.Base;
using TCC.Logic.Implementations;

namespace TCC.Logic.Factory
{
    public class ApplicableAlgorithmFactory
    {
        //TODO: Add factory methods for all implementations of algorithms

        public static IAppliableAlgorithm CreateHuffmanAlgorithm(string input)
        {
            return new HuffmanAlgorithmImpl() { Input = input };
        }
    }
}
