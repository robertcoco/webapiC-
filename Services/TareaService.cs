namespace Api_Rest_con_C_.Services;

using projectEntity;
using projectEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

public class TareaService : ITareaService
{

    TareasContext context;

    public TareaService(TareasContext DbContext)
    {
        context = DbContext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        await context.AddAsync(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var TareaActual = context.Tareas.Find(id);

        if (TareaActual != null)
        {
            TareaActual.Titulo = tarea.Titulo;
            TareaActual.Descripcion = tarea.Descripcion;
            TareaActual.prioridad = tarea.prioridad;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);

        if (TareaActual != null)
        {
            context.Remove(TareaActual);
            await context.SaveChangesAsync();

        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);

}