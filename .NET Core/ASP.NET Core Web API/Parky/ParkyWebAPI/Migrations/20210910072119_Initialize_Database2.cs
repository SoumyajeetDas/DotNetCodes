using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkyWebAPI.Migrations
{
    public partial class Initialize_Database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "nationalparks",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "nationalparks");
        }
    }
}
