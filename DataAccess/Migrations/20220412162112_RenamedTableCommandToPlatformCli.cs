using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class RenamedTableCommandToPlatformCli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.CreateTable(
                name: "PlatformClis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommandLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformClis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformClis_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlatformClis",
                columns: new[] { "Id", "CommandLine", "HowTo", "PlatformId" },
                values: new object[] { 1, "dotnet build", "Build project", 1 });

            migrationBuilder.InsertData(
                table: "PlatformClis",
                columns: new[] { "Id", "CommandLine", "HowTo", "PlatformId" },
                values: new object[] { 2, "dotnet run", "Run project", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformClis_PlatformId",
                table: "PlatformClis",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformClis");

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    CommandLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandLine", "HowTo", "PlatformId" },
                values: new object[] { 1, "dotnet build", "Build project", 1 });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandLine", "HowTo", "PlatformId" },
                values: new object[] { 2, "dotnet run", "Run project", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands",
                column: "PlatformId");
        }
    }
}
