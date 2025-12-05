import { add, subtract, multiply, divide } from "../src/calculator";

describe("Calculator", () => {
  describe("add", () => {
    it("should add two positive numbers", () => {
      expect(add(2, 3)).toBe(5);
    });

    it("should handle negative numbers", () => {
      expect(add(-1, 1)).toBe(0);
    });

    it("should handle zeros", () => {
      expect(add(0, 0)).toBe(0);
    });
  });

  describe("subtract", () => {
    it("should subtract two numbers", () => {
      expect(subtract(5, 3)).toBe(2);
    });

    it("should handle equal numbers", () => {
      expect(subtract(1, 1)).toBe(0);
    });

    it("should handle negative results", () => {
      expect(subtract(0, 5)).toBe(-5);
    });
  });

  describe("multiply", () => {
    it("should multiply two numbers", () => {
      expect(multiply(2, 3)).toBe(6);
    });

    it("should handle negative numbers", () => {
      expect(multiply(-2, 3)).toBe(-6);
    });

    it("should handle zero", () => {
      expect(multiply(0, 5)).toBe(0);
    });
  });

  describe("divide", () => {
    it("should divide two numbers", () => {
      expect(divide(6, 2)).toBe(3);
    });

    it("should handle decimal results", () => {
      expect(divide(5, 2)).toBe(2.5);
    });

    it("should handle zero dividend", () => {
      expect(divide(0, 5)).toBe(0);
    });

    it("should throw on divide by zero", () => {
      expect(() => divide(5, 0)).toThrow("Cannot divide by zero");
    });
  });
});
