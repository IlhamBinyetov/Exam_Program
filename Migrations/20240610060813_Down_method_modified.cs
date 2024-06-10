using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Program.Migrations
{
    /// <inheritdoc />
    public partial class Down_method_modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_Exams_Lessons_LessonCode",
            table: "Exams");

            // Code sütununu eski haline döndürün
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Lessons",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            // LessonCode sütununu eski haline döndürün
            migrationBuilder.AlterColumn<string>(
                name: "LessonCode",
                table: "Exams",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            // Yabancı anahtarları yeniden ekleyin
            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lessons_LessonCode",
                table: "Exams",
                column: "LessonCode",
                principalTable: "Lessons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
