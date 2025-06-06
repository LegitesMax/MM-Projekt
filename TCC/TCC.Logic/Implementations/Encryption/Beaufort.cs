using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Encryption
{
    public class Beaufort : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input,string? key)
        {
            var result = new AlgorithmResult();

            try
            {
                result.Input = input;
                result.Key = key;
                result.Output = Encrypt(input, key);
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }

            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input,string? key)
        {
            var result = new AlgorithmResult();

            try
            {
                result.Input = input;
                result.Key = key;
                result.Output = Decrypt(input, key);
            }
            catch (Exception ex)
            {
                result.Output = $"Error during encoding: {ex.Message}";
            }

            return result;
        }
        private string Encrypt(string input, string key)
        {
            if (key == null) 
            {
                return "Key muss angegeben werden";
            }
            key = key.ToUpper();
            int counter = 0;
            StringBuilder result = new StringBuilder();
            foreach (char c in input) 
            {
                if (char.IsLetter(c))
                {
                    char tmp = char.ToUpper(c);
                    tmp = (char)('A' + (key[counter % key.Length] - tmp + 26) % 26);
                    if (char.IsLower(c))
                    { 
                        result.Append(char.ToLower(tmp));
                    }
                    else
                    {
                        result.Append(tmp);
                    }
                    counter++;

                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
        
        private string Decrypt(string input, string key)
        {
            return Encrypt(input, key); 
        }


    }
}
