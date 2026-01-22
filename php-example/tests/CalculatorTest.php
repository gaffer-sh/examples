<?php

declare(strict_types=1);

namespace GafferExample\Tests;

use GafferExample\Calculator;
use PHPUnit\Framework\TestCase;

/**
 * Tests for Calculator class.
 */
class CalculatorTest extends TestCase
{
    private Calculator $calculator;

    protected function setUp(): void
    {
        $this->calculator = new Calculator();
    }

    // ==================== Addition Tests ====================

    public function testAddPositiveNumbers(): void
    {
        $this->assertEquals(5, $this->calculator->add(2, 3));
    }

    public function testAddNegativeNumbers(): void
    {
        $this->assertEquals(-5, $this->calculator->add(-2, -3));
    }

    public function testAddWithZero(): void
    {
        $this->assertEquals(5, $this->calculator->add(5, 0));
    }

    public function testAddFloats(): void
    {
        $this->assertEqualsWithDelta(5.5, $this->calculator->add(2.5, 3.0), 0.001);
    }

    // ==================== Subtraction Tests ====================

    public function testSubtractPositiveNumbers(): void
    {
        $this->assertEquals(2, $this->calculator->subtract(5, 3));
    }

    public function testSubtractResultingInNegative(): void
    {
        $this->assertEquals(-2, $this->calculator->subtract(3, 5));
    }

    public function testSubtractWithZero(): void
    {
        $this->assertEquals(5, $this->calculator->subtract(5, 0));
    }

    // ==================== Multiplication Tests ====================

    public function testMultiplyPositiveNumbers(): void
    {
        $this->assertEquals(15, $this->calculator->multiply(3, 5));
    }

    public function testMultiplyWithZero(): void
    {
        $this->assertEquals(0, $this->calculator->multiply(5, 0));
    }

    public function testMultiplyNegativeNumbers(): void
    {
        $this->assertEquals(15, $this->calculator->multiply(-3, -5));
    }

    public function testMultiplyMixedSigns(): void
    {
        $this->assertEquals(-15, $this->calculator->multiply(3, -5));
    }

    // ==================== Division Tests ====================

    public function testDividePositiveNumbers(): void
    {
        $this->assertEquals(2, $this->calculator->divide(10, 5));
    }

    public function testDivideResultingInFloat(): void
    {
        $this->assertEqualsWithDelta(2.5, $this->calculator->divide(5, 2), 0.001);
    }

    public function testDivideByZeroThrowsException(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $this->expectExceptionMessage('Cannot divide by zero');
        $this->calculator->divide(10, 0);
    }

    // ==================== Power Tests ====================

    public function testPowerPositiveExponent(): void
    {
        $this->assertEquals(8, $this->calculator->power(2, 3));
    }

    public function testPowerZeroExponent(): void
    {
        $this->assertEquals(1, $this->calculator->power(5, 0));
    }

    public function testPowerNegativeExponent(): void
    {
        $this->assertEqualsWithDelta(0.25, $this->calculator->power(2, -2), 0.001);
    }

    // ==================== Factorial Tests ====================

    public function testFactorialOfZero(): void
    {
        $this->assertEquals(1, $this->calculator->factorial(0));
    }

    public function testFactorialOfOne(): void
    {
        $this->assertEquals(1, $this->calculator->factorial(1));
    }

    public function testFactorialOfFive(): void
    {
        $this->assertEquals(120, $this->calculator->factorial(5));
    }

    public function testFactorialOfNegativeThrowsException(): void
    {
        $this->expectException(\InvalidArgumentException::class);
        $this->expectExceptionMessage('Factorial is not defined for negative numbers');
        $this->calculator->factorial(-1);
    }

    // ==================== Intentional Failure (for demo) ====================

    /**
     * This test intentionally fails to demonstrate test failure reporting.
     * Comment out or fix in production.
     */
    public function testIntentionalFailure(): void
    {
        // This assertion is intentionally wrong to show failure reporting
        $this->assertEquals(42, $this->calculator->add(1, 1), 'This test is intentionally failing');
    }
}
