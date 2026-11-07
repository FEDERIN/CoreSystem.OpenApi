FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["src/Core.OpenApi/Core.OpenApi.csproj", "src/Core.OpenApi/Core.OpenApi.csproj"]
COPY ["src/Core.OpenApi.Swashbuckle/Core.OpenApi.Swashbuckle.csproj", "src/Core.OpenApi.Swashbuckle/Core.OpenApi.Swashbuckle.csproj"]
COPY ["samples/Core.OpenApi.Swashbuckle.Sample/Core.OpenApi.Swashbuckle.Sample.csproj", "samples/Core.OpenApi.Swashbuckle.Sample/Core.OpenApi.Swashbuckle.Sample.csproj"]
RUN dotnet restore "samples/Core.OpenApi.Swashbuckle.Sample/Core.OpenApi.Swashbuckle.Sample.csproj"
COPY . .
WORKDIR "/src/samples/Core.OpenApi.Swashbuckle.Sample"
RUN dotnet publish "Core.OpenApi.Swashbuckle.Sample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Core.OpenApi.Swashbuckle.Sample.dll"]