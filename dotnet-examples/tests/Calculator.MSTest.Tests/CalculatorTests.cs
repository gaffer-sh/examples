using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.MSTest.Tests;

[TestClass]
public class CalculatorTests
{
    private Calculator _calculator = null!;

    [TestInitialize]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    // PASSING TESTS
    [TestMethod]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        Assert.AreEqual(5.0, _calculator.Add(2, 3));
    }

    [TestMethod]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        Assert.AreEqual(0.0, _calculator.Add(-1, 1));
    }

    [TestMethod]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.AreEqual(2.0, _calculator.Subtract(5, 3));
    }

    [TestMethod]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        Assert.AreEqual(6.0, _calculator.Multiply(2, 3));
    }

    [TestMethod]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.AreEqual(3.0, _calculator.Divide(6, 2));
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        _calculator.Divide(5, 0);
    }

    // FAILING TEST (intentional for TRX parser testing)
    [TestMethod]
    public void FailingTest_DemonstratesFailure()
    {
        // This test intentionally fails to generate error output in TRX
        Assert.AreEqual(100.0, _calculator.Add(1, 1));
    }

    // SKIPPED/IGNORED TEST
    [TestMethod]
    [Ignore("Skipped for demonstration - feature not yet implemented")]
    public void SkippedTest_DemonstratesIgnore()
    {
        Assert.Fail();
    }

    // PARAMETERIZED TEST (DataRow)
    [TestMethod]
    [DataRow(1.0, 2.0, 3.0)]
    [DataRow(-1.0, -1.0, -2.0)]
    [DataRow(0.0, 0.0, 0.0)]
    public void Add_MultipleInputs_ReturnsExpectedSum(double a, double b, double expected)
    {
        Assert.AreEqual(expected, _calculator.Add(a, b));
    }

    // INCONCLUSIVE TEST
    [TestMethod]
    public void InconclusiveTest_DemonstratesInconclusive()
    {
        Assert.Inconclusive("Test result is inconclusive - requires manual verification");
    }
}

[TestClass]
public class StringUtilsTests
{
    [TestMethod]
    public void Reverse_ValidString_ReturnsReversed()
    {
        Assert.AreEqual("olleh", StringUtils.Reverse("hello"));
    }

    [TestMethod]
    public void IsPalindrome_Palindrome_ReturnsTrue()
    {
        Assert.IsTrue(StringUtils.IsPalindrome("racecar"));
    }

    [TestMethod]
    public void IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        Assert.IsFalse(StringUtils.IsPalindrome("hello"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        StringUtils.Reverse(null!);
    }
}
