using Microsoft.EntityFrameworkCore;
using projectEntity.Models;

namespace projectEntity
{
    public class TareasContext: DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Tarea> tareas = new List<Tarea>();
            tareas.Add(new Tarea {
                tareaId = Guid.Parse("dbfc07f7-bebf-4b66-a56f-5e7090f75511"),
                Titulo = "Hacer la tarea de ciencias naturales",
                Descripcion = "Tarea de ciencias naturales sobre el cuerpo humano",
                categoriaId = Guid.Parse("89a4a2cb-0b25-4373-a558-066525e4334a"),
                Fechacreada = DateTime.Now,
                prioridad = Prioridad.alto
            });

            tareas.Add(new Tarea
            {
                tareaId = Guid.Parse("74a70252-5c9c-4f39-bb8c-058fe6f02ce0"),
                Titulo = "Ejercicios de piernas",
                Descripcion = "Ejercicios de piernas con pesas de 5kg, desplazamiento delantero y trasero",
                categoriaId = Guid.Parse("2799307e-9ba5-4ee4-859c-e909339206d0"),
                Fechacreada = DateTime.Now,
                prioridad = Prioridad.alto
            });


            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.tareaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(150);
                tarea.Property(p => p.Descripcion).IsRequired();
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.categoriaId);
                tarea.Property(p => p.prioridad);
                tarea.HasData(tareas);
            });

            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(new Categoria
            {
                categoriaId = Guid.Parse("89a4a2cb-0b25-4373-a558-066525e4334a"),
                Nombre = "Tareas de la escuela",
                Descripcion = "Tareas de matematicas, lenguas espanola, ciencias sociales, ciencias naturales",
                Peso = 1
            });

            categorias.Add(new Categoria
            {
                categoriaId = Guid.Parse("2799307e-9ba5-4ee4-859c-e909339206d0"),
                Nombre = "Hacer ejercicios",
                Descripcion = "Hacer ejercicios de piernas, brazos, hombros y espalda",
                Peso = 2
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.categoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);
                categoria.Property(p => p.Peso);
                categoria.HasData(categorias);
            });
        }

    }

}
