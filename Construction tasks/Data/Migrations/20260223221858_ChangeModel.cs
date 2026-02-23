using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construction_tasks.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "manager",
                table: "Task",
                newName: "Manager");

            migrationBuilder.RenameColumn(
                name: "estimate",
                table: "Task",
                newName: "Estimate");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Task",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "completed",
                table: "Task",
                newName: "Completed");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Task",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Task",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Task",
                newName: "manager");

            migrationBuilder.RenameColumn(
                name: "Estimate",
                table: "Task",
                newName: "estimate");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Task",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Task",
                newName: "completed");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Task",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Task",
                newName: "address");
        }
    }
}
