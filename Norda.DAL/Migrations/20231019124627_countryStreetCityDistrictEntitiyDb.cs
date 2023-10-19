using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Norda.DAL.Migrations
{
    /// <inheritdoc />
    public partial class countryStreetCityDistrictEntitiyDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Street_District_DistrictID",
                table: "Street");

            migrationBuilder.AddForeignKey(
                name: "FK_Street_District_DistrictID",
                table: "Street",
                column: "DistrictID",
                principalTable: "District",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Street_District_DistrictID",
                table: "Street");

            migrationBuilder.AddForeignKey(
                name: "FK_Street_District_DistrictID",
                table: "Street",
                column: "DistrictID",
                principalTable: "District",
                principalColumn: "ID");
        }
    }
}
