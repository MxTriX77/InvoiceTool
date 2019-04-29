using System;

namespace Invoice_Tool
{
    class Invoice
    {
        public Invoice()
        {
            InvoiceThread();
        }

        enum WorkValues
        {
            Hours = 0,
            Minutes,
            Rate,
        }

        private static void ThrowException(string message)
        {
            Console.Write(message);
            Console.ReadKey();
            Console.Clear();
        }

        private static string GetWorkValue(int index)
        {
            string value;
            if (Enum.IsDefined(typeof(WorkValues), index))
            {
                value = ((WorkValues)index).ToString();
            }
            else { value = "Invalid work data value!"; }
            return value;
        }

        private static bool IsInt(string String)
        {
            bool result = false;
            Int32.TryParse(String, out int IsNumericCheck);
            switch (IsNumericCheck)
            {
                case 0:
                    result = false;
                    break;
                default:
                    result = true;
                    break;
            }
            return result;
        }

        private static void InvoiceThread()
        {
            try
            {
                int usercount;
                string userdatainput;
                string[] userdata = { };
                string lackingvalues = "";
                short hours;
                short minutes;
                float rate;
                float totaltime = 0F;
                float totalamount = 0F;

                Console.Write("Enter the amount of invoiced users (0 to exit): ");
                usercount = Convert.ToInt16(Console.ReadLine().Replace(" ", ""));

                if (usercount < 0)
                {
                    ThrowException(Config.INVALID_INPUT_EXCEPTION);
                    return;
                }

                if (usercount == 0) { Environment.Exit(0); }

                Console.Clear();
                Console.WriteLine("Please specify users' work data one by one (Hours Minutes Rate), 0 to exit:\n");

                while (usercount != 0)
                {
                    userdatainput = Console.ReadLine().Trim();
                    if (userdatainput != "")
                    {
                        userdata = userdatainput.Split(' ');
                    }

                    if (userdata.Length < Config.N)
                    {
                        for (int i = userdata.Length; i < Config.N; i++)
                        {
                            lackingvalues += " " + GetWorkValue(i);
                        }
                        ThrowException($"{Config.INSUFFICIENT_DATA_EXCEPTION}\nThe following values are missing:{lackingvalues}. Please double-check the data and try again.");
                        return;
                    }
                    else if (userdata.Length > Config.N)
                    {
                        ThrowException($"\n{Config.INSUFFICIENT_DATA_EXCEPTION}");
                        return;
                    }

                    for (int i = 0; i < Config.N - 1; i++)
                    {
                        if (!IsInt(userdata[i]) && Convert.ToInt16(userdata[i]) != 0)
                        {
                            ThrowException($"{Config.INVALID_INPUT_EXCEPTION}\n\n");
                            return;
                        }
                    }

                    if (userdatainput.Replace(" ", "") != "0" && userdata.Length == Config.N)
                    {
                        // Dividing and allocating user information.
                        hours = Convert.ToInt16(userdata[0]);
                        minutes = Convert.ToInt16(userdata[1]);
                        rate = (float)Convert.ToDouble(userdata[2]);

                        // Creating a developer with such information.
                        var developer = new Developer(hours, minutes, rate);
                        Console.WriteLine("Time spent (hours): {0,-8}     Amount: {1}{2,-8}\n", developer.DecimalTime, Config.CURRENCY_SYMBOL, developer.Amount);
                        totalamount += developer.Amount;
                        totaltime += developer.DecimalTime;
                        usercount--;
                    }
                    else { Environment.Exit(0); }
                }
                Console.WriteLine($"-----\nTotal time (hours): {totaltime}     Total amount to pay: {Config.CURRENCY_SYMBOL}{String.Format("{0:0.00}", totalamount)}   \n");
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    ThrowException($"\n{Config.INVALID_INPUT_EXCEPTION}");
                }
                else if (ex is OverflowException)
                {
                    ThrowException($"\n{Config.ARITHMETIC_OVERFLOW_EXCEPTION}");
                }
                else
                {
                    ThrowException($"\n{Config.DEFAULT_EXCEPTION} in {ex.Source}\n {ex.StackTrace}");
                }
                return;
            }
        }
    }
}
