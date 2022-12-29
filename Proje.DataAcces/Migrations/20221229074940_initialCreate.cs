using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Proje.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hammadde",
                columns: table => new
                {
                    HamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HamAdi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HamAdet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hammadde", x => x.HamId);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UrunAdi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UrunAdet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunId);
                });

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    StokId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UrunId = table.Column<int>(type: "integer", nullable: false),
                    HamId = table.Column<int>(type: "integer", nullable: false),
                    StokSayi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.StokId);
                    table.ForeignKey(
                        name: "FK_Stok_Hammadde_HamId",
                        column: x => x.HamId,
                        principalTable: "Hammadde",
                        principalColumn: "HamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stok_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stok_HamId",
                table: "Stok",
                column: "HamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UrunId",
                table: "Stok",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "Hammadde");

            migrationBuilder.DropTable(
                name: "Urun");
        }
    }
}
