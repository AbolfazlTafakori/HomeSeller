using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeSeller.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryModelAndItsRelationWithEstateModelEstablished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Estate",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "EstateModelId",
                table: "Estate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estate_EstateModelId",
                table: "Estate",
                column: "EstateModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estate_Estate_EstateModelId",
                table: "Estate",
                column: "EstateModelId",
                principalTable: "Estate",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estate_Estate_EstateModelId",
                table: "Estate");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Estate_EstateModelId",
                table: "Estate");

            migrationBuilder.DropColumn(
                name: "EstateModelId",
                table: "Estate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Estate",
                newName: "id");
        }
    }
}
