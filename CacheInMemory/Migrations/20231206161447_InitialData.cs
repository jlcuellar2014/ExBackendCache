using CacheInMemory.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacheInMemory.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var countries = CountriesHelper.GetCountiesFromStaticCsv("Resources\\countries_es.csv");

            foreach (var country in countries)
            {
                migrationBuilder.InsertData(
                   table: "Countries",
                   columns: new[] { "CountryCode", "CountryName" },
                    values: new object[,] {
                        { country.CountryCode, country.CountryName }
                    }
               );
            }

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "CountryCode", "Name", "Description" },
                values: new object[,] {
                    { 1, "DE", "Mercedez Benz", "Autos de alta Gama"}
                }
            );

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BranchId", "CountryCode", "Name", "Description" },
                values: new object[,] {
                    { 1, 1, "DE", "EQS Berlina", "La elegancia de un coupé unida a la espaciosidad de una berlina."}
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
