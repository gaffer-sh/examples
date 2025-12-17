using Xunit;

namespace Calculator.XUnit.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    // PASSING TESTS
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        Assert.Equal(5, _calculator.Add(2, 3));
    }

    [Fact]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        Assert.Equal(0, _calculator.Add(-1, 1));
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.Equal(2, _calculator.Subtract(5, 3));
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        Assert.Equal(6, _calculator.Multiply(2, 3));
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.Equal(3, _calculator.Divide(6, 2));
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    // FAILING TEST (intentional for TRX parser testing)
    [Fact]
    public void FailingTest_DemonstratesFailure()
    {
        // This test intentionally fails to generate error output in TRX
        Assert.Equal(100, _calculator.Add(1, 1));
    }

    // SKIPPED TEST
    [Fact(Skip = "Skipped for demonstration - feature not yet implemented")]
    public void SkippedTest_DemonstratesSkip()
    {
        Assert.True(false);
    }

    // THEORY (parameterized test)
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, -1, -2)]
    [InlineData(0, 0, 0)]
    public void Add_MultipleInputs_ReturnsExpectedSum(double a, double b, double expected)
    {
        Assert.Equal(expected, _calculator.Add(a, b));
    }
}

public class StringUtilsTests
{
    [Fact]
    public void Reverse_ValidString_ReturnsReversed()
    {
        Assert.Equal("olleh", StringUtils.Reverse("hello"));
    }

    [Fact]
    public void IsPalindrome_Palindrome_ReturnsTrue()
    {
        Assert.True(StringUtils.IsPalindrome("racecar"));
    }

    [Fact]
    public void IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        Assert.False(StringUtils.IsPalindrome("hello"));
    }

    [Fact]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringUtils.Reverse(null!));
    }
}
