using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construction_tasks.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCityField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "Task");
        }
    }
}
