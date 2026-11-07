---
name: docker-sample
description: Create/adapt Dockerfile, docker-compose.yml and samples-smoke.yml for a sample project. Usage: /docker-sample <SampleFolder> [SolutionFile]
---

Load the `docker-sample` skill and apply it to the sample project provided in `$ARGUMENTS`.

Arguments: `$ARGUMENTS` — first token is the sample folder name under `samples/` (e.g. `Core.OpenApi.Swashbuckle.Sample`), optional second token is the solution file (defaults to `CoreSystem.OpenApi.slnx`).

Steps:
1. Read the sample's csproj to determine its TargetFramework and dependencies.
2. Create `samples/<Sample>/Dockerfile` adapted to this repo (root build context, multi-stage SDK 10, runtime matching TFM).
3. Create `samples/<Sample>/docker-compose.yml` mapping port 5185 -> 8080.
4. Create `.github/workflows/samples-smoke.yml` verifying Swagger endpoints.
5. Verify by building the sample and validating the compose config.