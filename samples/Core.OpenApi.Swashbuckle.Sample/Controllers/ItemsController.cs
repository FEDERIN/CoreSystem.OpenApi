using Core.OpenApi.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Core.OpenApi.Swashbuckle.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Core.OpenApi.Swashbuckle.Sample.Examples;

namespace Core.OpenApi.Swashbuckle.Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private static readonly List<Item> Items = [];
    private static int _nextId = 1;

    [HttpGet]
    [SwaggerOperation(Summary = "Gets all items", Description = "Returns the full list of items.")]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ItemExampleProvider))]
    [ProducesOk<IEnumerable<Item>>]
    public ActionResult<IEnumerable<Item>> GetAll() => Ok(Items);

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Gets an item by ID", Description = "Returns the item with the specified ID.")]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ItemExampleProvider))]
    [ProducesOk<Item>]
    [ProducesNotFoundProblem]
    public ActionResult<Item> Get(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new item", Description = "Creates a new item and returns it.")]
    [SwaggerRequestExample(typeof(Item), typeof(ItemExampleProvider))]
    [ProducesCreated<Item>]
    [ProducesValidationProblem]
    [ProducesTooManyRequestsProblem]
    public ActionResult<Item> Create([FromBody] Item item)
    {
        item.Id = _nextId++;
        Items.Add(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Updates an existing item", Description = "Updates the item with the specified ID.")]
    [ProducesNoContent]
    [ProducesNotFoundProblem]
    public IActionResult Update(int id, [FromBody] Item item)
    {
        var existing = Items.FirstOrDefault(i => i.Id == id);
        if (existing is null) return NotFound();
        existing.Name = item.Name;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Deletes an item", Description = "Deletes the item with the specified ID.")]
    [ProducesNoContent]
    [ProducesNotFoundProblem]
    public IActionResult Delete(int id)
    {
        var removed = Items.RemoveAll(i => i.Id == id);
        return removed == 0 ? NotFound() : NoContent();
    }
}