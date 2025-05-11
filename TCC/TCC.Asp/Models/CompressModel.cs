using System.Text;
using TCC.Logic.Base;

namespace TCC.Asp.Models
{
    public class CompressModel
    {

        public string Input = string.Empty;

        public string Output = string.Empty;
        public InputOutputStatistic Statistic => new();
    }
}
