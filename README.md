# Gaffer Examples

Example test projects demonstrating [Gaffer](https://gaffer.sh) integration for various test frameworks.

## Examples

| Framework | Report Formats | Directory |
|-----------|---------------|-----------|
| Jest | JSON, HTML | [`jest-example/`](./jest-example/) |
| pytest | HTML | [`pytest-example/`](./pytest-example/) |
| Vitest | JSON | [`vitest-example/`](./vitest-example/) |

## Quick Start

### Prerequisites

- Node.js 22+ (Jest, Vitest)
- Python 3.9+ (pytest)
- [Gaffer API key](https://app.gaffer.sh)

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

## Uploading to Gaffer

### Using the GitHub Action (Recommended)

```yaml
- name: Upload to Gaffer
  uses: gaffer-sh/gaffer-uploader@v0.3.0
  with:
    gaffer_api_key: ${{ secrets.GAFFER_API_KEY }}
    report_path: reports/test-report.json
    commit_sha: ${{ github.sha }}
    branch: ${{ github.ref_name }}
    test_framework: jest
```

### Using curl

```bash
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_API_KEY" \
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
2. Add `GAFFER_API_KEY` to your repository secrets
3. Push to trigger the workflows

## License

MIT
