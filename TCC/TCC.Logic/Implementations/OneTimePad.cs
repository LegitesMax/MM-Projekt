using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations
{
    public class OneTimePad : BaseApplicableAlgorithm
    {

        public override AlgorithmResult ComputeOutput(string input)
        {
            string key = "XMCKL";
            key = FixKeyLength(key);
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input,key)
            };

            return result;
        }
        private string Encrypt(string input,string key)
        {
            input = FixInputString(input.ToUpper());

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int charVal = (input[i] - 'A' + key[i] - 'A') % 26;
                result.Append((char)(charVal + 'A'));
            }

            return result.ToString();
        }
        /*
        private string Decrypt(string input, string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int charVal = (input[i] - 'A' - (key[i] - 'A') + 26) % 26;
                result.Append((char)(charVal + 'A'));
            }

            return result.ToString();
        }
         */
        private string FixKeyLength(string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < key.Length; i++)
            {
                key.Append(key[i % key.Length]);
            }

            return result.ToString();
        }

        private string FixInputString(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    result.Append(c);
            }

            return result.ToString();
        }
        
    }
}
