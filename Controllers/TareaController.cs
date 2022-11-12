namespace projectEntity.Models;

using Microsoft.AspNetCore.Mvc;
using Api_Rest_con_C_.Services;
using System.Runtime.InteropServices;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController (ITareaService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}