using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
        name: "LessonId",
        table: "Educations",
        type: "int",
        nullable: true); 

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_LessonId",
                table: "Educations",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Lessons_LessonId",
                table: "Educations",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Lessons_LessonId",
                table: "Educations");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Educations_LessonId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Educations");
        }
    }
}
