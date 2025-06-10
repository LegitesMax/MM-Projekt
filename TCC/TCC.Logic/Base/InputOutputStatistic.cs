namespace TCC.Logic.Base
{
    public class InputOutputStatistic
    {
        public int InputSize { get; set; }
        public int KeySize { get; set; }
        public int OutputSize { get; set; }

        public bool IsInputBinary { get; set; } = false;
        public bool IsOutputBinary { get; set; } = false;

        public int SizeDifference => ToCorrectSize(IsInputBinary, InputSize) - ToCorrectSize(IsOutputBinary, OutputSize);
        public double SavedSizePercent => Math.Round((double)SizeDifference / (double)ToCorrectSize(IsInputBinary, InputSize) * 100.0, 2);

        private int ToCorrectSize(bool isBinary, int utfCount)
        {
            if (isBinary)
            {
                return utfCount / 8;
            }

            return utfCount;
        }
    }
}
