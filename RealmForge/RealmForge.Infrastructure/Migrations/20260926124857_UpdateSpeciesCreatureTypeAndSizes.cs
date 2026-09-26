using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpeciesCreatureTypeAndSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Species");

            migrationBuilder.AddColumn<int[]>(
                name: "AllowedSizes",
                table: "Species",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<int>(
                name: "CreatureType",
                table: "Species",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedSizes",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatureType",
                table: "Species");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Species",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
