using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Logic;

namespace TCC.Logic.Implementations
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
                Key = key,
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
            if(input == null) 
            {
                return "Input muss gegeben sein";
            }
            input = FixInputString(input.ToUpper());
            keyMatrix = CreateKeyFromString(key, input);

            if (keyMatrix == null || !Helper.HasIntegerSquareRoot(key.Length))
            {
                return "Key muss angegeben sein, Darf Keine Zahlen haben, Muss mindestens 4 zeichen lang sein, Die Länge muss eine ganze Zahl als Quadratwurzel ergeben";
            }

            int matrixSize = Convert.ToInt32(Math.Sqrt(key.Length));

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i += matrixSize)
            {
                int[] inputBlock = new int[matrixSize];

                for (int j = 0; j < matrixSize; j++)
                    inputBlock[j] = input[i + j] - 'A';

                for (int row = 0; row < matrixSize; row++)
                {
                    int sum = 0;
                    for (int col = 0; col < matrixSize; col++)
                        sum += keyMatrix[row, col] * inputBlock[col];

                    result.Append((char)((sum % Mod + Mod) % Mod + 'A'));
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

            if (result.Length % 2 != 0)
                result.Append('A');
            /*Note: Extra zeichen da der Input eine gerade Länge
             haben muss*/

            return result.ToString();
        }
        public static int[,]? CreateKeyFromString(string key, string input)
        {
            if (key == "" || key == null || input.Length % key.Length !=  0 || key.Length <=3)
            {
                return null;
                // Bricht Encript ab und wirft eine nachricht
            }
            key = key.ToUpper();
            int length = 0;
            int with = 0;
            int format = Convert.ToInt32(Math.Sqrt(key.Length));
            if(format%1 != 0)
            {
                return null ;
            }
            int[,] result = new int[format, format];

            foreach (char c in key)
            {
                if (char.IsLetter(c))
                {
                    result[length,with] = c -'A';
                    //result[length, with]++;

                    if (result[length,with]%26 == 0)
                    {
                        result[length,with]++;
                    }
                    with++;
                    if (with % format == 0)
                    {
                        length++;
                        with = 0;
                    }
                }
                else
                {
                    return null;
                }
            }
            return result;
        }

    }
}
