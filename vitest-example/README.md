# Vitest Example

A simple TypeScript calculator demonstrating Vitest with JSON report generation for [Gaffer](https://gaffer.sh).

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
```

## Report Output

- **Vitest JSON**: `reports/vitest-results.json`

## Uploading to Gaffer

### Using curl

```bash
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_API_KEY" \
  -F "files=@reports/vitest-results.json"
```

### Using GitHub Action

See `.github/workflows/vitest.yml` for the full workflow.
