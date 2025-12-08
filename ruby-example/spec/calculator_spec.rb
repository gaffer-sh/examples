# spec/calculator_spec.rb
    require_relative '../lib/calculator' # Adjust path if needed

    RSpec.describe Calculator do
      subject(:calculator) { described_class.new } # Instantiate Calculator once for all tests

      describe '#add' do
        it 'returns the sum of two numbers' do
          expect(calculator.add(2, 3)).to eq(5)
        end

        it 'handles negative numbers' do
          expect(calculator.add(-5, 10)).to eq(5)
        end
      end

      describe '#subtract' do
        it 'returns the difference of two numbers' do
          expect(calculator.subtract(5, 2)).to eq(3)
        end
      end

      describe '#multiply' do
        it 'returns the product of two numbers' do
          expect(calculator.multiply(4, 5)).to eq(20)
        end
      end

      describe '#divide' do
        it 'returns the quotient of two numbers' do
          expect(calculator.divide(10, 2)).to eq(5.0)
        end

        it 'raises an error when dividing by zero' do
          expect { calculator.divide(10, 0) }.to raise_error(ArgumentError, "Cannot divide by zero")
        end
      end
    end
