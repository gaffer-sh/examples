<?php

declare(strict_types=1);

namespace GafferExample;

/**
 * Simple calculator class for demonstrating PHPUnit testing and coverage.
 */
class Calculator
{
    /**
     * Add two numbers.
     */
    public function add(float $a, float $b): float
    {
        return $a + $b;
    }

    /**
     * Subtract second number from first.
     */
    public function subtract(float $a, float $b): float
    {
        return $a - $b;
    }

    /**
     * Multiply two numbers.
     */
    public function multiply(float $a, float $b): float
    {
        return $a * $b;
    }

    /**
     * Divide first number by second.
     *
     * @throws \InvalidArgumentException If divisor is zero
     */
    public function divide(float $a, float $b): float
    {
        if ($b === 0.0) {
            throw new \InvalidArgumentException('Cannot divide by zero');
        }
        return $a / $b;
    }

    /**
     * Calculate the power of a number.
     */
    public function power(float $base, int $exponent): float
    {
        return pow($base, $exponent);
    }

    /**
     * Calculate the factorial of a non-negative integer.
     *
     * @throws \InvalidArgumentException If n is negative
     */
    public function factorial(int $n): int
    {
        if ($n < 0) {
            throw new \InvalidArgumentException('Factorial is not defined for negative numbers');
        }
        if ($n === 0 || $n === 1) {
            return 1;
        }
        return $n * $this->factorial($n - 1);
    }
}
