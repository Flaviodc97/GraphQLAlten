using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgrammingLanguageGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguages_Types_TypeLanguageId",
                        column: x => x.TypeLanguageId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40d90a44-e98e-4593-9de3-b773f68e52b0"), "Scripting languages" },
                    { new Guid("4220f9a0-9f21-45e4-a440-c579390ac1ff"), "Object-oriented programming languages" },
                    { new Guid("478feb93-8dcb-4d39-b829-df130869dda5"), "Procedural programming languages" },
                    { new Guid("e7acf30a-c40a-4829-a978-1fd784d39be1"), "Functional programming languages" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Description", "Name", "ReleaseDate", "TypeLanguageId" },
                values: new object[,]
                {
                    { new Guid("27797c1c-fdfa-4eb5-ae6a-b013c2678548"), "C# è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.", "c#", new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7acf30a-c40a-4829-a978-1fd784d39be1") },
                    { new Guid("a6c3addf-b40e-455d-8d80-397d50103c19"), "Java è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.", "Java", new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4220f9a0-9f21-45e4-a440-c579390ac1ff") },
                    { new Guid("d80f35bd-3b58-4ef0-9aa3-88204f9edfb8"), "Python è un linguaggio di programmazione di \"alto livello\", orientato a oggetti, adatto, tra gli altri usi, a sviluppare applicazioni distribuite, scripting, computazione numerica e system testing.", "Python", new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("478feb93-8dcb-4d39-b829-df130869dda5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguages_TypeLanguageId",
                table: "ProgrammingLanguages",
                column: "TypeLanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
