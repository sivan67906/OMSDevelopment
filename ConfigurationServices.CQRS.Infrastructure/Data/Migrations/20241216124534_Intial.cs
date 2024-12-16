using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigurationServices.CQRS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "State",
                table: "clients");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_clients_CityId",
                table: "clients",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_CompanyId",
                table: "clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_CountryId",
                table: "clients",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_StateId",
                table: "clients",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_Cities_CityId",
                table: "clients",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_Companies_CompanyId",
                table: "clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_Countries_CountryId",
                table: "clients",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_States_StateId",
                table: "clients",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_Cities_CityId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_Companies_CompanyId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_Countries_CountryId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_States_StateId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_CityId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_CompanyId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_CountryId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_StateId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "clients");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
