namespace TCC.Logic.Base
{
    public class InputOutputStatistic
    {
        public int InputSize { get; set; }
        public int KeySize { get; set; }
        public int OutputSize { get; set; }

        public int SizeDifference => InputSize - OutputSize;
        public double SavedSizePercent => Math.Round((double)SizeDifference / (double)InputSize * 100.0, 2);
    }
}
