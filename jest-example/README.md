# Jest Example

A simple TypeScript calculator demonstrating Jest with JSON and HTML report generation for [Gaffer](https://gaffer.sh).

## Setup

```bash
npm install
```

## Running Tests

```bash
# Run tests (basic)
npm test

# Run tests with JSON output
npm run test:json

# Run tests with HTML output (default config)
npm run test:html

# Run all report formats
npm run test:all
```

## Report Output

- **Jest JSON**: `reports/jest-results.json`
- **Jest HTML**: `reports/jest-report.html`

## Uploading to Gaffer

### Using curl

```bash
# Upload JSON report
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_API_KEY" \
  -F "files=@reports/jest-results.json"

# Upload HTML report
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_API_KEY" \
  -F "files=@reports/jest-report.html"
```

### Using GitHub Action

See `.github/workflows/jest.yml` for the full workflow.
