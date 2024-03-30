using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healink.Migrations
{
    /// <inheritdoc />
    public partial class updatedexperienceeducationentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_OrganizationDetails_orgId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_OrganizationDetails_companyId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Experiences",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_companyId",
                table: "Experiences",
                newName: "IX_Experiences_CompanyId");

            migrationBuilder.RenameColumn(
                name: "orgId",
                table: "Educations",
                newName: "OrgId");

            migrationBuilder.RenameColumn(
                name: "graduationDescription",
                table: "Educations",
                newName: "GraduationDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_orgId",
                table: "Educations",
                newName: "IX_Educations_OrgId");

            migrationBuilder.AlterColumn<string>(
                name: "GraduationDescription",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationEndDate",
                table: "Educations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_OrganizationDetails_OrgId",
                table: "Educations",
                column: "OrgId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_OrganizationDetails_CompanyId",
                table: "Experiences",
                column: "CompanyId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_OrganizationDetails_OrgId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_OrganizationDetails_CompanyId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Experiences",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_CompanyId",
                table: "Experiences",
                newName: "IX_Experiences_companyId");

            migrationBuilder.RenameColumn(
                name: "OrgId",
                table: "Educations",
                newName: "orgId");

            migrationBuilder.RenameColumn(
                name: "GraduationDescription",
                table: "Educations",
                newName: "graduationDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_OrgId",
                table: "Educations",
                newName: "IX_Educations_orgId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationEndDate",
                table: "Educations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "graduationDescription",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_OrganizationDetails_orgId",
                table: "Educations",
                column: "orgId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_OrganizationDetails_companyId",
                table: "Experiences",
                column: "companyId",
                principalTable: "OrganizationDetails",
                principalColumn: "OrganizationDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
