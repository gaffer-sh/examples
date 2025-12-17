namespace Calculator;

public class Calculator
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
}

public static class StringUtils
{
    public static string Reverse(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        return new string(input.Reverse().ToArray());
    }

    public static bool IsPalindrome(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        var cleaned = input.ToLower().Replace(" ", "");
        return cleaned == new string(cleaned.Reverse().ToArray());
    }
}
