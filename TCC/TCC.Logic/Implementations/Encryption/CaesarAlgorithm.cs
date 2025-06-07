using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Encryption
{
    public class CaesarAlgorithm : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string? key)
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

        private string Encrypt(string input, string? key)
        {
            if (String.IsNullOrEmpty(key)) key = "0";
            int offset = 0;
            StringBuilder sb = new StringBuilder();
            char tmp;
            if(!Int32.TryParse(key, out offset)) return input;
            foreach (char c in input) {
                if (Char.IsLetter(c))
                {
                    tmp = (char)(c + offset % 26);
                    tmp = Char.IsLetter(tmp) ? tmp : (char)(tmp - 26);
                }
                else
                {
                    tmp = c;
                }
                sb.Append(tmp);
            }
            return sb.ToString();
        }
        private string Decrypt(string input, string? key)
        {
            if (String.IsNullOrEmpty(key)) key = "0";
            int offset = 0;
            StringBuilder sb = new StringBuilder();
            char tmp;
            if (!Int32.TryParse(key, out offset)) return input;
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    tmp = (char)(c - offset % 26);
                    tmp = Char.IsLetter(tmp) ? tmp : (char)(tmp + 26);
                }
                else
                {
                    tmp = c;
                }
                sb.Append(tmp);
            }
            return sb.ToString();
        }
    }
}
