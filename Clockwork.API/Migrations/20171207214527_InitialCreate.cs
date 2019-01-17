using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Clockwork.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentTimeQueries",
                columns: table => new
                {
                    CurrentTimeQueryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientIp = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UTCTime = table.Column<DateTime>(nullable: false),
                    Timezone = table.Column<string>(nullable: true),
                    TimezoneTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTimeQueries", x => x.CurrentTimeQueryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTimeQueries");
        }
    }
}
