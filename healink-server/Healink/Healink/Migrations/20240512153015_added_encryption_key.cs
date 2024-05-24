using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healink.Migrations
{
    /// <inheritdoc />
    public partial class addedencryptionkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MessageAesKey",
                table: "Messages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageAesKey",
                table: "Messages");
        }
    }
}
