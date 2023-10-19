using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Norda.DAL.Migrations
{
    /// <inheritdoc />
    public partial class countryStreetCityDistrictEntitiy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "District",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneCode",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlateNo",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinaryCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    TripleCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PhoneCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    StreetName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DistrictID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Street_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Street_DistrictID",
                table: "Street",
                column: "DistrictID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "District");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "City");

            migrationBuilder.DropColumn(
                name: "PlateNo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "City");
        }
    }
}
