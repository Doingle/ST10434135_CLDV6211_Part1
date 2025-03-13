using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10434135_CLDV6211_Part1.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingSpecialists",
                columns: table => new
                {
                    SpecialistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialistEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialistPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSpecialists", x => x.SpecialistID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSpecialists");
        }
    }
}
