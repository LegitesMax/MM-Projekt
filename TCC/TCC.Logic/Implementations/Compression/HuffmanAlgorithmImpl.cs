using System.Text;
using System.Xml.Linq;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations.Compression
{
    public class HuffmanAlgorithmImpl : BaseApplicableAlgorithm
    {
        private Node TreeRoot { get; set; }

        public override AlgorithmResult ComputeOutput(string input, string? key)
        {
            var result = new AlgorithmResult();

            result.Input = input;
            try
            {
                result.Output = Encode(input);
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }


            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input, string? key)
        {
            var result = new AlgorithmResult();

            result.Input = input;
            try
            {
                result.Output = "TODO";
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }


            return result;
        }
        private string Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var histogram = Helper.CreateHistogram(input);
            var nodes = histogram.Select(h => new Node { Histogramm = h }).ToList();

            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(n => n.Histogramm.Count).ToList();

                var left = nodes[0];
                var right = nodes[1];

                var parent = new Node
                {
                    Histogramm = new Histogramm
                    {
                        Count = left.Histogramm.Count + right.Histogramm.Count
                    },
                    Left = left,
                    Right = right
                };

                nodes.RemoveRange(0, 2);
                nodes.Add(parent);
            }

            TreeRoot = nodes[0];
            AssignCodes(TreeRoot, "");

            var encoded = new StringBuilder();
            foreach (char ch in input)
            {
                encoded.Append(FindCode(TreeRoot, ch));
            }

            return encoded.ToString();
        }



        private void AssignCodes(Node node, string code)
        {
            if (node == null) return;

            if (node.Left == null && node.Right == null)
            {
                if (code.Length == 0)
                {
                    node.Code = "0";  
                }
                else
                {
                    node.Code = code;  
                }  
                return;
            }

            AssignCodes(node.Left, code + "0");
            AssignCodes(node.Right, code + "1");

        }

        private string FindCode(Node node, char target)
        {
            if (node == null) return null;

            if (node.Left == null && node.Right == null && node.Histogramm.Character == target)
                return node.Code;

            string left = FindCode(node.Left, target);
            if (left != null) return left;

            return FindCode(node.Right, target);

        }

    }


}
