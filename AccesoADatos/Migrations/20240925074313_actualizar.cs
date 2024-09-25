using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class actualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Disciplina_DisciplinaId",
                table: "Atletas");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_DisciplinaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Atletas");

            migrationBuilder.CreateTable(
                name: "AtletaDisciplina",
                columns: table => new
                {
                    AtletasId = table.Column<int>(type: "int", nullable: false),
                    DisciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaDisciplina", x => new { x.AtletasId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Atletas_AtletasId",
                        column: x => x.AtletasId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Disciplina_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina_DisciplinasId",
                table: "AtletaDisciplina",
                column: "DisciplinasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_DisciplinaId",
                table: "Atletas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Disciplina_DisciplinaId",
                table: "Atletas",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id");
        }
    }
}
