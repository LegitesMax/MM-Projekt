using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations.Encryption
{
    public class OneTimePad : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input, string key)
        {

            key = Helper.Generate(input.Length);
            var result = new AlgorithmResult
            {
                Input = input,
                Key = key,
                Output = Encrypt(input, key)
            };
            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input,string key)
        {
            if (key == null || key == "")
            {
                key = Helper.Generate(input.Length);
            }
            var result = new AlgorithmResult
            {
                Input = input,
                Key = key,
                Output = Decrypt(input, key)
            };

            return result;
        }
    
        private string Encrypt(string input,string key)
        {
            input = FixInputString(input.ToUpper());

            key = Helper.Generate(input.Length);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {

                int c = ((input[i] - 'A') - (key[i] - 'A')) % 26;
                if(c < 0)
                {
                    c *= -1;
                }
                result.Append((char)(c + 'A'));
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


        /* Wenn key übergeben wird muss er auf die länge 
         * gebracht werden fals unglich lang
         * 
         * Mit mehr zeit können man den Key speichern und 
         * zum decrypten verwenden
         */

        private string Decrypt(string input, string key)
        {
            return "todo";
            input = FixInputString(input.ToUpper());
            key = FixKeyLength(key, input.Length);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int c = input[i] - 'A';
                int k = key[i] - 'A';
                int p = (c -26 + k );
                if (c < 0)
                {
                    c *= -1;
                }
                result.Append((char)(p + 'A'));
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



    }
}
