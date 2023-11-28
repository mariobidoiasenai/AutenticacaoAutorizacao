using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutenticacaoAutorizacao.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Produtos");
        }
    }
}
