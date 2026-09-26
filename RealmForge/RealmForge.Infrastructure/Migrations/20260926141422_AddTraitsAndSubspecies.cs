using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTraitsAndSubspecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subspecies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseSpeedOverrideInFeet = table.Column<int>(type: "integer", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subspecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subspecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubspeciesTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubspeciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubspeciesTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubspeciesTranslations_Subspecies_SubspeciesId",
                        column: x => x.SubspeciesId,
                        principalTable: "Subspecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredLevel = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubspeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traits_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traits_Subspecies_SubspeciesId",
                        column: x => x.SubspeciesId,
                        principalTable: "Subspecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraitTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TraitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraitTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraitTranslations_Traits_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subspecies_SpeciesId",
                table: "Subspecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SubspeciesTranslations_SubspeciesId_Language",
                table: "SubspeciesTranslations",
                columns: new[] { "SubspeciesId", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traits_SpeciesId",
                table: "Traits",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Traits_SubspeciesId",
                table: "Traits",
                column: "SubspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_TraitTranslations_TraitId_Language",
                table: "TraitTranslations",
                columns: new[] { "TraitId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubspeciesTranslations");

            migrationBuilder.DropTable(
                name: "TraitTranslations");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "Subspecies");
        }
    }
}
