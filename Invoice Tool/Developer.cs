using System;

namespace Invoice_Tool
{
    public sealed class Developer
    {
        public float DecimalTime { get; }
        public float Amount { get; }

        public Developer(short hours, short minutes, float rate)
        {
            checked
            {
                DecimalTime = (float)(hours * 60 + minutes) / 60;
                Amount = (float)Math.Round(DecimalTime * rate, 2);
            }
        }
    }
}
