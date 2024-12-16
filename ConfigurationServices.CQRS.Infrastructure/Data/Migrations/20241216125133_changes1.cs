using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigurationServices.CQRS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "OrganisationHierarchies");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OrganisationTypes");

            migrationBuilder.DropTable(
                name: "LocationLevels");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "BusinessLocations");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "BusinessLocations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BusinessLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BusinessLocations");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "BusinessLocations",
                newName: "Code");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "BusinessLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocations_AddressId",
                table: "BusinessLocations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocations_CityId",
                table: "BusinessLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocations_CompanyId",
                table: "BusinessLocations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocations_CountryId",
                table: "BusinessLocations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocations_StateId",
                table: "BusinessLocations",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_Addresses_AddressId",
                table: "BusinessLocations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_Cities_CityId",
                table: "BusinessLocations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_Companies_CompanyId",
                table: "BusinessLocations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_Countries_CountryId",
                table: "BusinessLocations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_States_StateId",
                table: "BusinessLocations",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_Addresses_AddressId",
                table: "BusinessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_Cities_CityId",
                table: "BusinessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_Companies_CompanyId",
                table: "BusinessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_Countries_CountryId",
                table: "BusinessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_States_StateId",
                table: "BusinessLocations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessLocations_AddressId",
                table: "BusinessLocations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessLocations_CityId",
                table: "BusinessLocations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessLocations_CompanyId",
                table: "BusinessLocations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessLocations_CountryId",
                table: "BusinessLocations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessLocations_StateId",
                table: "BusinessLocations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "BusinessLocations");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "BusinessLocations",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "BusinessLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "BusinessLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "BusinessLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "BusinessLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LocationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationLevelId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_LocationLevels_LocationLevelId",
                        column: x => x.LocationLevelId,
                        principalTable: "LocationLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganisationHierarchies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationHierarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationHierarchies_OrganisationTypes_OrganisationTypeId",
                        column: x => x.OrganisationTypeId,
                        principalTable: "OrganisationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effective_From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Effective_To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    TypeLOVId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDetails_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_LocationId",
                table: "AddressDetails",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationLevelId",
                table: "Locations",
                column: "LocationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationHierarchies_OrganisationTypeId",
                table: "OrganisationHierarchies",
                column: "OrganisationTypeId");
        }
    }
}
