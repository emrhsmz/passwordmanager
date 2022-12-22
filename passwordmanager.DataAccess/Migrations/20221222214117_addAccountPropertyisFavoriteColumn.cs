using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace passwordmanager.DataAccess.Migrations
{
    public partial class addAccountPropertyisFavoriteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavorite",
                table: "AccountProperties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavorite",
                table: "AccountProperties");
        }
    }
}
