using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CezaBedeli",
                schema: "Library",
                table: "BookTransactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CezaBedeli",
                schema: "Library",
                table: "BookTransactions");
        }
    }
}
