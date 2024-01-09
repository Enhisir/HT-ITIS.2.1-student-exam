using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    AttackNumberPerRound = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    MaxCubeDamage = table.Column<int>(type: "integer", nullable: false),
                    CubeDamageMultiplier = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackNumberPerRound", "CubeDamageMultiplier", "DamageModifier", "HitPoints", "MaxCubeDamage", "Name" },
                values: new object[,]
                {
                    { 1, 15, 1, 1, 1, -1, 7, 6, "Гоблин" },
                    { 2, 12, 3, 1, 1, 1, 32, 8, "Ледяная Жаба" },
                    { 3, 13, 5, 1, 1, 3, 15, 12, "Орк" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
