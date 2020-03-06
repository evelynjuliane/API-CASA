using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDeShow.Migrations
{
    public partial class atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_EventosId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "EventosId",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "CasaShowId",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Vendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventoID",
                table: "Vendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeIngressos",
                table: "Vendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorDeIngressos",
                table: "Vendas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "QuantDeIngressos",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CasaShowId",
                table: "Vendas",
                column: "CasaShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CategoriaId",
                table: "Vendas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_CasasShows_CasaShowId",
                table: "Vendas",
                column: "CasaShowId",
                principalTable: "CasasShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Categorias_CategoriaId",
                table: "Vendas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_CasasShows_CasaShowId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Categorias_CategoriaId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_CasaShowId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_CategoriaId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CasaShowId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "EventoID",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "QuantidadeDeIngressos",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorDeIngressos",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "EventosId",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "QuantDeIngressos",
                table: "Eventos",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_EventosId",
                table: "Vendas",
                column: "EventosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Eventos_EventosId",
                table: "Vendas",
                column: "EventosId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
