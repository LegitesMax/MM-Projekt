using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Logic.Base
{
    public class AlgorithmResult
    {
        public AlgorithmResult() { }

        string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                Statistic.InputSize = Encoding.Default.GetBytes(Input).Length;
            }
        }

        private string _output = string.Empty;
        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                Statistic.OutputSize = Encoding.Default.GetBytes(Output).Length;
            }
        }


        private InputOutputStatistic _statistic = new();
        public InputOutputStatistic Statistic => _statistic;

    }
}
