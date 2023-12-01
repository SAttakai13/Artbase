using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artbase.Migrations
{
    public partial class FixedSaveUploadUserModefixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SavdId",
                table: "UserSaves",
                newName: "SavedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SavedId",
                table: "UserSaves",
                newName: "SavdId");
        }
    }
}
