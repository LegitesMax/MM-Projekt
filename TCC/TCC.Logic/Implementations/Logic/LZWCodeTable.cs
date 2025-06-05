using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Implementations.Logic
{
    public class LzwCodeTable
    {
        private List<Tuple<string, int>> Entries { get; set; }
        private int NextAvailableCode { get; set; }
        private int MaxTableSize { get; set; }
        private int InitialCharacterRange { get; set; }

        public int CurrentNextCode => NextAvailableCode;
        public bool IsFull => NextAvailableCode >= MaxTableSize;

        public LzwCodeTable(int initialCharacterRange = 256, int maxTableSize = 4096)
        {
            Entries = new List<Tuple<string, int>>(initialCharacterRange);
            MaxTableSize = maxTableSize;
            InitialCharacterRange = initialCharacterRange;

            if (InitialCharacterRange > 0)
            {
                Entries.Capacity = InitialCharacterRange;
                for (int i = 0; i < InitialCharacterRange; i++)
                {
                    Entries.Add(new Tuple<string, int>(((char)i).ToString(), i));
                }
            }
            NextAvailableCode = InitialCharacterRange;
        }

        public void Add(string pattern)
        {
            if (!IsFull) 
            {
                Entries.Add(new Tuple<string, int>(pattern, NextAvailableCode));
                NextAvailableCode++;
            }
           
        }

        public int? TryGetCode(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return null;
            }
            for (int i = 0; i < Entries.Count; i++)
            {
                if (Entries[i].Item1 == pattern)
                {
                    return Entries[i].Item2;
                }
            }
            return null;
        }


        public int GetCode(string pattern)
        {
            int? code = TryGetCode(pattern);
            if (code.HasValue)
            {
                return code.Value;
            }
            throw new Exception($"Pattern '{pattern}' not found.");
        }

        public string TryGetString(int code)
        {
            for (int i = 0; i < Entries.Count; i++)
            {
                if (Entries[i].Item2 == code)
                {
                    return Entries[i].Item1;
                }
            }
            return null;
        }

        public string GetString(int code)
        {
            string pattern = TryGetString(code);
            if (pattern != null)
            {
                return pattern;
            }
            throw new Exception($"Code '{code}' not found.");
        }
    }

}
