using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManagementSystem.Migrations
{
    public partial class Initialize_Database1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionPapers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectResult = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPapers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionPapers");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
