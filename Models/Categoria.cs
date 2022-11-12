namespace projectEntity.Models;

using System.Text.Json.Serialization;

public class Categoria 
{
    public Guid categoriaId { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int Peso { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
}

