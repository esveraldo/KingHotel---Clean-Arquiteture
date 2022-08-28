using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingHotel.Infraestructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Number = table.Column<string>(type: "varchar(10)", nullable: false, defaultValue: "Not informed"),
                    Address_Street = table.Column<string>(type: "varchar(100)", nullable: false, defaultValue: "Not informed"),
                    Address_City = table.Column<string>(type: "varchar(30)", nullable: false, defaultValue: "Not informed"),
                    Address_ZipCode = table.Column<string>(type: "varchar(10)", nullable: false, defaultValue: "Not informed"),
                    Document = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
