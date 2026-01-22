package com.example;

/**
 * Simple calculator class for demonstrating JUnit testing and JaCoCo coverage.
 */
public class Calculator {

    /**
     * Add two numbers.
     */
    public double add(double a, double b) {
        return a + b;
    }

    /**
     * Subtract second number from first.
     */
    public double subtract(double a, double b) {
        return a - b;
    }

    /**
     * Multiply two numbers.
     */
    public double multiply(double a, double b) {
        return a * b;
    }

    /**
     * Divide first number by second.
     *
     * @throws IllegalArgumentException if divisor is zero
     */
    public double divide(double a, double b) {
        if (b == 0) {
            throw new IllegalArgumentException("Cannot divide by zero");
        }
        return a / b;
    }

    /**
     * Calculate the power of a number.
     */
    public double power(double base, int exponent) {
        return Math.pow(base, exponent);
    }

    /**
     * Calculate the factorial of a non-negative integer.
     *
     * @throws IllegalArgumentException if n is negative
     */
    public long factorial(int n) {
        if (n < 0) {
            throw new IllegalArgumentException("Factorial is not defined for negative numbers");
        }
        if (n == 0 || n == 1) {
            return 1;
        }
        return n * factorial(n - 1);
    }

    /**
     * Check if a number is prime.
     */
    public boolean isPrime(int n) {
        if (n <= 1) {
            return false;
        }
        if (n <= 3) {
            return true;
        }
        if (n % 2 == 0 || n % 3 == 0) {
            return false;
        }
        for (int i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0) {
                return false;
            }
        }
        return true;
    }
}
