# 🧩 Attributes

Response attributes declare the responses of an endpoint in the generated document.

- `ProducesOkAttribute<T>` - declares a `200 OK` with a typed body.
- `ProducesCreatedAttribute<T>` - declares a `201 Created` with a typed body.
- `ProducesNoContentAttribute` - declares a `204 No Content`.
- `ProducesNotFoundProblemAttribute` - declares a `404` problem response.
- `ProducesValidationProblemAttribute` - declares a `400` validation problem response.
- `ProducesTooManyRequestsProblemAttribute` - declares a `429` problem response.
- `ProducesConflictProblemAttribute` - declares a `409` problem response.

## Next Steps

Choose a package to continue learning.

- [CoreSystem.OpenApi.Swashbuckle](Swashbuckle/index.md) to generate the document
