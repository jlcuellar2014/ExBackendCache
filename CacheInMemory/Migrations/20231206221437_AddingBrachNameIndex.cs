using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacheInMemory.Migrations
{
    /// <inheritdoc />
    public partial class AddingBrachNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branches_Name",
                table: "Branches");
        }
    }
}
