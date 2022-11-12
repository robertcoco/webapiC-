namespace Api_Rest_con_C_.Services;

using projectEntity;
using projectEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

public class CategoriaService: ICategoriaService
{

   TareasContext context;

    public CategoriaService(TareasContext DbContext)
    {
        this.context = DbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        categoria.categoriaId = Guid.NewGuid();
        await context.AddAsync(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var CategoriaActual = context.Categorias.Find(id);

        if(CategoriaActual != null)
        {
            CategoriaActual.Nombre = categoria.Nombre;
            CategoriaActual.Descripcion = categoria.Descripcion;
            CategoriaActual.Peso = categoria.Peso;
        }
    }

    public async Task Delete(Guid id)
    {
        var CategoriaActual = context.Categorias.Find(id);

        if(CategoriaActual != null)
        {
            context.Remove(CategoriaActual);
            await context.SaveChangesAsync();

        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);

}