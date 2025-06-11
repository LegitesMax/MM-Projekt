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

        public override AlgorithmResult ComputeOutputDe(string input,string key)
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
        private string Decrypt(string input,string key)
        {
            var result = new StringBuilder();

            input = FixInputString(input.ToUpper(), key);

            if (key == null || key == "key")
            {
                return "Key muss angegeben sein";
            }

            keyMatrix = CreateKeyFromString(key,input);

            if (keyMatrix == null)
            {
                return "Key muss 144 Buchstaben (nur A-Z) enthalten, keine Zahlen oder Sonderzeichen.";
            }

            int[,] inverseKeyMatrix = InvertMatrixMod26(keyMatrix);
            if (inverseKeyMatrix == null)
            {
                return "Key-Matrix ist nicht invertierbar modulo 26.";
            }

            int matrixSize = Convert.ToInt32(Math.Sqrt(key.Length));

            for (int i = 0; i < input.Length; i += matrixSize)
            {
                int[] block = new int[matrixSize];
                for (int j = 0; j < matrixSize; j++)
                    block[j] = input[i + j] - 'A';

                for (int row = 0; row < matrixSize; row++)
                {
                    int sum = 0;
                    for (int col = 0; col < matrixSize; col++)
                        sum += inverseKeyMatrix[row, col] * block[col];

                    result.Append((char)(((sum % 26 + 26) % 26) + 'A'));
                }
            }

            return result.ToString();
        }
        private string Encrypt(string input,string key)
        {
            input = FixInputString(input.ToUpper(), key);

            if (input == null || key == null)  
            {
                return "Input oder Key muss gegeben sein";
            }
            keyMatrix = CreateKeyFromString(key, input);

            if (keyMatrix == null || !Helper.HasIntegerSquareRoot(key.Length))
            {
                return "Key muss angegeben sein, Darf Keine Zahlen haben, Muss mindestens 4 zeichen lang sein, Die Länge muss eine ganze Zahl als Quadratwurzel ergeben und muss ein viellfaches der input TextLänge sein";
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

        private string FixInputString(string input,string key)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    result.Append(c);
            }

            /*if (result.Length % Math.Sqrt(key.Length) != 0)
                result.Append('A');
            /*Note: Extra zeichen da der Input eine gerade Länge
             haben muss*/

            return result.ToString();
        }
        public static int[,]? CreateKeyFromString(string key, string input)
        {
            if (key == "" || key == null || (input.Length % key.Length !=  0 && key.Length % input.Length != 0) || key.Length <=3)
            {
                return null;
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
        private static int[,]? InvertMatrixMod26(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int[,] copy = new int[size, size];      
            int[,] inverse = new int[size, size];   

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    copy[i, j] = ((matrix[i, j] % 26) + 26) % 26;
                    inverse[i, j] = (i == j) ? 1 : 0;
                }
            }

            for (int i = 0; i < size; i++)
            {
                int pivot = copy[i, i];
                int inv = ModInverse(pivot, 26);
                if (inv == -1) 
                { 
                    return null; 
                }                

                for (int j = 0; j < size; j++)
                {
                    copy[i, j] = (copy[i, j] * inv) % 26;
                    inverse[i, j] = (inverse[i, j] * inv) % 26;
                }

                for (int k = 0; k < size; k++)
                {
                    if (k == i) continue;

                    int factor = copy[k, i];
                    for (int j = 0; j < size; j++)
                    {
                        copy[k, j] = (copy[k, j] - factor * copy[i, j]) % 26;
                        inverse[k, j] = (inverse[k, j] - factor * inverse[i, j]) % 26;

                        if (copy[k, j] < 0)
                        {
                            copy[k, j] += 26;
                        }
                        if (inverse[k, j] < 0)
                        {
                            inverse[k, j] += 26;
                        }
                    }
                }
            }

            return inverse;
        }
        private static int ModInverse(int a, int m)
        {
            a = ((a % m) + m) % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return -1; 
        }
    }
}
