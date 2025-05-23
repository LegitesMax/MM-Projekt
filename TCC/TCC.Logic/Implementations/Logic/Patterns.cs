using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Implementations.Logic
{
    public class Patterns
    {
        public string Pattern { get; set; }
        public int StartIndex { get; set; }

        public Patterns(string pattern, int startIndex)
        {
            Pattern = pattern;
            StartIndex = startIndex;
        }
    }

}
