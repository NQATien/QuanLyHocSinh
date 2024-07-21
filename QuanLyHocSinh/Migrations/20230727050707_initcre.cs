using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyHocSinh.Migrations
{
    /// <inheritdoc />
    public partial class initcre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonName",
                table: "Diems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MonName",
                table: "Diems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
