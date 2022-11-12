using System;
using System.Net;
using System.Threading.Tasks;

// para crear un middleware tenemos que crear una clase con la palabra middleware al final 
// esta clase debe de contener una propiedad que sera para delegar la próxima request 
//

public class TimeMiddleware
{
	readonly RequestDelegate next;

	public TimeMiddleware(RequestDelegate nextRequest)
	{
		next = nextRequest;
	}

	// en todos los middleware tenemos que usar el metodo invoke que retorno un obejto de tipo task.
	// si queremos que la respuesta que manejemos se imprima o muestre al final de la respuesta normal
	// utilizamos la funcion next.

	public async Task Invoke(HttpContext context)
	{
		await next(context); 

		// aqui vamos agregar la fecha actual al final del json si en la url hay un parametro
		// llamado time.

		if (context.Request.Query.Any(p => p.Key == "time"))
		{
			await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
		}
	}
}

// aqui creamos una clase para  agregar el middleware a la configuracion de .net para que funcione
// correctamente.

public static class TimeMiddlewareExtension
{
	// aqui utilizamos el aplicacion builder para agregar nuestro middleware a la configuracion.
	// le tenemos que pasar un parametro builder para que funcione?.

	public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) 
	{
		// y finalmente retornamos el middleware que hemos creado.
		return builder.UseMiddleware<TimeMiddleware>();
	}
}