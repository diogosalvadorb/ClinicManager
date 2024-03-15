using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Migrations
{
    public partial class AjusteAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_IdServico",
                table: "Atendimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_IdServico",
                table: "Atendimentos",
                column: "IdServico",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
