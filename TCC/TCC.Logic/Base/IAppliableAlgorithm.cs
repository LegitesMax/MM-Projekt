using System.Text;

namespace TCC.Logic.Base
{
    internal interface IAppliableAlgorithm
    {
        string Input { get; set; }
        string Output { get; }
        InputOutputStatistic Statistic { get; }
    }
}
