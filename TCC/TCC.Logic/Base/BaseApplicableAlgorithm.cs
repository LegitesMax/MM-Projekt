using System.Text;

namespace TCC.Logic.Base
{
    public abstract class BaseApplicableAlgorithm : IComputable
    {
        /// <summary>
        /// Hier wird die jeweilige Compresion-/Codierungsmethode umgesetzt
        /// </summary>
        /// <returns>Ergebnis der Codierung</returns>
        public abstract AlgorithmResult ComputeOutput(string input,string? key);
        public abstract AlgorithmResult ComputeOutputDe(string input,string? key);

    }
}
