# ⚡ CoreSystem.OpenApi

Base contracts and models for .NET 8, .NET 9 and .NET 10.

CoreSystem.OpenApi contains the base contracts, options and models shared by every OpenAPI provider implementation. It depends on ASP.NET Core but carries no provider-specific code, so it can be referenced on its own for the response attributes.

![NuGet](https://img.shields.io/nuget/v/CoreSystem.OpenApi?style=for-the-badge)
![Downloads](https://img.shields.io/nuget/dt/CoreSystem.OpenApi?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%209.0%20%7C%2010.0-blue?style=for-the-badge)

## ✨ Features

- ✅ Shared options, descriptors and problem-details contracts
- ✅ Response attributes usable without any provider
- ✅ Problem response definitions with configurable replacement modes
- ✅ Bearer security scheme options

See [Getting Started](GettingStarted.md) and [Attributes](Attributes.md).

For document generation, see [CoreSystem.OpenApi.Swashbuckle](Swashbuckle/index.md).
