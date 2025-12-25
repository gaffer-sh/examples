# Gaffer Examples

Example test projects demonstrating [Gaffer](https://gaffer.sh) integration for various test frameworks.

Parser Check: December 25 2025 - 1:10PM - Merry Christmas

## Examples

| Framework | Report Formats | Directory |
|-----------|---------------|-----------|
| Jest | JSON, HTML | [`jest-example/`](./jest-example/) |
| pytest | HTML | [`pytest-example/`](./pytest-example/) |
| Vitest | JSON | [`vitest-example/`](./vitest-example/) |
| .NET (xUnit, NUnit, MSTest) | TRX | [`dotnet-examples/`](./dotnet-examples/) |

## Quick Start

### Prerequisites

- Node.js 22+ (Jest, Vitest)
- Python 3.9+ (pytest)
- Docker or .NET 8.0 SDK (xUnit, NUnit, MSTest)
- [Gaffer Upload Token](https://app.gaffer.sh)

### Running Examples Locally

#### Jest

```bash
cd jest-example
npm install
npm run test:all  # Generates both JSON and HTML reports
```

#### pytest

```bash
cd pytest-example
pip install -r requirements.txt
pytest --html=reports/pytest-report.html --self-contained-html
```

#### Vitest

```bash
cd vitest-example
npm install
npm run test:json  # Generates JSON report
```

#### .NET (via Docker)

```bash
cd dotnet-examples
mkdir -p reports
docker run --rm -v "$(pwd):/app" -w /app mcr.microsoft.com/dotnet/sdk:8.0 sh -c "
  dotnet restore && dotnet build && \
  dotnet test tests/Calculator.XUnit.Tests --logger 'trx;LogFileName=xunit-results.trx' --results-directory ./reports && \
  dotnet test tests/Calculator.NUnit.Tests --logger 'trx;LogFileName=nunit-results.trx' --results-directory ./reports && \
  dotnet test tests/Calculator.MSTest.Tests --logger 'trx;LogFileName=mstest-results.trx' --results-directory ./reports
"
```

## Uploading to Gaffer

### Using the GitHub Action (Recommended)

```yaml
- name: Upload to Gaffer
  uses: gaffer-sh/gaffer-uploader@v0.4.0
  with:
    gaffer_upload_token: ${{ secrets.GAFFER_UPLOAD_TOKEN }}
    report_path: reports/test-report.json
    commit_sha: ${{ github.sha }}
    branch: ${{ github.ref_name }}
    test_framework: jest
```

### Using curl

```bash
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_UPLOAD_TOKEN" \
  -F "files=@reports/test-report.json" \
  -F "commit_sha=$COMMIT_SHA" \
  -F "branch=$BRANCH"
```

## CI/CD Integration

Each example includes a GitHub Actions workflow that:

1. Runs tests on push/PR to `main`
2. Generates reports in the target format
3. Uploads to Gaffer (both Action and curl examples)
4. Stores artifacts for 30 days

See the workflows in [`.github/workflows/`](./.github/workflows/).

## Report Formats

| Framework | Format | Output Path | Parser |
|-----------|--------|-------------|--------|
| Jest | JSON | `reports/jest-results.json` | `jest-json` |
| Jest | HTML | `reports/jest-report.html` | `jest-html` |
| pytest | HTML | `reports/pytest-report.html` | `pytest-html` |
| Vitest | JSON | `reports/vitest-results.json` | `vitest-json` |
| xUnit | TRX | `reports/xunit-results.trx` | `trx` |
| NUnit | TRX | `reports/nunit-results.trx` | `trx` |
| MSTest | TRX | `reports/mstest-results.trx` | `trx` |

## Accessing Artifacts

After a workflow run, you can download the test report artifacts:

1. Go to the Actions tab in GitHub
2. Select the workflow run
3. Download artifacts from the "Artifacts" section

Or use the GitHub CLI:

```bash
gh run download <run-id> -n jest-reports-<sha>
```

## Repository Setup

To use these examples with your own Gaffer project:

1. Fork or clone this repository
2. Add `GAFFER_UPLOAD_TOKEN` to your repository secrets
3. Push to trigger the workflows

## License

MIT
