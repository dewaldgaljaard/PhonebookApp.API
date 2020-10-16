using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonebookApp.Data.Migrations
{
    public partial class tableRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_PhoneBooks_PhoneBookId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneBookId",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_PhoneBooks_PhoneBookId",
                table: "Entries",
                column: "PhoneBookId",
                principalTable: "PhoneBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_PhoneBooks_PhoneBookId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneBookId",
                table: "Entries",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_PhoneBooks_PhoneBookId",
                table: "Entries",
                column: "PhoneBookId",
                principalTable: "PhoneBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
