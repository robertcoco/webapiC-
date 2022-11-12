namespace Api_Rest_con_C_.Controllers;

using Microsoft.AspNetCore.Mvc;
using Api_Rest_con_C_.Services;
using projectEntity;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
	IHelloWorldService helloWorldService;
	TareasContext context;

	public HelloWorldController(IHelloWorldService helloWorld, TareasContext tareaContext)
	{
		helloWorldService = helloWorld;
		context = tareaContext;
	}

    [HttpGet(Name = "GetHelloWorld")]
	//[Route("Get/HelloWorld")]

    public IActionResult Get()
	{
		return Ok(helloWorldService.GetHelloWorld());
	}

	[HttpGet]
	[Route("createdb")]
	public IActionResult CreateDatabase()
	{
		context.Database.EnsureCreated();
		return Ok();
	}
}
