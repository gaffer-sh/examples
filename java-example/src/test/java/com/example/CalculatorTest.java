package com.example;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Tests for Calculator class.
 */
class CalculatorTest {

    private Calculator calculator;

    @BeforeEach
    void setUp() {
        calculator = new Calculator();
    }

    // ==================== Addition Tests ====================

    @Nested
    @DisplayName("Addition Tests")
    class AdditionTests {
        @Test
        @DisplayName("should add positive numbers")
        void testAddPositiveNumbers() {
            assertEquals(5.0, calculator.add(2.0, 3.0));
        }

        @Test
        @DisplayName("should add negative numbers")
        void testAddNegativeNumbers() {
            assertEquals(-5.0, calculator.add(-2.0, -3.0));
        }

        @Test
        @DisplayName("should add with zero")
        void testAddWithZero() {
            assertEquals(5.0, calculator.add(5.0, 0.0));
        }

        @Test
        @DisplayName("should add floats")
        void testAddFloats() {
            assertEquals(5.5, calculator.add(2.5, 3.0), 0.001);
        }
    }

    // ==================== Subtraction Tests ====================

    @Nested
    @DisplayName("Subtraction Tests")
    class SubtractionTests {
        @Test
        @DisplayName("should subtract positive numbers")
        void testSubtractPositiveNumbers() {
            assertEquals(2.0, calculator.subtract(5.0, 3.0));
        }

        @Test
        @DisplayName("should handle negative result")
        void testSubtractResultingInNegative() {
            assertEquals(-2.0, calculator.subtract(3.0, 5.0));
        }

        @Test
        @DisplayName("should subtract zero")
        void testSubtractWithZero() {
            assertEquals(5.0, calculator.subtract(5.0, 0.0));
        }
    }

    // ==================== Multiplication Tests ====================

    @Nested
    @DisplayName("Multiplication Tests")
    class MultiplicationTests {
        @Test
        @DisplayName("should multiply positive numbers")
        void testMultiplyPositiveNumbers() {
            assertEquals(15.0, calculator.multiply(3.0, 5.0));
        }

        @Test
        @DisplayName("should multiply by zero")
        void testMultiplyWithZero() {
            assertEquals(0.0, calculator.multiply(5.0, 0.0));
        }

        @Test
        @DisplayName("should multiply negative numbers")
        void testMultiplyNegativeNumbers() {
            assertEquals(15.0, calculator.multiply(-3.0, -5.0));
        }

        @Test
        @DisplayName("should multiply mixed signs")
        void testMultiplyMixedSigns() {
            assertEquals(-15.0, calculator.multiply(3.0, -5.0));
        }
    }

    // ==================== Division Tests ====================

    @Nested
    @DisplayName("Division Tests")
    class DivisionTests {
        @Test
        @DisplayName("should divide positive numbers")
        void testDividePositiveNumbers() {
            assertEquals(2.0, calculator.divide(10.0, 5.0));
        }

        @Test
        @DisplayName("should return float result")
        void testDivideResultingInFloat() {
            assertEquals(2.5, calculator.divide(5.0, 2.0), 0.001);
        }

        @Test
        @DisplayName("should throw on divide by zero")
        void testDivideByZeroThrowsException() {
            IllegalArgumentException exception = assertThrows(
                IllegalArgumentException.class,
                () -> calculator.divide(10.0, 0.0)
            );
            assertEquals("Cannot divide by zero", exception.getMessage());
        }
    }

    // ==================== Power Tests ====================

    @Nested
    @DisplayName("Power Tests")
    class PowerTests {
        @Test
        @DisplayName("should calculate positive exponent")
        void testPowerPositiveExponent() {
            assertEquals(8.0, calculator.power(2.0, 3));
        }

        @Test
        @DisplayName("should handle zero exponent")
        void testPowerZeroExponent() {
            assertEquals(1.0, calculator.power(5.0, 0));
        }

        @Test
        @DisplayName("should handle negative exponent")
        void testPowerNegativeExponent() {
            assertEquals(0.25, calculator.power(2.0, -2), 0.001);
        }
    }

    // ==================== Factorial Tests ====================

    @Nested
    @DisplayName("Factorial Tests")
    class FactorialTests {
        @Test
        @DisplayName("factorial of 0 should be 1")
        void testFactorialOfZero() {
            assertEquals(1L, calculator.factorial(0));
        }

        @Test
        @DisplayName("factorial of 1 should be 1")
        void testFactorialOfOne() {
            assertEquals(1L, calculator.factorial(1));
        }

        @Test
        @DisplayName("factorial of 5 should be 120")
        void testFactorialOfFive() {
            assertEquals(120L, calculator.factorial(5));
        }

        @Test
        @DisplayName("should throw on negative input")
        void testFactorialOfNegativeThrowsException() {
            IllegalArgumentException exception = assertThrows(
                IllegalArgumentException.class,
                () -> calculator.factorial(-1)
            );
            assertEquals("Factorial is not defined for negative numbers", exception.getMessage());
        }
    }

    // ==================== Prime Tests ====================

    @Nested
    @DisplayName("Prime Tests")
    class PrimeTests {
        @Test
        @DisplayName("2 should be prime")
        void testTwoIsPrime() {
            assertTrue(calculator.isPrime(2));
        }

        @Test
        @DisplayName("17 should be prime")
        void testSeventeenIsPrime() {
            assertTrue(calculator.isPrime(17));
        }

        @Test
        @DisplayName("4 should not be prime")
        void testFourIsNotPrime() {
            assertFalse(calculator.isPrime(4));
        }

        @Test
        @DisplayName("1 should not be prime")
        void testOneIsNotPrime() {
            assertFalse(calculator.isPrime(1));
        }

        @Test
        @DisplayName("negative numbers should not be prime")
        void testNegativeIsNotPrime() {
            assertFalse(calculator.isPrime(-5));
        }
    }

    // ==================== Intentional Failure (for demo) ====================

    @Test
    @DisplayName("Intentional failure for demo purposes")
    void testIntentionalFailure() {
        // This assertion is intentionally wrong to show failure reporting
        assertEquals(42.0, calculator.add(1.0, 1.0), "This test is intentionally failing");
    }
}
