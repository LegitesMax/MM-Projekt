using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations
{
    public class OneTimePad : BaseApplicableAlgorithm
    {
        private static string key;
        public override AlgorithmResult ComputeOutput(string input)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input,key)
            };

            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Output = "Kann nicht Decrypted werden" /*Decrypt(input, key)*/
            };

            return result;
        }
        private string Encrypt(string input,string key)
        {
            input = FixInputString(input.ToUpper());

            key = Generate(input.Length);
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
        public static string Generate(int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var bytes = new byte[length];
            var chars = new char[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            for (int i = 0; i < length; i++)
            {
                chars[i] = alphabet[bytes[i] % alphabet.Length];
            }

            return new string(chars);
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

        /*private string Decrypt(string input, string key)
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
        }*/



    }
}
