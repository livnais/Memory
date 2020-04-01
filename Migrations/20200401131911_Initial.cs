using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    FindBy = table.Column<string>(nullable: true),
                    PartieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberCards = table.Column<int>(nullable: false),
                    StateGame = table.Column<string>(nullable: true),
                    TournToPlay = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScorePartie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Winner = table.Column<string>(nullable: true),
                    Player1 = table.Column<string>(nullable: true),
                    Player2 = table.Column<string>(nullable: true),
                    ScorePlayer1 = table.Column<int>(nullable: false),
                    ScorePlayer2 = table.Column<int>(nullable: false),
                    PartieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScorePartie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carte");

            migrationBuilder.DropTable(
                name: "Partie");

            migrationBuilder.DropTable(
                name: "ScorePartie");
        }
    }
}
