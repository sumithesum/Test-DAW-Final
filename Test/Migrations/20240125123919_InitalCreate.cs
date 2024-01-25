using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Join",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    MaterieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Join", x => new { x.ProfesorId, x.MaterieId });
                    table.ForeignKey(
                        name: "FK_Join_Materii_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Join_Profesori_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Join_MaterieId",
                table: "Join",
                column: "MaterieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Join");

            migrationBuilder.DropTable(
                name: "Materii");

            migrationBuilder.DropTable(
                name: "Profesori");
        }
    }
}
