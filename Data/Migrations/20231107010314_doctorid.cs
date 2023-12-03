using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class doctorid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Doctors_doctorId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_doctorId",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "Pacientes",
                newName: "doctorid");

            migrationBuilder.AddColumn<int>(
                name: "DoctorUserId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DoctorUserId",
                table: "Pacientes",
                column: "DoctorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Doctors_DoctorUserId",
                table: "Pacientes",
                column: "DoctorUserId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Doctors_DoctorUserId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_DoctorUserId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DoctorUserId",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "doctorid",
                table: "Pacientes",
                newName: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_doctorId",
                table: "Pacientes",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Doctors_doctorId",
                table: "Pacientes",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
