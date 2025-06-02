using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations
{
    public class CaesarAlgorithm : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input)
            };

            return result;
        }

        private string Encrypt(string input)
        {
            throw new NotImplementedException();
        }
    }
}
