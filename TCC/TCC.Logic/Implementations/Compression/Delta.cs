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
            var result = new AlgorithmResult();
            result.Input = input;

            // Zerlege die kommagetrennte Liste in Zahlen
            var parts = input.Split(',');
            List<int> values = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int val))
                    values.Add(val);
            }

            // Jetzt rekonstruieren wir den Original-Text
            List<char> tmp = new List<char>();

            int current = values[0];
            tmp.Add((char)current);

            for (int i = 1; i < values.Count; i++)
            {
                current += values[i]; // Delta anwenden
                tmp.Add((char)current);
            }

            result.Output = string.Join("", tmp.ToArray());

            return result;
        }
    }
}
