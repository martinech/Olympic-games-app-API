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
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEntidad = table.Column<int>(type: "int", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
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
    { "Carolina", "Ramírez", "F", "Venezuela" },
    { "Diego", "Alvarez", "M", "Argentina" },
    { "Valeria", "Castro", "F", "México" },
    { "Pablo", "Herrera", "M", "España" },
    { "Isabela", "Vargas", "F", "Colombia" },
    { "Matías", "Ríos", "M", "Chile" },
    { "Andrea", "Morales", "F", "Perú" },
    { "Fernando", "Lima", "M", "Brasil" },
    { "Lucía", "Sosa", "F", "Uruguay" },
    { "Roberto", "Navarro", "M", "Cuba" },
    { "Paula", "Paredes", "F", "Venezuela" },
    { "Esteban", "Ortiz", "M", "Argentina" },
    { "Camila", "Figueroa", "F", "México" },
    { "Javier", "López", "M", "España" },
    { "Daniela", "Prieto", "F", "Colombia" },
    { "Francisco", "Suárez", "M", "Chile" },
    { "Claudia", "Bravo", "F", "Perú" },
    { "Hugo", "Mendoza", "M", "Brasil" },
    { "Natalia", "Correa", "F", "Uruguay" },
    { "Gustavo", "Peña", "M", "Cuba" },
    { "Elena", "Campos", "F", "Venezuela" },
    { "Leandro", "Silva", "M", "Argentina" },
    { "Sara", "Carvajal", "F", "México" },
    { "Iván", "García", "M", "España" },
    { "Adriana", "Salazar", "F", "Colombia" },
    { "Nicolás", "Paredes", "M", "Chile" },
    { "Florencia", "Esquivel", "F", "Perú" },
    { "Thiago", "Cruz", "M", "Brasil" },
    { "Micaela", "Villalba", "F", "Uruguay" },
    { "Sebastián", "Gómez", "M", "Cuba" },
    { "Vanessa", "Molina", "F", "Venezuela" },
    { "Bruno", "Ramón", "M", "Argentina" },
    { "Diana", "Jiménez", "F", "México" },
    { "Luis", "Medina", "M", "España" },
    { "Alejandra", "Arias", "F", "Colombia" },
    { "Tomás", "Vega", "M", "Chile" },
    { "Clara", "Matos", "F", "Perú" },
    { "Andrés", "Rojas", "M", "Brasil" },
    { "Gabriela", "Benítez", "F", "Uruguay" },
    { "Jorge", "Luna", "M", "Cuba" },
    { "Sabrina", "Rivera", "F", "Venezuela" },
    { "Álvaro", "Castillo", "M", "Argentina" },
    { "Renata", "Cruz", "F", "México" },
    { "Sergio", "Martín", "M", "España" },
    { "Catalina", "Lara", "F", "Colombia" },
    { "Diego", "Palacios", "M", "Chile" },
    { "Mónica", "Reyes", "F", "Perú" },
    { "Ricardo", "Ramos", "M", "Brasil" },
    { "Lorena", "Duarte", "F", "Uruguay" },
    { "Mauricio", "Cabrera", "M", "Cuba" },
    { "Andrea", "Mejía", "F", "Venezuela" },
    { "Julio", "Guzmán", "M", "Argentina" },
    { "Elisa", "Nuñez", "F", "México" },
    { "César", "Iglesias", "M", "España" },
    { "Viviana", "Ortiz", "F", "Colombia" },
    { "Ramiro", "Vargas", "M", "Chile" },
    { "María", "Alonso", "F", "Perú" },
    { "Enrique", "Lemos", "M", "Brasil" },
    { "Paola", "Silva", "F", "Uruguay" },
    { "Fabián", "Ávila", "M", "Cuba" },
    { "Rocío", "Morales", "F", "Venezuela" },
    { "Luis", "Barrera", "M", "Argentina" },
    { "Fernanda", "Hernández", "F", "México" },
    { "Joaquín", "Navarro", "M", "España" },
    { "Susana", "Romero", "F", "Colombia" },
    { "Oscar", "Villalobos", "M", "Chile" },
    { "Camila", "Fuentes", "F", "Perú" },
    { "Leonardo", "Castro", "M", "Brasil" },
    { "Nadia", "Muñoz", "F", "Uruguay" },
    { "Emilio", "Durán", "M", "Cuba" },
    { "Yolanda", "González", "F", "Venezuela" },
    { "Matías", "Salinas", "M", "Argentina" },
    { "Luciana", "Montes", "F", "México" },
    { "Damián", "Arce", "M", "España" },
    { "Patricia", "Fernández", "F", "Colombia" },
    { "Cristian", "Delgado", "M", "Chile" },
    { "Verónica", "Espinoza", "F", "Perú" },
    { "Mario", "Quiroga", "M", "Brasil" },
    { "Raquel", "Mendoza", "F", "Uruguay" },
    { "Héctor", "Orozco", "M", "Cuba" },
    { "Carla", "Valdés", "F", "Venezuela" },
    { "Gabriel", "Segovia", "M", "Argentina" },
    { "Noelia", "García", "F", "México" },
    { "Ezequiel", "Sandoval", "M", "España" },
    { "Martina", "Rosales", "F", "Colombia" },
    { "Facundo", "Saavedra", "M", "Chile" },
    { "Diana", "Cárdenas", "F", "Perú" },
    { "Bruno", "Medrano", "M", "Brasil" },
    { "Alicia", "Rentería", "F", "Uruguay" },
    { "Rafael", "Serrano", "M", "Cuba" },
    { "Sandra", "Villalba", "F", "Venezuela" }
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
    { "Remo", 1900 },
    { "Voleibol", 1964 },
    { "Bádminton", 1992 },
    { "Halterofilia", 1920 },
    { "Triatlón", 2000 },
    { "Equitación", 1900 },
    { "Hockey sobre césped", 1908 },
    { "Baloncesto", 1936 },
    { "Fútbol", 1900 },
    { "Rugby", 2016 },
    { "Surf", 2020 },
    { "Escalada deportiva", 2020 },
    { "Karate", 2020 },
    { "Pentatlón moderno", 1912 },
    { "Skateboarding", 2020 },
    { "Softbol", 1996 },
    { "Béisbol", 1992 },
    { "Snowboarding", 1998 },
    { "Taekwondo", 2000 },
    { "Lucha", 1904 },
    { "Golf", 2016 }
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
    { "Maratón Internacional", "Atletismo", new DateTime(2024, 7, 1), new DateTime(2024, 7, 1) },
    { "Carrera de Velocidad 100m", "Atletismo", new DateTime(2024, 7, 2), new DateTime(2024, 7, 2) },
    { "Salto Triple", "Atletismo", new DateTime(2024, 7, 3), new DateTime(2024, 7, 3) },
    { "Natación 200m Libres", "Natación", new DateTime(2024, 7, 4), new DateTime(2024, 7, 4) },
    { "Natación de Relevos", "Natación", new DateTime(2024, 7, 5), new DateTime(2024, 7, 5) },
    { "Gimnasia Artística de Suelo", "Gimnasia", new DateTime(2024, 7, 6), new DateTime(2024, 7, 6) },
    { "Rutina de Barras Paralelas", "Gimnasia", new DateTime(2024, 7, 7), new DateTime(2024, 7, 7) },
    { "Final de Boxeo", "Boxeo", new DateTime(2024, 7, 8), new DateTime(2024, 7, 8) },
    { "Torneo de Combates", "Boxeo", new DateTime(2024, 7, 9), new DateTime(2024, 7, 9) },
    { "Campeonato de Esgrima", "Esgrima", new DateTime(2024, 7, 10), new DateTime(2024, 7, 10) },
    { "Competencia de Espadas", "Esgrima", new DateTime(2024, 7, 11), new DateTime(2024, 7, 11) },
    { "Torneo de Precisión", "Tiro con arco", new DateTime(2024, 7, 12), new DateTime(2024, 7, 12) },
    { "Competencia de Arqueros", "Tiro con arco", new DateTime(2024, 7, 13), new DateTime(2024, 7, 13) },
    { "Final Olímpica de Judo", "Judo", new DateTime(2024, 7, 14), new DateTime(2024, 7, 14) },
    { "Combate Libre", "Judo", new DateTime(2024, 7, 15), new DateTime(2024, 7, 15) },
    { "Regata de Velocidad", "Remo", new DateTime(2024, 7, 16), new DateTime(2024, 7, 16) },
    { "Final de Dobles", "Voleibol", new DateTime(2024, 7, 17), new DateTime(2024, 7, 17) },
    { "Competencia de Equipos", "Voleibol", new DateTime(2024, 7, 18), new DateTime(2024, 7, 18) },
    { "Torneo de Baloncesto", "Baloncesto", new DateTime(2024, 7, 19), new DateTime(2024, 7, 19) },
    { "Final de Baloncesto", "Baloncesto", new DateTime(2024, 7, 20), new DateTime(2024, 7, 20) },
    { "Copa Internacional de Rugby", "Rugby", new DateTime(2024, 7, 21), new DateTime(2024, 7, 21) },
    { "Surf Profesional", "Surf", new DateTime(2024, 7, 22), new DateTime(2024, 7, 22) },
    { "Competencia de Escalada", "Escalada deportiva", new DateTime(2024, 7, 23), new DateTime(2024, 7, 23) },
    { "Demostración de Karate", "Karate", new DateTime(2024, 7, 24), new DateTime(2024, 7, 24) },
    { "Prueba Combinada", "Pentatlón moderno", new DateTime(2024, 7, 25), new DateTime(2024, 7, 25) },
    { "Exhibición de Skateboarding", "Skateboarding", new DateTime(2024, 7, 26), new DateTime(2024, 7, 26) },
    { "Semifinal de Softbol", "Softbol", new DateTime(2024, 7, 27), new DateTime(2024, 7, 27) },
    { "Competencia de Béisbol", "Béisbol", new DateTime(2024, 7, 28), new DateTime(2024, 7, 28) },
    { "Prueba de Taekwondo", "Taekwondo", new DateTime(2024, 7, 29), new DateTime(2024, 7, 29) },
    { "Torneo Internacional de Golf", "Golf", new DateTime(2024, 7, 30), new DateTime(2024, 7, 30) },
    { "Copa de Atletismo", "Atletismo", new DateTime(2024, 8, 1), new DateTime(2024, 8, 1) },
    { "Prueba de Natación Maratón", "Natación", new DateTime(2024, 8, 2), new DateTime(2024, 8, 2) },
    { "Gimnasia Olímpica", "Gimnasia", new DateTime(2024, 8, 3), new DateTime(2024, 8, 3) },
    { "Tour de Ciclismo", "Ciclismo", new DateTime(2024, 8, 4), new DateTime(2024, 8, 4) },
    { "Campeonato de Boxeo", "Boxeo", new DateTime(2024, 8, 5), new DateTime(2024, 8, 5) },
    { "Torneo de Tenis", "Tenis", new DateTime(2024, 8, 6), new DateTime(2024, 8, 6) },
    { "Competencia de Espadas Olímpicas", "Esgrima", new DateTime(2024, 8, 7), new DateTime(2024, 8, 7) },
    { "Competencia de Tiro Avanzado", "Tiro con arco", new DateTime(2024, 8, 8), new DateTime(2024, 8, 8) },
    { "Torneo Internacional de Judo", "Judo", new DateTime(2024, 8, 9), new DateTime(2024, 8, 9) },
    { "Competencia de Remo", "Remo", new DateTime(2024, 8, 10), new DateTime(2024, 8, 10) },
    { "Final de Voleibol", "Voleibol", new DateTime(2024, 8, 11), new DateTime(2024, 8, 11) },
    { "Competencia de Bádminton", "Bádminton", new DateTime(2024, 8, 12), new DateTime(2024, 8, 12) },
    { "Torneo de Halterofilia", "Halterofilia", new DateTime(2024, 8, 13), new DateTime(2024, 8, 13) },
    { "Triatlón Olímpico", "Triatlón", new DateTime(2024, 8, 14), new DateTime(2024, 8, 14) },
    { "Exhibición de Equitación", "Equitación", new DateTime(2024, 8, 15), new DateTime(2024, 8, 15) },
    { "Campeonato de Hockey sobre Césped", "Hockey sobre césped", new DateTime(2024, 8, 16), new DateTime(2024, 8, 16) },
    { "Final de Baloncesto Internacional", "Baloncesto", new DateTime(2024, 8, 17), new DateTime(2024, 8, 17) },
    { "Competencia de Rugby", "Rugby", new DateTime(2024, 8, 18), new DateTime(2024, 8, 18) },
    { "Surf Abierto Internacional", "Surf", new DateTime(2024, 8, 19), new DateTime(2024, 8, 19) },
    { "Campeonato de Escalada", "Escalada deportiva", new DateTime(2024, 8, 20), new DateTime(2024, 8, 20) },
    { "Final de Karate", "Karate", new DateTime(2024, 8, 21), new DateTime(2024, 8, 21) },
    { "Competencia Combinada", "Pentatlón moderno", new DateTime(2024, 8, 22), new DateTime(2024, 8, 22) },
    { "Skateboarding Pro", "Skateboarding", new DateTime(2024, 8, 23), new DateTime(2024, 8, 23) },
    { "Final de Softbol", "Softbol", new DateTime(2024, 8, 24), new DateTime(2024, 8, 24) },
    { "Copa Internacional de Béisbol", "Béisbol", new DateTime(2024, 8, 25), new DateTime(2024, 8, 25) },
    { "Torneo de Taekwondo", "Taekwondo", new DateTime(2024, 8, 26), new DateTime(2024, 8, 26) },
    { "Campeonato Internacional de Golf", "Golf", new DateTime(2024, 8, 27), new DateTime(2024, 8, 27) },
    { "Final de Lucha Olímpica", "Lucha", new DateTime(2024, 8, 28), new DateTime(2024, 8, 28) },
    { "Regata de Velocidad 2000m", "Remo", new DateTime(2024, 8, 29), new DateTime(2024, 8, 29) },
    { "Competencia de Ciclismo en Ruta", "Ciclismo", new DateTime(2024, 8, 30), new DateTime(2024, 8, 30) },
    { "Competencia de Rugby", "Rugby", new DateTime(2024, 8, 18), new DateTime(2024, 8, 18) },
    { "Campeonato de Surf", "Surf", new DateTime(2024, 8, 19), new DateTime(2024, 8, 19) },
    { "Competencia de Escalada", "Escalada deportiva", new DateTime(2024, 8, 20), new DateTime(2024, 8, 20) },
    { "Demostración de Karate", "Karate", new DateTime(2024, 8, 21), new DateTime(2024, 8, 21) },
    { "Prueba Combinada", "Pentatlón moderno", new DateTime(2024, 8, 22), new DateTime(2024, 8, 22) },
    { "Exhibición de Skateboarding", "Skateboarding", new DateTime(2024, 8, 23), new DateTime(2024, 8, 23) },
    { "Semifinal de Softbol", "Softbol", new DateTime(2024, 8, 24), new DateTime(2024, 8, 24) },
    { "Competencia de Béisbol", "Béisbol", new DateTime(2024, 8, 25), new DateTime(2024, 8, 25) },
    { "Prueba de Taekwondo", "Taekwondo", new DateTime(2024, 8, 26), new DateTime(2024, 8, 26) },
    { "Torneo Internacional de Golf", "Golf", new DateTime(2024, 8, 27), new DateTime(2024, 8, 27) },
    { "Copa de Atletismo", "Atletismo", new DateTime(2024, 8, 28), new DateTime(2024, 8, 28) },
    { "Prueba de Natación Maratón", "Natación", new DateTime(2024, 8, 29), new DateTime(2024, 8, 29) },
    { "Gimnasia Olímpica", "Gimnasia", new DateTime(2024, 8, 30), new DateTime(2024, 8, 30) },
    { "Tour de Ciclismo", "Ciclismo", new DateTime(2024, 8, 31), new DateTime(2024, 8, 31) },
    { "Campeonato de Tenis", "Tenis", new DateTime(2024, 9, 1), new DateTime(2024, 9, 1) },
    { "Competencia de Espadas Olímpicas", "Esgrima", new DateTime(2024, 9, 2), new DateTime(2024, 9, 2) },
    { "Competencia de Tiro Avanzado", "Tiro con arco", new DateTime(2024, 9, 3), new DateTime(2024, 9, 3) },
    { "Torneo Internacional de Judo", "Judo", new DateTime(2024, 9, 4), new DateTime(2024, 9, 4) },
    { "Competencia de Remo", "Remo", new DateTime(2024, 9, 5), new DateTime(2024, 9, 5) },
    { "Final de Voleibol", "Voleibol", new DateTime(2024, 9, 6), new DateTime(2024, 9, 6) },
    { "Competencia de Bádminton", "Bádminton", new DateTime(2024, 9, 7), new DateTime(2024, 9, 7) },
    { "Torneo de Halterofilia", "Halterofilia", new DateTime(2024, 9, 8), new DateTime(2024, 9, 8) },
    { "Triatlón Olímpico", "Triatlón", new DateTime(2024, 9, 9), new DateTime(2024, 9, 9) },
    { "Exhibición de Equitación", "Equitación", new DateTime(2024, 9, 10), new DateTime(2024, 9, 10) },
    { "Campeonato de Hockey sobre Césped", "Hockey sobre césped", new DateTime(2024, 9, 11), new DateTime(2024, 9, 11) },
    { "Competencia de Waterpolo", "Waterpolo", new DateTime(2024, 9, 12), new DateTime(2024, 9, 12) },
    { "Maratón Acuático", "Natación", new DateTime(2024, 9, 13), new DateTime(2024, 9, 13) },
    { "Campeonato de Lucha Libre", "Lucha Libre", new DateTime(2024, 9, 14), new DateTime(2024, 9, 14) },
    { "Competencia de Gimnasia Rítmica", "Gimnasia", new DateTime(2024, 9, 15), new DateTime(2024, 9, 15) },
    { "Regata Internacional", "Remo", new DateTime(2024, 9, 16), new DateTime(2024, 9, 16) },
    { "Campeonato de Bobsleigh", "Bobsleigh", new DateTime(2024, 9, 17), new DateTime(2024, 9, 17) },
    { "Competencia de Patinaje Artístico", "Patinaje Artístico", new DateTime(2024, 9, 18), new DateTime(2024, 9, 18) },
    { "Torneo de Curling", "Curling", new DateTime(2024, 9, 19), new DateTime(2024, 9, 19) },
    { "Final de Snowboard", "Snowboard", new DateTime(2024, 9, 20), new DateTime(2024, 9, 20) },
    { "Campeonato de Esquí Alpino", "Esquí Alpino", new DateTime(2024, 9, 21), new DateTime(2024, 9, 21) },
    { "Competencia de Luge", "Luge", new DateTime(2024, 9, 22), new DateTime(2024, 9, 22) },
    { "Campeonato de Biatlón", "Biatlón", new DateTime(2024, 9, 23), new DateTime(2024, 9, 23) },
    { "Competencia de Hockey sobre Hielo", "Hockey sobre hielo", new DateTime(2024, 9, 24), new DateTime(2024, 9, 24) },
    { "Maratón de Patinaje de Velocidad", "Patinaje de velocidad", new DateTime(2024, 9, 25), new DateTime(2024, 9, 25) },
    { "Torneo de Salto de Esquí", "Salto de esquí", new DateTime(2024, 9, 26), new DateTime(2024, 9, 26) },
    { "Competencia de Skeleton", "Skeleton", new DateTime(2024, 9, 27), new DateTime(2024, 9, 27) },
    { "Campeonato de Snowboard Cross", "Snowboard Cross", new DateTime(2024, 9, 28), new DateTime(2024, 9, 28) }
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
    { 3, 3 },
    { 5, 5 },
    { 7, 7 },
    { 9, 9 },
    { 11, 1 },
    { 13, 3 },
    { 15, 5 },
    { 17, 7 },
    { 19, 9 },
    { 21, 11 },
    { 23, 13 },
    { 25, 15 },
    { 27, 17 },
    { 29, 19 },
    { 31, 21 },
    { 33, 23 },
    { 35, 25 },
    { 37, 27 },
    { 39, 29 }
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
                name: "Auditorias");

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
