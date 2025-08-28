using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classSchaduals_Subjects_SubjectId",
                table: "classSchaduals");

            migrationBuilder.DropForeignKey(
                name: "FK_classSchaduals_Teachers_TeacherId",
                table: "classSchaduals");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SuppervisorSSN",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "passMarks",
                table: "Subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "fullMarks",
                table: "Subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectScore",
                table: "StudentSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "MidtermScore",
                table: "StudentSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "FinalScore",
                table: "StudentSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateTable(
                name: "SubjectAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectAttachment_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SuppervisorSSN",
                table: "Teachers",
                column: "SuppervisorSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Titel",
                table: "Subjects",
                column: "Titel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Stage_ClassNumber",
                table: "Classes",
                columns: new[] { "Stage", "ClassNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAttachment_SubjectId",
                table: "SubjectAttachment",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_classSchaduals_Subjects_SubjectId",
                table: "classSchaduals",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_classSchaduals_Teachers_TeacherId",
                table: "classSchaduals",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ssn",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_SuppervisorSSN",
                table: "Teachers",
                column: "SuppervisorSSN",
                principalTable: "Teachers",
                principalColumn: "ssn",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classSchaduals_Subjects_SubjectId",
                table: "classSchaduals");

            migrationBuilder.DropForeignKey(
                name: "FK_classSchaduals_Teachers_TeacherId",
                table: "classSchaduals");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_SuppervisorSSN",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "SubjectAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SuppervisorSSN",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Titel",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Stage_ClassNumber",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SuppervisorSSN",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "passMarks",
                table: "Subjects",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "fullMarks",
                table: "Subjects",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<short>(
                name: "ProjectScore",
                table: "StudentSubjects",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "MidtermScore",
                table: "StudentSubjects",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "FinalScore",
                table: "StudentSubjects",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_classSchaduals_Subjects_SubjectId",
                table: "classSchaduals",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_classSchaduals_Teachers_TeacherId",
                table: "classSchaduals",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "ssn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
