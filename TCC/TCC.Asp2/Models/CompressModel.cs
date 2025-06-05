using TCC.Logic.Base;

namespace TCC.Asp.Models
{
    public class CompressModel
    {
        public string Input { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Output { get; set; } = string.Empty;

        public InputOutputStatistic Statistic => new();
    }
}
