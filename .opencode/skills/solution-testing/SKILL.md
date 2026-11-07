---
name: Solution Testing
description: Run and interpret tests for a .NET solution (multi-target). Use when asked to test, validate, or check a solution/project.
---

# Solution Testing

## Commands

- Full solution: `dotnet test --solution <slnx> -c Release`
- Single project: `dotnet test --project <csproj> -c Release`
- Never use a positional path with `dotnet test` on SDK 10 (Microsoft.Testing.Platform mode); always use `--solution` or `--project`.

## Multi-targeting

Projects target net8.0;net9.0;net10.0. A test run executes all three TFMs. Report per-TFM counts.

## Before testing

- Ensure restore succeeded: `dotnet restore <slnx> --use-lock-file`.
- Build first if `--no-build` will be used: `dotnet build <slnx> -c Release`.

## Coverage guidance

- Optional input: a coverage report URL/path (e.g., ReportGenerator HTML). When provided, analyze uncovered lines/branches and plan tests to cover them.
- Review the production code under test and identify gaps (uncovered branches, public methods, edge cases) before declaring a run green.
- Code that operates on `IServiceCollection` / DI registration belongs in `*IntegrationTests` (not unit tests), since it needs the real container.

## Interpreting results

- Report total/passed/failed/skipped and duration.
- On failure, show the failing test name, TFM, and assertion message; do not dump full output.
- A failure in one TFM must be fixed for all TFMs unless justified.

## Do not

- Do not disable tests or lower coverage to make green.
- Do not run `dotnet test` without `-c Release` for final validation.