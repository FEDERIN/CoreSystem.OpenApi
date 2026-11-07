---
name: Sample Docker & CI Smoke
description: Use when creating or adapting a Dockerfile, docker-compose.yml, and samples-smoke.yml workflow for a .NET sample project in this repo. Ensures the Docker build context is the repo root, multi-stage build uses the SDK 10, runtime matches the sample's TFM, and the smoke workflow verifies Swagger/OpenAPI endpoints.
---

# Sample Docker & CI Smoke

## When to use

When a new sample project is added under `samples/` and needs containerization plus a CI smoke check.

## Inputs

- Sample project folder name (e.g. `Core.OpenApi.Swashbuckle.Sample`).
- Solution file name (e.g. `CoreSystem.OpenApi.slnx`).

## Dockerfile (samples/<Sample>/Dockerfile)

- Build context MUST be the repository root (so `src/` and `Directory.*.props` resolve).
- Multi-stage: SDK 10 build, runtime image matching the sample's `<TargetFramework>`.
- Copy `Directory.Packages.props` and `Directory.Build.props` first, then project csprojs, then restore, then publish.
- Entrypoint uses the sample's assembly name.

Template:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["Directory.Build.props", "Directory.Build.props"]
# add project csprojs...
RUN dotnet restore "samples/<Sample>/<Sample>.csproj"
COPY . .
WORKDIR "/src/samples/<Sample>"
RUN dotnet publish "<Sample>.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "<Sample>.dll"]
```

## docker-compose.yml (samples/<Sample>/docker-compose.yml)

- Single service `sample-api` building from the repo root with the Dockerfile.
- Map host port 5185 -> 8080.
- Set `ASPNETCORE_ENVIRONMENT=Development`.

## samples-smoke.yml (.github/workflows/)

- Trigger on changes to the sample, `src/`, props, and the workflow itself.
- `docker compose up -d --build`, wait for `/swagger/index.html`, verify `/swagger/v1/swagger.json`.
- Dump logs on failure, tear down with `if: always()`.

## Verification

After creating, run:

```
dotnet build samples/<Sample>/<Sample>.csproj -c Release
docker compose -f samples/<Sample>/docker-compose.yml config
```

## Do not

- Do not include OTel/Jaeger/Prometheus/Grafana/DB services unless the sample actually uses them.
- Do not reference projects that do not exist in this repo.