# Memory

Facts and current repo state NOT covered by AGENTS.md. Read this after AGENTS.md.

## Current state

- Packages in `src/`: `Core.OpenApi` (2.1.0 on main) and `Core.OpenApi.Swashbuckle` (1.2.0). No NSwag project exists yet.
- Swashbuckle depends on Core.OpenApi; keep that direction.
- PR #15 (fix/skip-wildcard-development-servers) is pending merge. Its release bump is still to do after the merge.

## Decisions

- `OpenApiProblemResponsesOptions.SchemaId` defaults to `CoreProblemDetails` (was `ProblemDetails`). `ProblemSchemaIds` includes `CoreProblemDetails` by default. Known consumer: the EventHouse API.
- Behavior change in Core.OpenApi is released as a minor bump, 2.2.0 (owner decision, not strict SemVer). Release notes must flag it as BREAKING and explain how to restore `ProblemDetails`.
- Swashbuckle skips `Local` servers whose host is a wildcard (`+`, `*`, `0.0.0.0`, `[::]`) in Development. Planned release: 1.2.1 (patch).
- Tests that modify `ASPNETCORE_URLS` belong to the xUnit collection `ProcessEnvironment` to avoid races.

## Gotchas

- RestoreLockedMode is on; run `dotnet restore CoreSystem.OpenApi.slnx --use-lock-file --force-evaluate` after package changes.
- Many source files carry a UTF-8 BOM; do not normalize it away.
- Prefer collection expressions (IDE0300): use `["msg"]` instead of `new[] { "msg" }`.
- `git worktree list` shows a stale `CoreSystem.OpenApi-fix` worktree (prunable). Clean with `git worktree prune` when safe.
