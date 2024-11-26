using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuPrev.Migrations
{
    public partial class migration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Funcionario");
        }
    }
}
