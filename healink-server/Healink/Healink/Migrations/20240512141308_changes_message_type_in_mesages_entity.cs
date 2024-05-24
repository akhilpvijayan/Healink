using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healink.Migrations
{
    /// <inheritdoc />
    public partial class changesmessagetypeinmesagesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "MessageContent",
                table: "Messages",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MessageContent",
                table: "Messages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500);
        }
    }
}
