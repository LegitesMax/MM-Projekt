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
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input,key)
            };

            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input)
        {
            string key = "XMCKL";
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Decrypt(input, key)
            };

            return result;
        }
        private string Encrypt(string input,string key)
        {
            key = FixKeyLength(key, input.Length);

            input = FixInputString(input.ToUpper());

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0)
                {
                    int charVal = (input[i] - 'A' + key[i % key.Length] - 'A') % 26;
                    result.Append((char)(charVal + 'A'));
                }
                else 
                {
                    int charVal = (input[i] - 'A' + key[0] - 'A') % 26;
                    result.Append((char)(charVal + 'A'));
                }
            }

            return result.ToString();
        }
        
        private string Decrypt(string input, string key)
        {
            key = FixKeyLength(key, input.Length);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0)
                {
                    int charVal = (input[i] - 'A' - (key[i % key.Length] - 'A') + 26) % 26;
                    result.Append((char)(charVal + 'A'));
                }
                else
                {
                    int charVal = (input[i] - 'A' - (key[0] - 'A') + 26) % 26;
                    result.Append((char)(charVal + 'A'));
                }
            }

            return result.ToString();
        }
         
        private string FixKeyLength(string key,int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(key[i % key.Length]);
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
