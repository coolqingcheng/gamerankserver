using Microsoft.EntityFrameworkCore.Migrations;

namespace GameRankServer.Storage.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RegisterGameId",
                table: "users",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "GameId",
                table: "games",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterGameId",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "games",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
