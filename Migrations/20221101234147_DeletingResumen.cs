using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Rest_con_C_.Migrations
{
    public partial class DeletingResumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    tareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prioridad = table.Column<int>(type: "int", nullable: false),
                    Fechacreada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.tareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "categoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2799307e-9ba5-4ee4-859c-e909339206d0"), "Hacer ejercicios de piernas, brazos, hombros y espalda", "Hacer ejercicios", 2 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "categoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("89a4a2cb-0b25-4373-a558-066525e4334a"), "Tareas de matematicas, lenguas espanola, ciencias sociales, ciencias naturales", "Tareas de la escuela", 1 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "tareaId", "Descripcion", "Fechacreada", "Titulo", "categoriaId", "prioridad" },
                values: new object[] { new Guid("74a70252-5c9c-4f39-bb8c-058fe6f02ce0"), "Ejercicios de piernas con pesas de 5kg, desplazamiento delantero y trasero", new DateTime(2022, 11, 1, 19, 41, 47, 445, DateTimeKind.Local).AddTicks(3517), "Ejercicios de piernas", new Guid("2799307e-9ba5-4ee4-859c-e909339206d0"), 2 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "tareaId", "Descripcion", "Fechacreada", "Titulo", "categoriaId", "prioridad" },
                values: new object[] { new Guid("dbfc07f7-bebf-4b66-a56f-5e7090f75511"), "Tarea de ciencias naturales sobre el cuerpo humano", new DateTime(2022, 11, 1, 19, 41, 47, 445, DateTimeKind.Local).AddTicks(3500), "Hacer la tarea de ciencias naturales", new Guid("89a4a2cb-0b25-4373-a558-066525e4334a"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_categoriaId",
                table: "Tarea",
                column: "categoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
