namespace TCC.Logic.Base
{
    public interface IComputable
    {
        AlgorithmResult ComputeOutput(string input,string key);
        AlgorithmResult ComputeOutputDe(string input, string key);
    }
}
