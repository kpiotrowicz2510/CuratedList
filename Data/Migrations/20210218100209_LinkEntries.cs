using Microsoft.EntityFrameworkCore.Migrations;

namespace CuratedList.Data.Migrations
{
    public partial class LinkEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TargetUrl = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTag_LinkEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "LinkEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkEntries_UserId",
                table: "LinkEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTag_EntryId",
                table: "LinkTag",
                column: "EntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTag");

            migrationBuilder.DropTable(
                name: "LinkEntries");
        }
    }
}
