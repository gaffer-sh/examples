using NUnit.Framework;

namespace Calculator.NUnit.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    // PASSING TESTS
    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        Assert.That(_calculator.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        Assert.That(_calculator.Add(-1, 1), Is.EqualTo(0));
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.That(_calculator.Subtract(5, 3), Is.EqualTo(2));
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        Assert.That(_calculator.Multiply(2, 3), Is.EqualTo(6));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.That(_calculator.Divide(6, 2), Is.EqualTo(3));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    // FAILING TEST (intentional for TRX parser testing)
    [Test]
    public void FailingTest_DemonstratesFailure()
    {
        // This test intentionally fails to generate error output in TRX
        Assert.That(_calculator.Add(1, 1), Is.EqualTo(100));
    }

    // SKIPPED/IGNORED TEST
    [Test]
    [Ignore("Skipped for demonstration - feature not yet implemented")]
    public void SkippedTest_DemonstratesIgnore()
    {
        Assert.Fail();
    }

    // PARAMETERIZED TEST (TestCase)
    [TestCase(1, 2, 3)]
    [TestCase(-1, -1, -2)]
    [TestCase(0, 0, 0)]
    public void Add_MultipleInputs_ReturnsExpectedSum(double a, double b, double expected)
    {
        Assert.That(_calculator.Add(a, b), Is.EqualTo(expected));
    }

    // INCONCLUSIVE TEST (maps to Inconclusive in TRX)
    [Test]
    public void InconclusiveTest_DemonstratesInconclusive()
    {
        Assert.Inconclusive("Test result is inconclusive - requires manual verification");
    }
}

[TestFixture]
public class StringUtilsTests
{
    [Test]
    public void Reverse_ValidString_ReturnsReversed()
    {
        Assert.That(StringUtils.Reverse("hello"), Is.EqualTo("olleh"));
    }

    [Test]
    public void IsPalindrome_Palindrome_ReturnsTrue()
    {
        Assert.That(StringUtils.IsPalindrome("racecar"), Is.True);
    }

    [Test]
    public void IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        Assert.That(StringUtils.IsPalindrome("hello"), Is.False);
    }

    [Test]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringUtils.Reverse(null!));
    }
}
