using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Encryption
{
    public class CaesarAlgorithm : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string? key)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input)
            };

            return result;
        }

        public override AlgorithmResult ComputeOutputDe(string input,string? key)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Decrypt(input)
            };

            return result;
        }

        private string Encrypt(string input)
        {
            throw new NotImplementedException();
        }
        private string Decrypt(string input)
        {
            throw new NotImplementedException();
        }
    }
}
