using Swashbuckle.AspNetCore.Annotations;
using Core.OpenApi.Swashbuckle.Baseline.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.OpenApi.Swashbuckle.Baseline.Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private static readonly List<Item> Items = [];
    private static int _nextId = 1;

    /// <summary>XML-COMMENT-TEST: Gets all items from baseline.</summary>
    [HttpGet]
    [SwaggerOperation(Summary = "Gets all items", Description = "Returns the full list of items.")]
    [ProducesResponseType(typeof(IEnumerable<Item>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Item>> GetAll() => Ok(Items);

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Gets an item by ID", Description = "Returns the item with the specified ID.")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Item> Get(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new item", Description = "Creates a new item and returns it.")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status429TooManyRequests)]
    public ActionResult<Item> Create([FromBody] Item item)
    {
        item.Id = _nextId++;
        Items.Add(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Updates an existing item", Description = "Updates the item with the specified ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] Item item)
    {
        var existing = Items.FirstOrDefault(i => i.Id == id);
        if (existing is null) return NotFound();
        existing.Name = item.Name;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Deletes an item", Description = "Deletes the item with the specified ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var removed = Items.RemoveAll(i => i.Id == id);
        return removed == 0 ? NotFound() : NoContent();
    }
}