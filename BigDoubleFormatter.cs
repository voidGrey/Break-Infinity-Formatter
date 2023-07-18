using BreakInfinity;

public static class BigDoubleFormatter
{
    /// <summary>
    /// A formatter for BreakInfinity, this method converts BigDouble to a readable and understandable string.
    /// </summary>
    /// <param name="value">The BigDouble to convert</param>
    /// <returns>if Exponent is less then 15 its return 9.9T if it is bigger than 15 returns 1aa</returns>
    public static string Format(BigDouble value)
    {
        string goesBack = string.Empty;
        goesBack = value.ToString();

        goesBack = StringFormat(goesBack);

        goesBack = goesBack.Substring(0 , 3);

        if (goesBack.EndsWith('.'))
            goesBack = goesBack.Replace("." , "");

        if (value.Exponent < 3)
        {
            return goesBack;
        }
        else if (value.Exponent <= 5)
        {
            return goesBack += "K";
        }
        else if (value.Exponent <= 14)
        {
            if (value.Exponent <= 8)
            {
                goesBack += "M";
            }
            else if (value.Exponent <= 11)
            {
                goesBack += "B";
            }
            else if (value.Exponent <= 14)
            {
                goesBack += "T";
            }
        }
        else
        {
            long diff = value.Exponent - 14;
            char firstChar = (char)('a' + (diff - 1) / 26);
            char secondChar = (char)('a' + (diff - 1) % 26);

            goesBack += firstChar;
            goesBack += secondChar;
        }
        return goesBack;
    }

    private static string StringFormat(string number)
    {
        int length = number.Length;
        string formattedNumber = "";
        for (int i = 0; i < length; i += 3)
        {
            if (i + 3 < length)
            {
                formattedNumber = "." + number.Substring(length - i - 3 , 3) + formattedNumber;
            }
            else
            {
                formattedNumber = number.Substring(0 , length - i) + formattedNumber;
            }
        }

        return formattedNumber;
    }
}