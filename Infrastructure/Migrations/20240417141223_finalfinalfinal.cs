using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finalfinalfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesInProcent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesInNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

        }
    }
}
