using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artbase.Migrations
{
    public partial class Commentupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileType",
                table: "Uploads",
                newName: "fileTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileTypes",
                table: "Uploads",
                newName: "fileType");
        }
    }
}
