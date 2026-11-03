using Bench.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Controllers;

[ApiController]
[Route("api")]
public sealed class ApiController(ItemStore store) : ControllerBase
{
    [HttpGet("ping")]
    public ActionResult<PingResponse> Ping() => new PingResponse("ok", "pong");

    [HttpGet("items")]
    public ActionResult<FilterResponse> Filter(
        [FromQuery] string? category,
        [FromQuery] decimal minPrice = 0,
        [FromQuery] bool activeOnly = false) =>
        store.Filter(category, minPrice, activeOnly);

    [HttpGet("items/{id:int}")]
    public ActionResult<Item> Get(int id) =>
        store.Get(id) is { } item ? item : NotFound();

    [HttpPost("items")]
    public ActionResult<Item> Create([FromBody] ItemInput input)
    {
        var item = store.Create(input);
        return Created($"/api/items/{item.Id}", item);
    }

    [HttpPut("items/{id:int}")]
    public ActionResult<Item> Update(int id, [FromBody] ItemInput input) =>
        store.Update(id, input) is { } item ? item : NotFound();

    [HttpDelete("items/{id:int}")]
    public IActionResult Delete(int id) => store.Delete(id) ? NoContent() : NotFound();

    [HttpGet("cpu")]
    public ActionResult<CpuResponse> Cpu(
        [FromQuery] string input = AppDefaults.DefaultInput,
        [FromQuery] int rounds = AppDefaults.DefaultRounds)
    {
        if (rounds is < 1 or > AppDefaults.MaxRounds)
            return BadRequest(new ErrorResponse("rounds out of range"));
        return CpuWork.Run(input, rounds, DateTimeOffset.UtcNow);
    }
}
