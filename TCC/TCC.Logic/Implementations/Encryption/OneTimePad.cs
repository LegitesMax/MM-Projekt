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
            if(input != null)
            {
                key = Helper.Generate(input.Length);
            }
            var result = new AlgorithmResult
            {
                Input = input,
                Key = key,
                Output = Encrypt(input, key)
            };
            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input, string? key)
        {

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
            if(input == null || input == "")
            {
                return "Input muss befüllt werden";
            }
            input = FixInputString(input.ToUpper());
            input = ConvertToNumbCode(input.ToUpper());
            StringBuilder result = new StringBuilder();
            key = ConvertToNumbCode(key.ToUpper());
            int inputI = 0;
            int keyI = 0;
            int tmp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                inputI = input[i] - '0';
                keyI = key[i] - '0';
                tmp = inputI - keyI;
                if (tmp <= -1)
                {
                    tmp *= -1;
                }
                if (inputI < keyI)
                {
                    tmp = 10 - tmp;
                }

                result.Append(tmp.ToString());
            }

            return result.ToString();
        }
        private string ConvertToNumbCode(string input)
        {
            StringBuilder result = new StringBuilder();

            input = input.ToUpper();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    int value = (c - 'A') % 26;
                    result.Append(value.ToString("D2")); 
                }
            }

            return result.ToString();
        }

        private string ConvertFromNumbCodeToString(string numberString)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numberString.Length; i += 2)
            {
                string twoDigits = numberString.Substring(i, 2);
                if (int.TryParse(twoDigits, out int value) && value >= 0 && value < 26 )
                {
                    char letter = (char)('A' + value);
                    result.Append(letter);
                }
                else
                {
                    result.Append('?'); 
                }
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

        private string Decrypt(string input, string? key)
        {
            if (key == null || key == "" || key.Length != (input.Length/2))
            {
                return "Key muss angegeben werden";
            }

            key = ConvertToNumbCode(key);
            StringBuilder result = new StringBuilder();
            int inputI = 0;
            int keyI = 0;
            int tmp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                inputI = input[i] - '0';
                keyI = key[i] - '0';

                tmp = (inputI + keyI) % 10;


                result.Append(tmp.ToString());

            }

            return ConvertFromNumbCodeToString(result.ToString());
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
