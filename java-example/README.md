# Java Example (JUnit 5 + JaCoCo Coverage)

This example demonstrates how to integrate Gaffer with JUnit 5 test reports and JaCoCo coverage reports.

## Overview

This project uses:
- **JUnit 5** (Jupiter) for testing
- **JaCoCo** for code coverage
- **Maven** as the build tool

## Requirements

- Java 17+
- Maven 3.8+

## Local Development

```bash
# Run tests with coverage
mvn clean test

# View coverage report
open target/site/jacoco/index.html
```

## Test Reports

After running tests, reports are generated in:
- `target/surefire-reports/*.xml` - JUnit XML test results
- `target/site/jacoco/jacoco.xml` - JaCoCo coverage XML
- `target/site/jacoco/index.html` - HTML coverage report

## CI Integration

The GitHub Actions workflow (`.github/workflows/java.yml`):
1. Runs Maven test with JaCoCo coverage
2. Generates JUnit test results and JaCoCo coverage
3. Uploads both reports to Gaffer

## Coverage Formats

JaCoCo generates multiple formats:
- **JaCoCo XML** - Parsed by Gaffer for coverage metrics
- **JaCoCo CSV** - Machine-readable summary
- **HTML** - Human-readable coverage browser
