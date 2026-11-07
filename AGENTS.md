# AGENTS.md

## 1. Engineering Standards

Before performing any task, read `CORE-SYSTEM-STANDARDS.md`.

These standards are mandatory and apply to all development
activities in this repository.

The repository-specific instructions in this file complement
the common standards.

If a project-specific rule differs from a common standard,
follow the explicit project-specific exception.

## 2. Repository Overview

CoreSystem.OpenApi is a .NET library repository providing
OpenAPI/Swagger integration packages, extracted from the
CoreSystem monorepo.

- Solution: CoreSystem.OpenApi.slnx
- Source: src/Core.OpenApi*
- Package IDs: CoreSystem.OpenApi, CoreSystem.OpenApi.NSwag,
  CoreSystem.OpenApi.Swashbuckle
- Documentation: MkDocs (when present).
- Samples: samples/Core.OpenApi.Swashbuckle.Sample (uses Swashbuckle annotations + filters).

Follow CORE-SYSTEM-STANDARDS.md for common
engineering rules.

## 3. Repository Architecture

- Each src/Core.OpenApi* project represents an independent
  library (core abstractions, NSwag integration, Swashbuckle
  integration).
- Packages are published independently.
- Use dotnet sln list and src/ as the source of truth.
- Respect the existing dependency direction (NSwag/Swashbuckle
  depend on Core.OpenApi).

## 4. Dependencies

- Package versions are centralized in
  `Directory.Packages.props`.
- `Directory.Build.props` enables `RestoreLockedMode`
  (unless `UseLocalProjectReferences=true` is set in the
  gitignored `Directory.Build.local.props`).
- After adding, removing or changing a package, run
  `dotnet restore CoreSystem.OpenApi.slnx --use-lock-file --force-evaluate`
  and commit the updated `packages.lock.json` files.

## 5. Framework Configuration

- SDK: 10.0.201 (see global.json)
- Target frameworks: net8.0;net9.0;net10.0
- All `src/Core.OpenApi*` libraries and their
  `tests/*UnitTests` projects are multi-targeted from the
  central `<TargetFrameworks>` in `Directory.Packages.props`.
- A project that must be single-TFM sets an explicit
  `<TargetFramework>` in its nearest `Directory.Build.props`.

## 6. Testing

- Unit tests: tests/Core.OpenApi.Swashbuckle.UnitTests
- Use `dotnet test --project` for single projects.

## 7. Build and Commands

dotnet build CoreSystem.OpenApi.slnx -c Release
dotnet test --solution CoreSystem.OpenApi.slnx -c Release
dotnet format CoreSystem.OpenApi.slnx --verify-no-changes

On SDK 10 (Microsoft.Testing.Platform mode) `dotnet test`
rejects a positional path: always use `--solution` or
`--project`.

## 8. CI/CD

- GitHub Actions (when configured).
- `main` is protected: never push directly. Create a branch and
  open a PR with `gh pr create`.

## 9. Editing rules

- Write UTF-8 explicitly. PowerShell `Set-Content` without
  `-Encoding utf8` writes mojibake (`U+FFFD`) and silently
  corrupts files; prefer the editor tools instead. Many source
  files carry a UTF-8 BOM from Visual Studio — that is the
  committed state, do not normalize it away.
- `*.bat` files are gitignored and exist only locally.

## 10. Memory

Read MEMORY.md at the beginning of a task.
Update it when significant decisions or project state change.
Keep it concise and avoid duplicating permanent rules
(max ~50 lines: summarize or drop what no longer adds value).
If something becomes a permanent rule, propose moving it to
`AGENTS.md` instead of keeping it in memory.
Never store sensitive data (keys, tokens, personal data).