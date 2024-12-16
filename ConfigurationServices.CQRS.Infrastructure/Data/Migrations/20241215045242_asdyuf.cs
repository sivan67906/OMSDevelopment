using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigurationServices.CQRS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class asdyuf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consumers_PlanTypeId",
                table: "Consumers");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_PlanTypeId",
                table: "Consumers",
                column: "PlanTypeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consumers_PlanTypeId",
                table: "Consumers");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_PlanTypeId",
                table: "Consumers",
                column: "PlanTypeId");
        }
    }
}
