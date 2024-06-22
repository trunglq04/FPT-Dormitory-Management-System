using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                values: new object[] { "c0db2f4a-be5e-4969-bb83-e93428bdab90", "AQAAAAIAAYagAAAAEJ8+qkpCubhrnLrzr23qGVs8TnxG5NG52mCZu0DHKoRAUC+HTKtiKVbt3qfCcR1NLA==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80da09fa-1484-4da3-8383-b7dadd3f286e", "AQAAAAIAAYagAAAAEDXeTCw15K2op+sMBizfJTtoV2DWTXHKZeXQwSgwGansU//jAJiQ8AxYJlT2nsCDrg==" });
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
                values: new object[] { "7daac841-4e1d-48c9-9d98-24d9bbc1f198", "AQAAAAIAAYagAAAAEP6kYbwgXLPQhJPrn9Hx4bu6bNURtA4oagcZjS721lh+FZLIY+ohE/DyMha2j54aAA==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5bd1560-0b6f-4642-8be1-2917d32f6532", "AQAAAAIAAYagAAAAEG+jLPiZf0JLn6na+2KNM5QZPJFFydzbEkBI/dXzYTtWtzIccH1z3FuBGjNJHSfPaA==" });
        }
    }
}
