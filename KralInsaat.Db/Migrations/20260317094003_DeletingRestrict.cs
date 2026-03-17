using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KralInsaat.Db.Migrations
{
    /// <inheritdoc />
    public partial class DeletingRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_Companies_CompanyId",
                table: "CompanyBranches");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_Companies_CompanyId",
                table: "CompanyBranches",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_Companies_CompanyId",
                table: "CompanyBranches");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_Companies_CompanyId",
                table: "CompanyBranches",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
