using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AddingRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompletedInfo",
                schema: "FPTDMS",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1f13ae2-63d3-42ef-a1e4-d9711d03e775", "AQAAAAIAAYagAAAAELka5jWrmPxTxOd4Jd4sRbtvyjc2xdJm6OveAT9rmDJaLEjc4vj6YERS8hkFTscg9w==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5d185f4-35cc-48f8-8425-19e101dff714", "AQAAAAIAAYagAAAAENol6H1fPkzJfXBH2RS+7xWQgFDNlM4vfYioayKQ6eBIeGYi5FToPgjzISytQSukmw==" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "FPTDMS",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "FPTDMS");

            migrationBuilder.AddColumn<int>(
                name: "isCompletedInfo",
                schema: "FPTDMS",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "isCompletedInfo" },
                values: new object[] { "5c6ebadc-68c1-4025-987b-fba8ee3a42d3", "AQAAAAIAAYagAAAAEFFGDqYtExnyUsOXWGSmz1NA0zKtrrlrsrknfAfOzT9evTwMdXN7giR4ROe5EF1JWQ==", 1 });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "isCompletedInfo" },
                values: new object[] { "516ed81a-556a-4c0c-87b3-5fea2c12a041", "AQAAAAIAAYagAAAAEJfkbyC9DlZqFMXEqiA59zin7f5Xari9DHig4A5lXs6CEGHgZCbMje1a0tez8opoRw==", 1 });
        }
    }
}
