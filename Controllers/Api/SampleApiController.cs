using Microsoft.AspNetCore.Mvc;

namespace DwadTestRp.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class SampleApiController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new[] { "value1", "value2" });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { Id = id, Name = $"Item {id}" });
    }

    [HttpPost]
    public IActionResult Create([FromBody] SampleRequest request)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, new { Id = 1, request.Name });
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] SampleRequest request)
    {
        return Ok(new { Id = id, request.Name });
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}

public record SampleRequest(string Name);
