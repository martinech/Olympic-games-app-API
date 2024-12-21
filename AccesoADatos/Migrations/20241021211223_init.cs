using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Disciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioDeIntegracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delegado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelDelegado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantHabitantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAdministrador = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

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
                        name: "FK_AtletaDisciplina_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoAtleta",
                columns: table => new
                {
                    idEvento = table.Column<int>(type: "int", nullable: false),
                    idAtleta = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoAtleta", x => new { x.idEvento, x.idAtleta });
                    table.ForeignKey(
                        name: "FK_EventoAtleta_Atletas_idAtleta",
                        column: x => x.idAtleta,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoAtleta_Eventos_idEvento",
                        column: x => x.idEvento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Atletas",
                columns: new[] { "Nombre", "Apellido", "Sexo", "Pais" },
                values: new object[,]
                {
                    { "Juan", "Pérez", "M", "Argentina" },
                    { "María", "Gómez", "F", "México" },
                    { "Carlos", "Sánchez", "M", "España" },
                    { "Ana", "López", "F", "Colombia" },
                    { "Pedro", "Martínez", "M", "Chile" },
                    { "Sofía", "Rodríguez", "F", "Perú" },
                    { "José", "Fernández", "M", "Brasil" },
                    { "Laura", "González", "F", "Uruguay" },
                    { "Miguel", "Torres", "M", "Cuba" },
                    { "Carolina", "Ramírez", "F", "Venezuela" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Nombre_Disciplina", "AnioDeIntegracion" },
                values: new object[,]
                {
                    { "Atletismo", 1896 },
                    { "Natación", 1908 },
                    { "Gimnasia", 1896 },
                    { "Ciclismo", 1896 },
                    { "Boxeo", 1904 },
                    { "Tenis", 1896 },
                    { "Esgrima", 1896 },
                    { "Tiro con arco", 1900 },
                    { "Judo", 1964 },
                    { "Remo", 1900 }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Nombre", "Delegado", "TelDelegado", "CantHabitantes" },
                values: new object[,]
                {
                    { "Argentina", "Martín Pérez", "1234567890", 45000000 },
                    { "México", "José García", "2345678901", 126000000 },
                    { "España", "Luis Martínez", "3456789012", 47000000 },
                    { "Colombia", "Ana Sánchez", "4567890123", 50000000 },
                    { "Chile", "Claudio Ruiz", "5678901234", 19000000 },
                    { "Perú", "Sofía Torres", "6789012345", 33000000 },
                    { "Brasil", "Pedro Silva", "7890123456", 211000000 },
                    { "Uruguay", "Carolina López", "8901234567", 3400000 },
                    { "Cuba", "Miguel Fernández", "9012345678", 11300000 },
                    { "Venezuela", "Luis Ramírez", "0123456789", 28000000 }
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Nombre", "Disciplina", "FechaInicio", "FechaFin" },
                values: new object[,]
                {
                    { "Maratón", "Atletismo", new DateTime(2024, 7, 21), new DateTime(2024, 7, 21) },
                    { "100 metros libres", "Natación", new DateTime(2024, 7, 22), new DateTime(2024, 7, 22) },
                    { "Salto en altura", "Atletismo", new DateTime(2024, 7, 23), new DateTime(2024, 7, 23) },
                    { "Gimnasia artística", "Gimnasia", new DateTime(2024, 7, 24), new DateTime(2024, 7, 24) },
                    { "Final de Boxeo", "Boxeo", new DateTime(2024, 7, 25), new DateTime(2024, 7, 25) },
                    { "Final de Tenis", "Tenis", new DateTime(2024, 7, 26), new DateTime(2024, 7, 26) },
                    { "Esgrima", "Esgrima", new DateTime(2024, 7, 27), new DateTime(2024, 7, 27) },
                    { "Tiro con arco", "Tiro con arco", new DateTime(2024, 7, 28), new DateTime(2024, 7, 28) },
                    { "Judo final", "Judo", new DateTime(2024, 7, 29), new DateTime(2024, 7, 29) },
                    { "Remo 2000m", "Remo", new DateTime(2024, 7, 30), new DateTime(2024, 7, 30) }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Email", "Password", "Rol", "FechaAlta", "EmailAdministrador" },
                values: new object[,]
                {
                    { "admin1@example.com", "password1", "admin", new DateTime(2024, 1, 1), "superadmin@example.com" },
                    { "admin2@example.com", "password2", "admin", new DateTime(2024, 1, 2), "superadmin@example.com" },
                    { "admin3@example.com", "password3", "admin", new DateTime(2024, 1, 3), "superadmin@example.com" },
                    { "user1@example.com", "password4", "digit", new DateTime(2024, 1, 4), "admin1@example.com" },
                    { "user2@example.com", "password5", "digit", new DateTime(2024, 1, 5), "admin1@example.com" },
                    { "user3@example.com", "password6", "digit", new DateTime(2024, 1, 6), "admin2@example.com" },
                    { "user4@example.com", "password7", "digit", new DateTime(2024, 1, 7), "admin2@example.com" },
                    { "user5@example.com", "password8", "digit", new DateTime(2024, 1, 8), "admin3@example.com" },
                    { "user6@example.com", "password9", "digit", new DateTime(2024, 1, 9), "admin3@example.com" },
                    { "user7@example.com", "password10", "digit", new DateTime(2024, 1, 10), "admin3@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AtletaDisciplina",
                columns: new[] { "AtletasId", "DisciplinasId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 6, 2 },
                    { 9, 2 },
                    { 4, 3 },
                    { 7, 3 },
                    { 10, 3 },
                    { 8, 5 }
                });

            migrationBuilder.InsertData(
                table: "EventoAtleta",
                columns: new[] { "idEvento", "idAtleta", "Puntaje" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 1, 3, 8 },
                    { 1, 5, 9 },
                    { 2, 2, 9 },
                    { 2, 6, 7 },
                    { 2, 9, 8 },
                    { 3, 1, 7 },
                    { 3, 3, 9 },
                    { 3, 5, 10 },
                    { 4, 4, 9 },
                    { 4, 7, 8 },
                    { 4, 10, 10 },
                    { 5, 8, 10 },
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina_DisciplinasId",
                table: "AtletaDisciplina",
                column: "DisciplinasId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoAtleta_idAtleta",
                table: "EventoAtleta",
                column: "idAtleta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.DropTable(
                name: "EventoAtleta");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
