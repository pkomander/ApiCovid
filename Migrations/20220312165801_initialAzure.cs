using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCovid.Migrations
{
    public partial class initialAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasoCovids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Sequences = table.Column<int>(type: "int", nullable: false),
                    Perc_Sequences = table.Column<double>(type: "float", nullable: false),
                    Num_Sequesces_total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasoCovids", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasoCovids");
        }
    }
}
