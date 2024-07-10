using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_project_coulumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images1",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images2",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images3",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images4",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Porfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Porfolios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Porfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images1",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Images2",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Images3",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Images4",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Porfolios");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Porfolios");
        }
    }
}
