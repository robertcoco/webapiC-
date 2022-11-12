
namespace projectEntity.Models;
using System.Text.Json.Serialization;

public class Tarea
{

    public virtual Categoria Categoria { get; set; }

    public Guid tareaId { get; set; }

    public Guid categoriaId { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public Prioridad prioridad { get; set; }

    public DateTime Fechacreada { get; set; }


}

public enum Prioridad
{
    bajo,
    medio,
    alto

}
