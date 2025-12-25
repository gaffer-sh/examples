# .NET Test Examples

Example .NET 8.0 test projects demonstrating TRX report generation for [Gaffer](https://gaffer.sh).

This directory contains three test projects using different .NET test frameworks:
- **xUnit** - Popular open-source testing framework
- **NUnit** - Well-established testing framework
- **MSTest** - Microsoft's official testing framework

## Prerequisites

- [Docker](https://www.docker.com/get-started) (recommended)
- OR [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Gaffer API key](https://app.gaffer.sh)

## Running Tests with Docker (Recommended)

No local .NET installation required.

```bash
cd dotnet-examples

# Create reports directory
mkdir -p reports

# Run all tests and generate TRX reports
docker run --rm -v "$(pwd):/app" -w /app mcr.microsoft.com/dotnet/sdk:8.0 sh -c "
  dotnet restore && \
  dotnet build && \
  dotnet test tests/Calculator.XUnit.Tests --logger 'trx;LogFileName=xunit-results.trx' --results-directory ./reports && \
  dotnet test tests/Calculator.NUnit.Tests --logger 'trx;LogFileName=nunit-results.trx' --results-directory ./reports && \
  dotnet test tests/Calculator.MSTest.Tests --logger 'trx;LogFileName=mstest-results.trx' --results-directory ./reports
"
```

### Run individual frameworks

```bash
# xUnit only
docker run --rm -v "$(pwd):/app" -w /app mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet test tests/Calculator.XUnit.Tests --logger "trx;LogFileName=xunit-results.trx" --results-directory ./reports

# NUnit only
docker run --rm -v "$(pwd):/app" -w /app mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet test tests/Calculator.NUnit.Tests --logger "trx;LogFileName=nunit-results.trx" --results-directory ./reports

# MSTest only
docker run --rm -v "$(pwd):/app" -w /app mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet test tests/Calculator.MSTest.Tests --logger "trx;LogFileName=mstest-results.trx" --results-directory ./reports
```

## Running Tests with Local .NET SDK

```bash
cd dotnet-examples
dotnet restore
mkdir -p reports

# Run xUnit tests
dotnet test tests/Calculator.XUnit.Tests --logger "trx;LogFileName=xunit-results.trx" --results-directory ./reports

# Run NUnit tests
dotnet test tests/Calculator.NUnit.Tests --logger "trx;LogFileName=nunit-results.trx" --results-directory ./reports

# Run MSTest tests
dotnet test tests/Calculator.MSTest.Tests --logger "trx;LogFileName=mstest-results.trx" --results-directory ./reports

# Or run all at once
dotnet test --logger "trx;LogFileName=test-results.trx" --results-directory reports
```

## Report Output

| Framework | Output Path |
|-----------|-------------|
| xUnit | `reports/xunit-results.trx` |
| NUnit | `reports/nunit-results.trx` |
| MSTest | `reports/mstest-results.trx` |

## TRX Format Notes

TRX (Test Results XML) is the native .NET test report format. Key characteristics:
- Root element: `<TestRun>`
- File extension: `.trx`
- Test results in `<UnitTestResult>` elements
- Outcomes: `Passed`, `Failed`, `NotExecuted`, `Inconclusive`
- Duration in `HH:mm:ss.fffffff` format
- Error details in `<Output><ErrorInfo><Message>` and `<StackTrace>`

## Test Cases

Each test project includes various test types to demonstrate TRX output:

| Test Type | xUnit | NUnit | MSTest | TRX Outcome |
|-----------|-------|-------|--------|-------------|
| Passing tests | `[Fact]` | `[Test]` | `[TestMethod]` | `Passed` |
| Failing test | `[Fact]` | `[Test]` | `[TestMethod]` | `Failed` |
| Skipped test | `[Fact(Skip="...")]` | `[Ignore("...")]` | `[Ignore("...")]` | `NotExecuted` |
| Inconclusive | N/A | `Assert.Inconclusive()` | `Assert.Inconclusive()` | `Inconclusive` |
| Parameterized | `[Theory]` | `[TestCase]` | `[DataRow]` | Multiple results |
| Exception tests | `Assert.Throws<>` | `Assert.Throws<>` | `[ExpectedException]` | `Passed` |

## Uploading to Gaffer

### Using curl

```bash
# Upload xUnit TRX
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_UPLOAD_TOKEN" \
  -F "files=@reports/xunit-results.trx"

# Upload NUnit TRX
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_UPLOAD_TOKEN" \
  -F "files=@reports/nunit-results.trx"

# Upload MSTest TRX
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_UPLOAD_TOKEN" \
  -F "files=@reports/mstest-results.trx"
```

### Using GitHub Action

See `.github/workflows/dotnet.yml` for the full CI/CD workflow.

## Project Structure

```
dotnet-examples/
├── src/Calculator/           # Shared source code
│   ├── Calculator.cs
│   └── Calculator.csproj
├── tests/
│   ├── Calculator.XUnit.Tests/
│   ├── Calculator.NUnit.Tests/
│   └── Calculator.MSTest.Tests/
├── DotnetExamples.sln
├── .gitignore
└── README.md
```
