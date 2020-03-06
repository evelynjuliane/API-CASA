using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDeShow.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "EventosId",
                table: "Vendas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas",
                column: "EventosId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "EventosId",
                table: "Vendas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas",
                column: "EventosId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
