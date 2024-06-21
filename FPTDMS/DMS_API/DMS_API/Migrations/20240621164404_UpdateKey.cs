using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7daac841-4e1d-48c9-9d98-24d9bbc1f198", "AQAAAAIAAYagAAAAEP6kYbwgXLPQhJPrn9Hx4bu6bNURtA4oagcZjS721lh+FZLIY+ohE/DyMha2j54aAA==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5bd1560-0b6f-4642-8be1-2917d32f6532", "AQAAAAIAAYagAAAAEG+jLPiZf0JLn6na+2KNM5QZPJFFydzbEkBI/dXzYTtWtzIccH1z3FuBGjNJHSfPaA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1438be39-17b2-4a7e-837d-91711d6a0c83", "AQAAAAIAAYagAAAAEO4L0e+o0VhyrOOfWHsONQsqfnb92g1ODZRnS76g2N4ow8zbeSuBuPSt49jjLY2YDw==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "765e3db1-94d5-460c-99b7-456db1b52437", "AQAAAAIAAYagAAAAEG8qbgs1B/kbXO4AgMh1Smg6NtvwEuKOaDpp0CRYma6EwOxfYrvRqmG7TfQt3Y8aLg==" });
        }
    }
}
