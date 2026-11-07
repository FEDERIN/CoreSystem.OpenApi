FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["samples/Core.OpenApi.Swashbuckle.Baseline.Sample/Core.OpenApi.Swashbuckle.Baseline.Sample.csproj", "samples/Core.OpenApi.Swashbuckle.Baseline.Sample/Core.OpenApi.Swashbuckle.Baseline.Sample.csproj"]
RUN dotnet restore "samples/Core.OpenApi.Swashbuckle.Baseline.Sample/Core.OpenApi.Swashbuckle.Baseline.Sample.csproj"
COPY . .
WORKDIR "/src/samples/Core.OpenApi.Swashbuckle.Baseline.Sample"
RUN dotnet publish "Core.OpenApi.Swashbuckle.Baseline.Sample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Core.OpenApi.Swashbuckle.Baseline.Sample.dll"]