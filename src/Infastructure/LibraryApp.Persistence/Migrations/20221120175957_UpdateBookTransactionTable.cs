using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedOutSince",
                schema: "Library",
                table: "BookTransactions");

            migrationBuilder.DropColumn(
                name: "CheckedOutUntil",
                schema: "Library",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "ExpectedCheckInDate",
                schema: "Library",
                table: "BookTransactions",
                newName: "CheckInDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                schema: "Library",
                table: "BookTransactions",
                newName: "ExpectedCheckInDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedOutSince",
                schema: "Library",
                table: "BookTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedOutUntil",
                schema: "Library",
                table: "BookTransactions",
                type: "datetime2",
                nullable: true);
        }
    }
}
