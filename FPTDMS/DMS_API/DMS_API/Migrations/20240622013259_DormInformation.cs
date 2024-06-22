using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class DormInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dorms",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Dorms_DormId",
                        column: x => x.DormId,
                        principalSchema: "FPTDMS",
                        principalTable: "Dorms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Floors_FloorId",
                        column: x => x.FloorId,
                        principalSchema: "FPTDMS",
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "FPTDMS",
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8d17e23-8c99-4234-b833-00ca68335257", "AQAAAAIAAYagAAAAEIOalbo5PEbvIz/wToaynLKl+NV/I3l3YhfElbkalYFp3BtHhyO4GOSXWsXGwILhzQ==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27c3c429-4dcc-474b-8a56-581ccbc202ca", "AQAAAAIAAYagAAAAENNdlw/MDUEJMoXsDyRxqJXBsQbPJkMqwtEl+YHdcqHtAel1BGUnzYUK0HpW54pr5A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Floors_DormId",
                schema: "FPTDMS",
                table: "Floors",
                column: "DormId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_FloorId",
                schema: "FPTDMS",
                table: "Houses",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HouseId",
                schema: "FPTDMS",
                table: "Rooms",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Houses",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Floors",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Dorms",
                schema: "FPTDMS");

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0db2f4a-be5e-4969-bb83-e93428bdab90", "AQAAAAIAAYagAAAAEJ8+qkpCubhrnLrzr23qGVs8TnxG5NG52mCZu0DHKoRAUC+HTKtiKVbt3qfCcR1NLA==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80da09fa-1484-4da3-8383-b7dadd3f286e", "AQAAAAIAAYagAAAAEDXeTCw15K2op+sMBizfJTtoV2DWTXHKZeXQwSgwGansU//jAJiQ8AxYJlT2nsCDrg==" });
        }
    }
}
