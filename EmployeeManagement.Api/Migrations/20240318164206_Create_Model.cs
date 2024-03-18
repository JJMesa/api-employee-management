using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Api.Migrations
{
    public partial class Create_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    LAST_NAME = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    IDENTIFICATION = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    DATE_ENTRY = table.Column<DateTime>(type: "date", nullable: false),
                    PATH_PHOTO = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EMPLOYEE_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEE");
        }
    }
}