# Memory

Facts and current repo state NOT covered by AGENTS.md. Read this after AGENTS.md.

## Current state

- Single package: Core.OpenApi (CoreSystem.OpenApi), multi-target net8.0;net9.0;net10.0.
- No integration wrappers: consumers wire Swashbuckle/NSwag filters themselves.
- Verified: solution build 0 errors/0 warnings.
- Package version 1.0.0 (csproj).

## Gotchas

- RestoreLockedMode is on; run `dotnet restore CoreSystem.OpenApi.slnx --use-lock-file --force-evaluate` after package changes.
- Many source files carry a UTF-8 BOM; do not normalize it away.
- Prefer collection expressions (IDE0300): use `["msg"]` instead of `new[] { "msg" }`.