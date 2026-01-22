# PHP Example (PHPUnit + Clover Coverage)

This example demonstrates how to integrate Gaffer with PHPUnit test reports and Clover coverage reports.

## Overview

This project uses:
- **PHPUnit 10** for testing
- **Clover XML** format for coverage reporting
- **JUnit XML** format for test results

## Requirements

- PHP 8.1+
- Composer
- Xdebug or PCOV for coverage (CI uses PCOV)

## Local Development

```bash
# Install dependencies
composer install

# Run tests
composer test

# Run tests with coverage (requires Xdebug or PCOV)
composer test:coverage
```

## Test Reports

After running tests with coverage, reports are generated in:
- `reports/phpunit-results.xml` - JUnit-style test results
- `reports/clover.xml` - Clover coverage format
- `reports/htmlcov/` - HTML coverage report

## CI Integration

The GitHub Actions workflow (`.github/workflows/phpunit.yml`):
1. Runs PHPUnit tests with coverage enabled
2. Generates JUnit test results and Clover coverage
3. Uploads both reports to Gaffer

## Coverage Formats

PHPUnit can generate multiple coverage formats:
- **Clover XML** - Used by many CI tools, parsed by Gaffer
- **Cobertura** - Alternative XML format (use `--coverage-cobertura`)
- **HTML** - Human-readable coverage browser
