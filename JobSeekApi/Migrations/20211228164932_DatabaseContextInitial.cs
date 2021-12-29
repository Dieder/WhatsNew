using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSeekApi.Migrations
{
    public partial class DatabaseContextInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Contents = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "Id", "Contents", "Name" },
                values: new object[] { "354a78845e5a4808bb2371020f44cef6", "A C# job....", "Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDetails");
        }
    }
}
