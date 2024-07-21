using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyHocSinh.Migrations
{
    /// <inheritdoc />
    public partial class initcret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiemName",
                table: "Diems",
                newName: "DiemHK3");

            migrationBuilder.AddColumn<string>(
                name: "DiemHK1",
                table: "Diems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiemHK2",
                table: "Diems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiemHK1",
                table: "Diems");

            migrationBuilder.DropColumn(
                name: "DiemHK2",
                table: "Diems");

            migrationBuilder.RenameColumn(
                name: "DiemHK3",
                table: "Diems",
                newName: "DiemName");
        }
    }
}
