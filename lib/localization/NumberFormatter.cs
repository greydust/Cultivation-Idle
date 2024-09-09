using System;

public class NumberFormatter : IFormatProvider, ICustomFormatter
{
  private static string ZhNumber = "零一二三四五六七八九";
  public object GetFormat(Type formatType)
  {
    if (formatType == typeof(ICustomFormatter))
    {
      return this;
    }
    return null;
  }

  public string Format(string format, object arg, IFormatProvider formatProvider)
  {
    // Check whether this is an appropriate callback
    if (!this.Equals(formatProvider))
    {
      return null;
    }

    if (arg.GetType() != typeof(int))
    {
      throw new ArgumentException(string.Format("The format provider can only format integers."));
    }

    // Set default format specifier
    if (string.IsNullOrEmpty(format))
    {
      format = "E";
    }

    switch (format)
    {
      case "E":
        return arg.ToString();
      case "Zh":
        break; // Chinese number formatting
    }

    throw new FormatException(string.Format("The {0} format specifier is invalid.", format));
  }
}

public class TestNumberFormatter
{
  public static void Main()
  {
    Console.WriteLine(String.Format(new NumberFormatter(), "{0}", 0));
  }
}