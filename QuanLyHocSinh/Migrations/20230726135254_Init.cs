using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyHocSinh.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoMons",
                columns: table => new
                {
                    BoMonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoMonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMons", x => x.BoMonID);
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    DiemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.DiemID);
                });

            migrationBuilder.CreateTable(
                name: "Khois",
                columns: table => new
                {
                    KhoiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongHS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khois", x => x.KhoiID);
                });

            migrationBuilder.CreateTable(
                name: "NamHocs",
                columns: table => new
                {
                    NamHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamHocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamHocs", x => x.NamHocID);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    LopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiSo = table.Column<int>(type: "int", nullable: false),
                    KhoiID = table.Column<int>(type: "int", nullable: false),
                    KhoiName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.LopID);
                    table.ForeignKey(
                        name: "FK_Lops_Khois_KhoiID",
                        column: x => x.KhoiID,
                        principalTable: "Khois",
                        principalColumn: "KhoiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocKys",
                columns: table => new
                {
                    HocKyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocKyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamHocID = table.Column<int>(type: "int", nullable: false),
                    NamHocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKys", x => x.HocKyID);
                    table.ForeignKey(
                        name: "FK_HocKys_NamHocs_NamHocID",
                        column: x => x.NamHocID,
                        principalTable: "NamHocs",
                        principalColumn: "NamHocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    GiaoVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaoVienName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LopID = table.Column<int>(type: "int", nullable: false),
                    LopName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.GiaoVienID);
                    table.ForeignKey(
                        name: "FK_GiaoViens_Lops_LopID",
                        column: x => x.LopID,
                        principalTable: "Lops",
                        principalColumn: "LopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocSinhs",
                columns: table => new
                {
                    HocSinhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocSinhName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LopID = table.Column<int>(type: "int", nullable: false),
                    LopName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinhs", x => x.HocSinhID);
                    table.ForeignKey(
                        name: "FK_HocSinhs_Lops_LopID",
                        column: x => x.LopID,
                        principalTable: "Lops",
                        principalColumn: "LopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mons",
                columns: table => new
                {
                    MonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoMonID = table.Column<int>(type: "int", nullable: false),
                    BoMonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaoVienID = table.Column<int>(type: "int", nullable: false),
                    GiaoVienName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mons", x => x.MonID);
                    table.ForeignKey(
                        name: "FK_Mons_BoMons_BoMonID",
                        column: x => x.BoMonID,
                        principalTable: "BoMons",
                        principalColumn: "BoMonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mons_GiaoViens_GiaoVienID",
                        column: x => x.GiaoVienID,
                        principalTable: "GiaoViens",
                        principalColumn: "GiaoVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_LopID",
                table: "GiaoViens",
                column: "LopID");

            migrationBuilder.CreateIndex(
                name: "IX_HocKys_NamHocID",
                table: "HocKys",
                column: "NamHocID");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinhs_LopID",
                table: "HocSinhs",
                column: "LopID");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_KhoiID",
                table: "Lops",
                column: "KhoiID");

            migrationBuilder.CreateIndex(
                name: "IX_Mons_BoMonID",
                table: "Mons",
                column: "BoMonID");

            migrationBuilder.CreateIndex(
                name: "IX_Mons_GiaoVienID",
                table: "Mons",
                column: "GiaoVienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "HocKys");

            migrationBuilder.DropTable(
                name: "HocSinhs");

            migrationBuilder.DropTable(
                name: "Mons");

            migrationBuilder.DropTable(
                name: "NamHocs");

            migrationBuilder.DropTable(
                name: "BoMons");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "Khois");
        }
    }
}
