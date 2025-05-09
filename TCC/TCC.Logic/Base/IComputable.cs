using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Base
{
    public interface IComputable
    {
        AlgorithmResult ComputeOutput(string input);
    }
}
