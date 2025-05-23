using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations
{
    public class Binary : BaseApplicableAlgorithm
    {
        //Man kann irgendwas einsetzen was normalerweise nie verwendet wird, am besten Ascii Steuerzeichen weil die nicht abgebildet werden können.
        private const char Marker = '\x00';

        public override AlgorithmResult ComputeOutput(string input)
        {
            var result = new AlgorithmResult();

            result.Input = input;
            result.Output = Encode(input);

            return result;
        }
        public string Encode(string input)
        {
            return Helper.ConvertToBinary(input);
        }
    }
}
