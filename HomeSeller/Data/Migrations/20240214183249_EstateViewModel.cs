using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeSeller.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstateViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Estate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Estate");
        }
    }
}
