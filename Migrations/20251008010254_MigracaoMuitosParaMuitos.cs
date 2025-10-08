using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 210, 146, 135, 26, 108, 173, 167, 58, 209, 87, 190, 230, 143, 227, 150, 129, 174, 35, 75, 49, 150, 78, 123, 49, 87, 217, 77, 5, 129, 32, 27, 201, 118, 132, 204, 4, 143, 74, 78, 204, 82, 80, 17, 141, 204, 60, 166, 68, 119, 151, 108, 55, 148, 233, 118, 150, 197, 217, 226, 17, 103, 229, 249, 23 }, new byte[] { 209, 175, 121, 67, 65, 253, 154, 42, 209, 27, 236, 15, 4, 46, 59, 10, 135, 181, 136, 106, 56, 31, 235, 113, 4, 109, 27, 113, 241, 41, 22, 13, 250, 113, 92, 247, 239, 137, 236, 62, 221, 158, 117, 15, 200, 225, 203, 209, 172, 65, 249, 201, 65, 172, 198, 174, 51, 223, 213, 184, 8, 8, 124, 17, 186, 15, 207, 121, 170, 248, 129, 244, 148, 146, 176, 63, 179, 18, 249, 79, 230, 172, 196, 133, 140, 109, 152, 218, 240, 252, 124, 176, 240, 64, 126, 41, 154, 111, 61, 166, 117, 54, 116, 31, 253, 69, 151, 89, 83, 210, 23, 14, 28, 49, 220, 183, 209, 188, 150, 231, 227, 79, 237, 22, 205, 76, 105, 11 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 55, 253, 228, 70, 216, 67, 193, 27, 141, 5, 34, 231, 46, 33, 48, 60, 60, 77, 107, 63, 58, 164, 183, 113, 101, 116, 89, 138, 128, 247, 166, 92, 193, 62, 23, 85, 192, 248, 179, 244, 29, 6, 17, 7, 100, 59, 15, 227, 138, 194, 213, 165, 203, 119, 96, 199, 0, 7, 131, 49, 56, 97, 62 }, new byte[] { 106, 119, 73, 221, 235, 190, 74, 52, 26, 54, 113, 43, 78, 166, 142, 104, 203, 235, 28, 250, 79, 157, 30, 196, 59, 18, 188, 164, 248, 122, 127, 179, 212, 240, 219, 242, 242, 165, 25, 166, 107, 53, 171, 81, 69, 78, 14, 159, 185, 159, 223, 193, 162, 186, 15, 119, 23, 49, 178, 54, 43, 237, 40, 206, 45, 255, 82, 222, 105, 143, 27, 70, 92, 131, 179, 9, 122, 238, 149, 135, 64, 186, 39, 243, 166, 119, 157, 245, 134, 181, 138, 196, 97, 51, 118, 11, 26, 91, 18, 204, 192, 122, 44, 26, 99, 230, 147, 128, 143, 175, 53, 193, 113, 212, 11, 11, 79, 107, 80, 251, 210, 251, 82, 225, 127, 150, 226, 252 } });
        }
    }
}
