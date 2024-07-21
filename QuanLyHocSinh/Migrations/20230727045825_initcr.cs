using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyHocSinh.Migrations
{
    /// <inheritdoc />
    public partial class initcr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HocSinhName",
                table: "Diems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonName",
                table: "Diems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HocSinhName",
                table: "Diems");

            migrationBuilder.DropColumn(
                name: "MonName",
                table: "Diems");
        }
    }
}
