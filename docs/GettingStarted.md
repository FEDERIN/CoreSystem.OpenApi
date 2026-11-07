# Getting Started

Install the package:

```bash
dotnet add package CoreSystem.OpenApi
```

Reference the package and annotate controllers with the response attributes:

```csharp
using Core.OpenApi.Attributes;

[HttpPost]
[ProducesCreated<OrderResponse>]
public async Task<IActionResult> Create(CreateOrderRequest request)
```

The attributes declare the response types (`200`, `201`, `204`, `400`, `404`, `429`)
in the generated document. They can be used on their own, without any OpenAPI provider.