using System.Text;

namespace TCC.Logic.Base
{
    /// <summary>
    /// Interface that describes the base of an algorithm that computes an output based on the provided input 
    /// and provides statistical information about byte-size difference
    /// </summary>
    public interface IAppliableAlgorithm
    {
        /// <summary>
        /// Input for computation of the specific algorithm
        /// </summary>
        string Input { get; set; }
        /// <summary>
        /// Computed output of the specific algorithm based on the Input
        /// </summary>
        string Output { get; }
        /// <summary>
        /// Statistics regarding byte-size of Output relative to Input
        /// </summary>
        InputOutputStatistic Statistic { get; }
    }
}
