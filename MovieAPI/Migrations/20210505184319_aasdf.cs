using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.Migrations
{
    public partial class aasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Creation",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creation", x => new { x.DirectorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Creation_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creation_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Christopher", "Nolan" },
                    { 2, "Lana", "Wachowski" },
                    { 3, "Lilly", "Wachowski" },
                    { 4, "Quentin", "Tarantino" },
                    { 5, "Tim", "Burton" },
                    { 6, "Edgar", "Wright" },
                    { 7, "Anthony", "Russo" },
                    { 8, "Joseph", "Russo" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 12, "Scott Pilgrim vs. the World", new DateTime(2010, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Django Unchained", new DateTime(2012, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Interstellar", new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Baby Driver", new DateTime(2017, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "The Hateful Eight", new DateTime(2015, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Captain America: Civil War", new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Inception", new DateTime(2010, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Ant-Man", new DateTime(2015, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Alice in Wonderland", new DateTime(2010, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Charlie and the Chocolate Factory", new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Hot Fuzz", new DateTime(2007, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Corpse Bride", new DateTime(2005, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Avengers: Infinity War", new DateTime(2018, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Kill Bill", new DateTime(2003, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Memento", new DateTime(2000, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Pulp Fiction", new DateTime(1994, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "The Nightmare Before Christmas", new DateTime(1993, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "The Dark Knight", new DateTime(2008, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Avengers: Endgame", new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Creation",
                columns: new[] { "DirectorId", "MovieId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 8, 19 },
                    { 7, 19 },
                    { 6, 18 },
                    { 8, 17 },
                    { 7, 17 },
                    { 4, 16 },
                    { 6, 15 },
                    { 1, 14 },
                    { 4, 13 },
                    { 6, 12 },
                    { 1, 11 },
                    { 5, 10 },
                    { 1, 9 },
                    { 6, 8 },
                    { 5, 7 },
                    { 5, 6 },
                    { 4, 5 },
                    { 1, 4 },
                    { 3, 3 },
                    { 2, 3 },
                    { 4, 2 },
                    { 7, 20 },
                    { 8, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creation_MovieId",
                table: "Creation",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creation");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
