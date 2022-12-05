using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odkup",
                columns: table => new
                {
                    OdkupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PridelekId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    CenaNaKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    letoMeritve = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odkup", x => x.OdkupId);
                });

            migrationBuilder.CreateTable(
                name: "Trte",
                columns: table => new
                {
                    TrteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sorta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trte", x => x.TrteId);
                });

            migrationBuilder.CreateTable(
                name: "Vinogradi",
                columns: table => new
                {
                    VinogradiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrteId = table.Column<int>(type: "int", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: false),
                    StTrt = table.Column<int>(type: "int", nullable: false),
                    letoMeritve = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinogradi", x => x.VinogradiId);
                    table.ForeignKey(
                        name: "FK_Vinogradi_Trte_TrteId",
                        column: x => x.TrteId,
                        principalTable: "Trte",
                        principalColumn: "TrteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pridelek",
                columns: table => new
                {
                    PridelekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrteId = table.Column<int>(type: "int", nullable: false),
                    VinogradId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    KolNaHa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KgNaTrto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    letoMeritve = table.Column<int>(type: "int", nullable: false),
                    VinogradiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pridelek", x => x.PridelekId);
                    table.ForeignKey(
                        name: "FK_Pridelek_Trte_TrteId",
                        column: x => x.TrteId,
                        principalTable: "Trte",
                        principalColumn: "TrteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pridelek_Vinogradi_VinogradiId",
                        column: x => x.VinogradiId,
                        principalTable: "Vinogradi",
                        principalColumn: "VinogradiId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pridelek_TrteId",
                table: "Pridelek",
                column: "TrteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pridelek_VinogradiId",
                table: "Pridelek",
                column: "VinogradiId");

            migrationBuilder.CreateIndex(
                name: "IX_Vinogradi_TrteId",
                table: "Vinogradi",
                column: "TrteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odkup");

            migrationBuilder.DropTable(
                name: "Pridelek");

            migrationBuilder.DropTable(
                name: "Vinogradi");

            migrationBuilder.DropTable(
                name: "Trte");
        }
    }
}
