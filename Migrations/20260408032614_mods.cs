using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwadTestRp.Migrations
{
    /// <inheritdoc />
    public partial class mods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "TransactionLogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Module",
                table: "TransactionLogs");
        }
    }
}
