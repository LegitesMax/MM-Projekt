using System.Text;

namespace TCC.Logic.Base
{
    public interface IAppliableAlgorithm
    {
        string Input { get; set; }
        string Output { get; }
        InputOutputStatistic Statistic { get; }
    }
}
