using Microsoft.AspNetCore.Mvc;
using MinimalGenericApi.DataAccess.Abstractions;

namespace MinimalGenericApi.GenericControllers;

[GenericController]
[Route("[controller]")]
public class GenericController<TEntity> : Controller where TEntity : IEntity
{

    private readonly IGenericRepository<TEntity> _repository;

    public GenericController(IGenericRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody]TEntity item)
    {
        var result = await _repository.CreateAsync(item);
        return CreatedAtAction(nameof(Get), new {id = result}, item);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Guid id)
    {
        var result = await _repository.FindByIdAsync(id).ConfigureAwait(false);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}