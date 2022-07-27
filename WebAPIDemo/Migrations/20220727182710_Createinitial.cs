using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIDemo.Migrations
{
    public partial class Createinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harddisk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "laptops");
        }
    }
}
