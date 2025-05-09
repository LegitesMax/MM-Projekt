using System.Text;

namespace TCC.Logic.Base
{
    public abstract class BaseApplicableAlgorithm : IAppliableAlgorithm
    {
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
            get
            {
                if (_output == string.Empty)
                {
                    _output = ComputeOutput();
                    Statistic.OutputSize = Encoding.Default.GetBytes(Output).Length;
                }

                return _output;
            }
        }

        private InputOutputStatistic _statistic = new();
        public InputOutputStatistic Statistic => _statistic;

        protected abstract string ComputeOutput();
    }
}
