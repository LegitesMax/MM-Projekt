namespace TCC.Logic.Base
{
    public class InputOutputStatistic
    {
        public int InputSize { get; set; }
        public int OutputSize { get; set; }

        public int SizeDifference => InputSize - OutputSize;
        public double SizeDifferencePercent => (1.0 - OutputSize / InputSize) * 100;
    }
}
