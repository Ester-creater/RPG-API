using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 55, 253, 228, 70, 216, 67, 193, 27, 141, 5, 34, 231, 46, 33, 48, 60, 60, 77, 107, 63, 58, 164, 183, 113, 101, 116, 89, 138, 128, 247, 166, 92, 193, 62, 23, 85, 192, 248, 179, 244, 29, 6, 17, 7, 100, 59, 15, 227, 138, 194, 213, 165, 203, 119, 96, 199, 0, 7, 131, 49, 56, 97, 62 }, new byte[] { 106, 119, 73, 221, 235, 190, 74, 52, 26, 54, 113, 43, 78, 166, 142, 104, 203, 235, 28, 250, 79, 157, 30, 196, 59, 18, 188, 164, 248, 122, 127, 179, 212, 240, 219, 242, 242, 165, 25, 166, 107, 53, 171, 81, 69, 78, 14, 159, 185, 159, 223, 193, 162, 186, 15, 119, 23, 49, 178, 54, 43, 237, 40, 206, 45, 255, 82, 222, 105, 143, 27, 70, 92, 131, 179, 9, 122, 238, 149, 135, 64, 186, 39, 243, 166, 119, 157, 245, 134, 181, 138, 196, 97, 51, 118, 11, 26, 91, 18, 204, 192, 122, 44, 26, 99, 230, 147, 128, 143, 175, 53, 193, 113, 212, 11, 11, 79, 107, 80, 251, 210, 251, 82, 225, 127, 150, 226, 252 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 129, 144, 185, 149, 117, 211, 229, 207, 18, 121, 56, 74, 39, 231, 109, 97, 252, 242, 249, 186, 233, 222, 242, 98, 203, 80, 30, 241, 248, 119, 246, 180, 198, 129, 159, 114, 77, 126, 181, 203, 32, 211, 178, 204, 59, 138, 85, 95, 0, 238, 114, 202, 236, 133, 20, 145, 246, 91, 216, 242, 154, 202, 46, 235 }, new byte[] { 28, 20, 118, 27, 175, 105, 162, 76, 218, 78, 193, 20, 133, 124, 187, 148, 123, 54, 173, 117, 171, 231, 177, 133, 66, 253, 139, 53, 172, 191, 206, 174, 156, 238, 36, 63, 210, 175, 140, 206, 81, 38, 200, 228, 156, 155, 116, 65, 205, 252, 101, 176, 163, 223, 154, 238, 230, 136, 220, 111, 106, 85, 51, 189, 147, 31, 255, 69, 227, 106, 105, 234, 74, 46, 55, 227, 233, 246, 212, 23, 224, 164, 132, 43, 212, 29, 168, 214, 31, 43, 251, 93, 147, 247, 162, 224, 95, 224, 52, 129, 95, 198, 243, 93, 65, 120, 4, 7, 135, 138, 74, 123, 211, 224, 46, 36, 164, 22, 193, 49, 75, 208, 63, 92, 155, 42, 78, 173 } });
        }
    }
}
