using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace opapProject.Data.Migrations
{
    public partial class OpapDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Draw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    Jackpot = table.Column<bool>(type: "bit", nullable: false),
                    Joker = table.Column<int>(type: "int", nullable: false),
                    Number1 = table.Column<int>(type: "int", nullable: false),
                    Number2 = table.Column<int>(type: "int", nullable: false),
                    Number3 = table.Column<int>(type: "int", nullable: false),
                    Number4 = table.Column<int>(type: "int", nullable: false),
                    Number5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draw", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Draw");
        }
    }
}
