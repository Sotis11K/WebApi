using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertisingUpdates",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DailyNewsletter",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventUpdates",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Podcasts",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartupsWeekly",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeekinReview",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertisingUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DailyNewsletter",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "EventUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Podcasts",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "StartupsWeekly",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "WeekinReview",
                table: "Subscribers");
        }
    }
}
