using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class AtletaDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Disciplina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Disciplina_DisciplinaId",
                table: "Atletas");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_DisciplinaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Atletas");
        }
    }
}
