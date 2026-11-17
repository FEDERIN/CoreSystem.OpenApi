# 🚀 Getting Started

## Prerequisites

Before getting started, ensure you have:

- .NET 8 SDK, .NET 9 SDK or .NET 10 SDK
- An IDE such as Visual Studio 2022 or JetBrains Rider

## 📦 Installation

```bash
dotnet add package CoreSystem.OpenApi
```

## First Example

Reference the package and annotate controllers with the response attributes:

```csharp
using Core.OpenApi.Attributes;

[HttpPost]
[ProducesCreated<OrderResponse>]
public async Task<IActionResult> Create(CreateOrderRequest request)
```

The attributes declare the response types (`200`, `201`, `204`, `400`, `404`, `429`)
in the generated document. They can be used on their own, without any OpenAPI provider.

## Next Steps

Choose a topic to continue learning.

- [Attributes](Attributes.md)
- [CoreSystem.OpenApi.Swashbuckle](Swashbuckle/index.md) to generate the document
