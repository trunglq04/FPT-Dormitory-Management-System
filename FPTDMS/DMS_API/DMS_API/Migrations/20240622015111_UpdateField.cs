using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "FPTDMS",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2230a585-7a0f-4ead-8eea-57e2d2340597", "AQAAAAIAAYagAAAAEPEmxWira4ei1mnCW6ehj9u9EbNgEjq/lR8PcJcm6TSbecDrgNyDxgbrTnvEJ7RY3A==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39940b55-5688-4f12-bedf-9aecb260ece7", "AQAAAAIAAYagAAAAEA0kzkQQI5v9lrA3wfoBxae1LKt8//cZk5t8OoO9sss8ysBob5o7EWdqmVYHTkhz/Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "FPTDMS",
                table: "Rooms");

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
        }
    }
}
