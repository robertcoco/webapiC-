using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Rest_con_C_.Migrations
{
    public partial class restarting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("74a70252-5c9c-4f39-bb8c-058fe6f02ce0"),
                column: "Fechacreada",
                value: new DateTime(2022, 11, 1, 20, 14, 55, 37, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("dbfc07f7-bebf-4b66-a56f-5e7090f75511"),
                column: "Fechacreada",
                value: new DateTime(2022, 11, 1, 20, 14, 55, 37, DateTimeKind.Local).AddTicks(2186));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("74a70252-5c9c-4f39-bb8c-058fe6f02ce0"),
                column: "Fechacreada",
                value: new DateTime(2022, 11, 1, 20, 2, 38, 329, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("dbfc07f7-bebf-4b66-a56f-5e7090f75511"),
                column: "Fechacreada",
                value: new DateTime(2022, 11, 1, 20, 2, 38, 329, DateTimeKind.Local).AddTicks(7663));
        }
    }
}
