using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healink.Migrations
{
    /// <inheritdoc />
    public partial class updatedexperienceeducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Users_Userid",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Educations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_Userid",
                table: "Educations",
                newName: "IX_Educations_UserId");

            migrationBuilder.AddColumn<long>(
                name: "companyId",
                table: "Experiences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "graduationDescription",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "orgId",
                table: "Educations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_companyId",
                table: "Experiences",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_orgId",
                table: "Educations",
                column: "orgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_OrganizationDetails_orgId",
                table: "Educations",
                column: "orgId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Users_UserId",
                table: "Educations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_OrganizationDetails_companyId",
                table: "Experiences",
                column: "companyId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_OrganizationDetails_orgId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Users_UserId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_OrganizationDetails_companyId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_companyId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_orgId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "companyId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "graduationDescription",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "orgId",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Educations",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                newName: "IX_Educations_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Users_Userid",
                table: "Educations",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
