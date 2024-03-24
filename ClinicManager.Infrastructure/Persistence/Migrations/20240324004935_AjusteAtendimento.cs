using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class AjusteAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Medicos_IdMedico",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_IdPaciente",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdMedico",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdPaciente",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdServico",
                table: "Atendimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdMedico",
                table: "Atendimentos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdPaciente",
                table: "Atendimentos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdServico",
                table: "Atendimentos",
                column: "IdServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Medicos_IdMedico",
                table: "Atendimentos",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_IdPaciente",
                table: "Atendimentos",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Medicos_IdMedico",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_IdPaciente",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdMedico",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdPaciente",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_IdServico",
                table: "Atendimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdMedico",
                table: "Atendimentos",
                column: "IdMedico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdPaciente",
                table: "Atendimentos",
                column: "IdPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdServico",
                table: "Atendimentos",
                column: "IdServico",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Medicos_IdMedico",
                table: "Atendimentos",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_IdPaciente",
                table: "Atendimentos",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Servicos_IdServico",
                table: "Atendimentos",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
