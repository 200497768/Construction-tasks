using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construction_tasks.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "completed",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed",
                table: "Task");
        }
    }
}
