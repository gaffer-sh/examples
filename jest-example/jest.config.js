/** @type {import('jest').Config} */
module.exports = {
  preset: "ts-jest",
  testEnvironment: "node",
  roots: ["<rootDir>/tests"],
  testMatch: ["**/*.test.ts"],
  reporters: [
    "default",
    [
      "jest-html-reporter",
      {
        pageTitle: "Gaffer Jest Example - Test Report",
        outputPath: "./reports/jest-report.html",
        includeFailureMsg: true,
        includeSuiteFailure: true,
      },
    ],
  ],
};
