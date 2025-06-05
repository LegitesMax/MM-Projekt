using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Compression
{
    public class Delta : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string? key = null)
        {
            var result = new AlgorithmResult();
            result.Input = input;

            List<int> deltas = new List<int>();

            // Erster Zeichenwert (Unicode) direkt übernehmen
            deltas.Add((int)input[0]);

            // Für jedes weitere Zeichen: Differenz zum vorherigen berechnen
            for (int i = 1; i < input.Length; i++)
            {
                int delta = input[i] - input[i - 1];
                deltas.Add(delta);
            }

            result.Output = string.Join(",", deltas);

            return result;
        }

        public override AlgorithmResult ComputeOutputDe(string input, string? key = null)
        {
            throw new NotImplementedException();
        }
    }
}
