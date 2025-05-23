using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Implementations.Logic
{
    public class Node
    {
        public Histogramm? Histogramm { get; set; }
        public string Code { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

}
