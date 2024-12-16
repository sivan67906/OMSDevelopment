using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigurationServices.CQRS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class jhghj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "OrganisationHierarchies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationHierarchies_OrganisationTypeId",
                table: "OrganisationHierarchies",
                column: "OrganisationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationHierarchies_OrganisationTypes_OrganisationTypeId",
                table: "OrganisationHierarchies",
                column: "OrganisationTypeId",
                principalTable: "OrganisationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationHierarchies_OrganisationTypes_OrganisationTypeId",
                table: "OrganisationHierarchies");

            migrationBuilder.DropIndex(
                name: "IX_OrganisationHierarchies_OrganisationTypeId",
                table: "OrganisationHierarchies");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "OrganisationHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
