using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeStudentLocalizerDependant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Students",
                newName: "thirdNameEn");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "thirdNameAr");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "secondNameEn");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "AddressEn");

            migrationBuilder.AddColumn<string>(
                name: "AddressAr",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "firstNameAr",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "firstNameEn",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "secondNameAr",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "firstNameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "firstNameEn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "secondNameAr",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "thirdNameEn",
                table: "Students",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "thirdNameAr",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "secondNameEn",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AddressEn",
                table: "Students",
                newName: "Address");
        }
    }
}
