using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRefreshTokenTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JWTToken",
                table: "UpdateRefreshTokens",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JWTToken",
                table: "UpdateRefreshTokens");
        }
    }
}
