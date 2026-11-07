# ⚡ CoreSystem.OpenApi

> **Base contracts and models for the CoreSystem OpenAPI infrastructure.**

CoreSystem.OpenApi contains the base contracts, options and models shared by every
OpenAPI provider implementation. It depends on ASP.NET Core but carries no
provider-specific code, so it can be referenced on its own for the response
attributes.

![NuGet](https://img.shields.io/nuget/v/CoreSystem.OpenApi?style=for-the-badge)
![Downloads](https://img.shields.io/nuget/dt/CoreSystem.OpenApi?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%209.0%20%7C%2010.0-blue?style=for-the-badge)

---

## ✨ Features

- ✅ Shared options, descriptors and problem-details contracts
- ✅ Response attributes usable without any provider
- ✅ Problem response definitions with configurable replacement modes
- ✅ Bearer security scheme options
- ✅ Multi-targeted for .NET 8, .NET 9 and .NET 10

---

## 📦 Installation

```bash
dotnet add package CoreSystem.OpenApi
```

---

## 🚀 Quick Start

Reference the package and annotate controllers with the response attributes:

```csharp
using Core.OpenApi.Attributes;

[HttpPost]
[ProducesCreated<OrderResponse>]
public async Task<IActionResult> Create(CreateOrderRequest request)
```

---

## 🧩 Public API

| Type | Description |
|------|-------------|
| `CoreProblemDetails` / `CoreValidationProblemDetails` | Problem details base types. |
| `OpenApiOptions` | Common options shared by all providers. |
| `OpenApiServerDescriptor` | Server entry for the document. |
| `BearerSecurityOptions` | Bearer security scheme configuration. |
| `OpenApiProblemResponsesOptions` | Shared problem response catalog. |
| `ProblemResponseDefinition` | One response: status code, component, error code and example. |
| `ProblemResponseReplacementMode` | Replacement behavior for existing responses. |
| `ProducesOkAttribute<T>` / `ProducesCreatedAttribute<T>` / `ProducesNoContentAttribute` | Response attributes. |
| `ProducesNotFoundProblemAttribute` / `ProducesValidationProblemAttribute` / `ProducesTooManyRequestsProblemAttribute` | Problem response attributes. |

---

## 🏗 Architecture

The package is the dependency-free foundation: providers (such as Swashbuckle)
build on top of these contracts and options.

---

## 📖 Documentation

- Getting Started
- Configuration

---

## 🤝 Contributing

Issues, discussions and pull requests are welcome.

---

## 📄 License

Released under the MIT License.