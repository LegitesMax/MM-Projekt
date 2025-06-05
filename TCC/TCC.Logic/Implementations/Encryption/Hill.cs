using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations.Encryption
{
    public class Hill : BaseApplicableAlgorithm
    {
        private int[,] keyMatrix = new int[,] { { 3, 3 }, { 2, 5 } };

        private const int Mod = 26;
        public override AlgorithmResult ComputeOutput(string input, string key)
        {
            //todo key in keymatix umwandeln
            var result = new AlgorithmResult
            {
                Input = input,
                Output = Encrypt(input, key)
            };

            return result;
        }

        public override AlgorithmResult ComputeOutputDe(string input,string key)
        {

            throw new NotImplementedException();
        }

        private string Encrypt(string input,string key)
        {
            keyMatrix = Helper.CreateKeyFromString(key);

            if (keyMatrix == null )
            {
                return "Key muss angegeben sein, Darf Keine Buchstaben haben und muss im Format (2:2 1 2 1 2) sein";
            }

            input = FixInputString(input.ToUpper());

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i += 2)
            {
                int letterOne = input[i] - 'A';
                int letterTwo = input[i + 1] - 'A';

                result.Append((char)
                    ((keyMatrix[0, 0] * letterOne + keyMatrix[0, 1] * letterTwo) % Mod + 'A'));
                result.Append((char)
                    ((keyMatrix[1, 0] * letterOne + keyMatrix[1, 1] * letterTwo) % Mod + 'A'));
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

            if (result.Length % 2 != 0)
                result.Append('A');
            /*Note: Extra zeichen da der Input eine gerade Länge
             haben muss*/

            return result.ToString();
        }

    }
}
