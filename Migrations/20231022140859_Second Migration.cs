using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject_IT_DIV.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Persons_User_Id",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_User_Id",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "PersonCategories",
                columns: table => new
                {
                    PersonCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCategories", x => x.PersonCategory_Id);
                    table.ForeignKey(
                        name: "FK_PersonCategories_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCategories_Persons_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Persons",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonCategories_Category_Id",
                table: "PersonCategories",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCategories_User_Id",
                table: "PersonCategories",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonCategories");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_User_Id",
                table: "Categories",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Persons_User_Id",
                table: "Categories",
                column: "User_Id",
                principalTable: "Persons",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
