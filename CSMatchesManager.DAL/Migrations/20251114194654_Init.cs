using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMatchesManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team2_Rounds = table.Column<int>(type: "int", nullable: false),
                    team1_Rounds = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tournament_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorWon = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foundingdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    KD = table.Column<int>(type: "int", nullable: false),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    Sniping = table.Column<int>(type: "int", nullable: false),
                    Firstmatch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team_id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams_Matches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1_id = table.Column<int>(type: "int", nullable: false),
                    Team2_id = table.Column<int>(type: "int", nullable: false),
                    MatchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Matches_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Matches_Teams_Team1_id",
                        column: x => x.Team1_id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Matches_Teams_Team2_id",
                        column: x => x.Team2_id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Majors = table.Column<int>(type: "int", nullable: false),
                    Cologne = table.Column<int>(type: "int", nullable: false),
                    Katowice = table.Column<int>(type: "int", nullable: false),
                    Grandslam = table.Column<int>(type: "int", nullable: false),
                    ESL = table.Column<int>(type: "int", nullable: false),
                    HLTV_TOP_1 = table.Column<int>(type: "int", nullable: false),
                    Player_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Players_Player_id",
                        column: x => x.Player_id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    HSRate = table.Column<int>(type: "int", nullable: false),
                    AVGDamange = table.Column<float>(type: "real", nullable: false),
                    Match_id = table.Column<int>(type: "int", nullable: false),
                    Player_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Matches_Match_id",
                        column: x => x.Match_id,
                        principalTable: "Matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statistics_Players_Player_id",
                        column: x => x.Player_id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_Player_id",
                table: "Rewards",
                column: "Player_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Match_id",
                table: "Statistics",
                column: "Match_id");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Player_id",
                table: "Statistics",
                column: "Player_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Matches_MatchID",
                table: "Teams_Matches",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Matches_Team1_id",
                table: "Teams_Matches",
                column: "Team1_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Matches_Team2_id",
                table: "Teams_Matches",
                column: "Team2_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Teams_Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
