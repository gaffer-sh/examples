# pytest Example

A simple Python calculator demonstrating pytest with HTML report generation for [Gaffer](https://gaffer.sh).

## Setup

```bash
# Create virtual environment (optional but recommended)
python -m venv .venv
source .venv/bin/activate  # On Windows: .venv\Scripts\activate

# Install dependencies
pip install -r requirements.txt
```

## Running Tests

```bash
# Run tests (basic)
pytest

# Run tests with HTML report
pytest --html=reports/pytest-report.html --self-contained-html
```

## Report Output

- **pytest HTML**: `reports/pytest-report.html`

## Uploading to Gaffer

### Using curl

```bash
curl -X POST https://app.gaffer.sh/api/upload \
  -H "X-API-Key: $GAFFER_API_KEY" \
  -F "files=@reports/pytest-report.html"
```

### Using GitHub Action

See `.github/workflows/pytest.yml` for the full workflow.
