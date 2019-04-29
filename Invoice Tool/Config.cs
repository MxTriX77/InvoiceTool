using System;

namespace Invoice_Tool
{
    class Config
    {
        public static readonly ConsoleColor BACKGROUND = ConsoleColor.Blue;
        public static readonly ConsoleColor FOREGROUND = ConsoleColor.Black;
        public static readonly short N = 3;
        public static readonly string CURRENCY_SYMBOL = "$";
        public static readonly string DEFAULT_EXCEPTION = "An error occured";
        public static readonly string INVALID_INPUT_EXCEPTION = "Invalid input detected! Please check whether the data set is correct, press any key and try again.";
        public static readonly string INSUFFICIENT_DATA_EXCEPTION = "Please specify three values: Hours Minutes Rate.";
        public static readonly string ARITHMETIC_OVERFLOW_EXCEPTION = "Input data is too large! Please double-check the data and try again.";
    }
}
