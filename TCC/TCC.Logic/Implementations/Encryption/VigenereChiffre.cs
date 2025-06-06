using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;

namespace TCC.Logic.Implementations.Encryption
{

    public class VigenereChiffre : BaseApplicableAlgorithm
    {
        public override AlgorithmResult ComputeOutput(string input,string? key)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Key = key,
                Output = Encrypt(input,key)
            };
            return result;
        }
        public override AlgorithmResult ComputeOutputDe(string input, string? key)
        {
            var result = new AlgorithmResult
            {
                Input = input,
                Key = key,
                Output = Decrypt(input,key)
            };
            return result;
        }
        private string Encrypt(string input,string key)
        {
            if (key == null)
            {
                return "Key muss angegeben werden";
            }
            StringBuilder ciphertext = new StringBuilder();
            string repeatedKey = RepeatKey(input, key.ToUpper());

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                char keyChar = repeatedKey[i];

                if (char.IsLetter(letter))
                {
                    char baseChar = char.IsUpper(letter) ? 'A' : 'a';

                    int shift = keyChar - 'A';
                    char encryptedChar = (char)((letter - baseChar + shift) % 26 + baseChar);

                    ciphertext.Append(encryptedChar);
                }
                else
                {
                    ciphertext.Append(letter);
                }
            }

            return ciphertext.ToString();
            throw new NotImplementedException();
        }
        private static string RepeatKey(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    result.Append(key[keyIndex % key.Length]);
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }


        public static string Decrypt(string input,string key)
        {
            if (key == null)
            {
                return "Key muss angegeben werden";
            }
            StringBuilder plaintext = new StringBuilder();
            string repeatedKey = RepeatKey(input, key.ToUpper());

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                char keyChar = repeatedKey[i];

                if (char.IsLetter(letter))
                {
                    char baseChar = char.IsUpper(letter) ? 'A' : 'a';

                    int shift = keyChar - 'A';
                    char decryptedChar = (char)((letter - baseChar - shift + 26) % 26 + baseChar);

                    plaintext.Append(decryptedChar);
                }
                else
                {
                    plaintext.Append(letter);
                }
            }

            return plaintext.ToString();
        }

    }
}
