using System.Xml.Linq;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations
{
    public class HuffmanAlgorithmImpl : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input)
        {
            //TODO IMPLEMENT CORRECLY - THIS IS AH TESTS CASE FOR FRONTEND

            /// Hier wird die jeweilige Compresion-/Codierungsmethode umgesetzt
            /// <returns>Ergebnis der Codierung</returns>

            var result = new AlgorithmResult();

            result.Input = input;
            result.Output = Encode(input).Encoded.ToString();

            return result;
        }

        public class Node
        {
            public char C; public int F; public Node L, R;
            public bool Leaf => L == null && R == null;
            public Node(char c, int f) => (C, F) = (c, f);
        }

        public static (string Encoded, Node Root) Encode(string s)
        {
            var freq = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var pq = new PriorityQueue<Node, int>(freq.Select(kv => (new Node(kv.Key, kv.Value), kv.Value)));

            while (pq.Count > 1)
            {
                var a = pq.Dequeue();
                var b = pq.Dequeue();
                var n = new Node('\0', a.F + b.F) { L = a, R = b };
                pq.Enqueue(n, n.F);
            }

            var root = pq.Dequeue();
            var codes = new Dictionary<char, string>();
            void Walk(Node node, string p)
            {
                if (node.Leaf)
                    codes[node.C] = p == string.Empty ? "0" : p;
                else
                {
                    Walk(node.L, p + "0");
                    Walk(node.R, p + "1");
                }
            }
            Walk(root, string.Empty);

            var encoded = string.Concat(s.Select(c => codes[c]));
            return (encoded, root);
        }

        public static string Decode(string bits, Node root)
        {
            var cur = root;
            var output = new List<char>();
            foreach (var b in bits)
            {
                cur = (b == '0') ? cur.L : cur.R;
                if (cur.Leaf)
                {
                    output.Add(cur.C);
                    cur = root;
                }
            }
            return new string(output.ToArray());
        }

    }
}
