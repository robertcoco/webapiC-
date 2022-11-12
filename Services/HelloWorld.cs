namespace Api_Rest_con_C_.Services;

using System;

public class HelloWorldService : IHelloWorldService
{
	public string GetHelloWorld()
	{
		return "Hello World";
	}
}

public interface IHelloWorldService
{
	string GetHelloWorld();
}