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
        string _key = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                if (string.IsNullOrEmpty(_input))
                {
                    _input = string.Empty;
                }
                Statistic.InputSize = Encoding.Default.GetBytes(Input).Length;
            }
        }
        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                if (string.IsNullOrEmpty(_key))
                {
                    _key = string.Empty;
                }
                Statistic.KeySize = Encoding.Default.GetBytes(Key).Length;
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
