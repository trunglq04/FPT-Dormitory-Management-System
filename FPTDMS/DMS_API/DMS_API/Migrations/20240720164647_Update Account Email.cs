using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Rooms_RoomId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "FPTDMS",
                table: "Floors");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                schema: "FPTDMS",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                schema: "FPTDMS",
                table: "Services",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                schema: "FPTDMS",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "FPTDMS",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "FPTDMS",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                schema: "FPTDMS",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                schema: "FPTDMS",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "FPTDMS",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "FPTDMS",
                table: "AspNetUsers",
                type: "varchar(max)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "FPTDMS",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingServices",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsageCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingServices_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "FPTDMS",
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "FPTDMS",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "d6de14e9-01ff-4087-9e97-4464415b787b", "client@fpt.edu.vn", "CLIENT@FPT.EDU.VN", "AQAAAAIAAYagAAAAEOK9JhexpuG+UWrcmCmFPwf+lNyd+aSAnzJJOAgfrv2JfPqgfb2IAAMTbffExmxF1A==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "9bc0c872-765d-4c45-90f5-06ba1474c28d", "admin@fpt.edu.vn", "ADMIN@FPT.EDU.VN", "AQAAAAIAAYagAAAAEPDJPFNEZU2mVjJ4uxqLaMWtYBtvGJCBFMrJGg0q7tWBsVIbt1cPyuZZ1qqc+bOAIw==" });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Dorms",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Description for Dorm A", "Dorm A" },
                    { new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Description for Dorm B", "Dorm B" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Floors",
                columns: new[] { "Id", "Description", "DormId", "Name" },
                values: new object[,]
                {
                    { new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "Description for Floor 4 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 4" },
                    { new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "Description for Floor 1 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 1" },
                    { new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "Description for Floor 2 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 2" },
                    { new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "Description for Floor 3 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 3" },
                    { new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "Description for Floor 2 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 2" },
                    { new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "Description for Floor 4 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 4" },
                    { new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "Description for Floor 1 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 1" },
                    { new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "Description for Floor 5 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 5" },
                    { new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "Description for Floor 3 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 3" },
                    { new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "Description for Floor 5 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 5" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Houses",
                columns: new[] { "Id", "Capacity", "Description", "FloorId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("02a3479e-afc0-4fc7-8f9c-1099b37ea1c9"), 13, "Description for House 1 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.401", "Available" },
                    { new Guid("03b767a6-f110-437f-9111-38e95b892a1a"), 13, "Description for House 3 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.303", "Available" },
                    { new Guid("043b1f38-a9e0-4c59-b7b7-bc08868daa05"), 13, "Description for House 2 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.502", "Available" },
                    { new Guid("0e5f59d6-7772-403b-94e9-1defc3b0ee7a"), 13, "Description for House 3 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.503", "Available" },
                    { new Guid("0ed5d560-179b-4633-bcbe-0a4c21ea22f7"), 13, "Description for House 2 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.102", "Available" },
                    { new Guid("14c6dabb-b61c-4863-9a00-2666cbb72aaa"), 13, "Description for House 1 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.201", "Available" },
                    { new Guid("21b4551c-5521-4328-a037-73ec15fbe973"), 13, "Description for House 3 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.103", "Available" },
                    { new Guid("25561ae1-8d63-4e5a-8cf9-432194f8f5db"), 13, "Description for House 3 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.203", "Available" },
                    { new Guid("28af9ad5-ac6e-4807-9408-1ff9bbf789bd"), 13, "Description for House 2 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.402", "Available" },
                    { new Guid("2ba4c8a6-0b1e-4816-b2cc-1e2d7f1afc1d"), 13, "Description for House 2 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.302", "Available" },
                    { new Guid("2d021f69-4517-4a89-becd-3b3c3e7a13a9"), 13, "Description for House 1 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.501", "Available" },
                    { new Guid("339fc6e4-c007-4147-81e5-3bbe9c966e8c"), 13, "Description for House 6 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.306", "Available" },
                    { new Guid("38c3ef8e-f188-4f3f-b6e4-64ec89f48cfd"), 13, "Description for House 3 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.403", "Available" },
                    { new Guid("3c0fd929-6fa4-49e6-b7e8-6b1e6c51006c"), 13, "Description for House 6 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.306", "Available" },
                    { new Guid("4307d667-8a92-4fe7-950f-cd58a13499d8"), 13, "Description for House 3 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.503", "Available" },
                    { new Guid("463b4332-b9c8-4aed-a5a3-2a9c07df1b89"), 13, "Description for House 6 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.206", "Available" },
                    { new Guid("492f0198-f669-40b9-a58a-750cd46e78e1"), 13, "Description for House 6 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.406", "Available" },
                    { new Guid("49be72d8-b79e-4610-974a-a842bbb2a6db"), 13, "Description for House 4 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.104", "Available" },
                    { new Guid("4db8b1e1-99a4-4881-8b6b-0173506e4b30"), 13, "Description for House 4 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.304", "Available" },
                    { new Guid("5225733d-a313-4f36-8f61-f1306c0e7be7"), 13, "Description for House 2 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.502", "Available" },
                    { new Guid("5410fbea-30bb-4ab4-be65-7f83aa2d0dff"), 13, "Description for House 2 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.302", "Available" },
                    { new Guid("5a9d1616-5e25-447f-ab8e-0778794b7b97"), 13, "Description for House 2 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.202", "Available" },
                    { new Guid("60035579-3e2c-4bb1-a690-20fab977236c"), 13, "Description for House 2 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.402", "Available" },
                    { new Guid("61a015ea-77ab-451f-8c18-781017f5dccd"), 13, "Description for House 3 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.203", "Available" },
                    { new Guid("6cdeadc8-cdcf-4430-8c66-505269d29b6d"), 13, "Description for House 4 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.204", "Available" },
                    { new Guid("6dec46fc-42be-484f-b0d6-0d41ebe67597"), 13, "Description for House 5 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.305", "Available" },
                    { new Guid("73367045-61d9-4d05-8848-fb78b633d5e2"), 13, "Description for House 1 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.101", "Available" },
                    { new Guid("7480e491-3a23-4cb6-a2d4-6470340188d0"), 13, "Description for House 3 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.103", "Available" },
                    { new Guid("754031ae-d3b3-46f1-8bfe-69a8bfce9b5a"), 13, "Description for House 3 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.303", "Available" },
                    { new Guid("75b9c2c5-c117-4e87-947a-fa86ba54db21"), 13, "Description for House 5 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.405", "Available" },
                    { new Guid("76c5fbd5-0942-4c35-a00b-ff96f93f3a5a"), 13, "Description for House 1 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.501", "Available" },
                    { new Guid("795a189e-a7be-4c0b-bf80-1f5f203e1ebd"), 13, "Description for House 4 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.204", "Available" },
                    { new Guid("85b4504f-ff0a-4365-8859-75e76edbaa1e"), 13, "Description for House 5 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.305", "Available" },
                    { new Guid("8b889632-99cc-48d4-8d59-a245ee347312"), 13, "Description for House 6 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.206", "Available" },
                    { new Guid("972ccb4d-52f3-4d49-aeab-06e8442c0c19"), 13, "Description for House 5 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.205", "Available" },
                    { new Guid("9a2dd8f7-a40a-4a27-bf77-f6bce83d209a"), 13, "Description for House 6 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.506", "Available" },
                    { new Guid("9ea27d2a-446c-47ca-b7a9-66f6cd24f30d"), 13, "Description for House 4 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.404", "Available" },
                    { new Guid("9f02dc0f-3064-42e8-bea9-32fbd4b9815f"), 13, "Description for House 1 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.101", "Available" },
                    { new Guid("a67186ba-00e4-4bbf-b6b5-9db85b24baa3"), 13, "Description for House 4 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.404", "Available" },
                    { new Guid("a7905519-5d41-4019-86f3-f5000fd29757"), 13, "Description for House 5 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.105", "Available" },
                    { new Guid("afa434a2-7ca6-4b03-9a06-64b9fbc38eac"), 13, "Description for House 2 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.102", "Available" },
                    { new Guid("b1221cca-1117-46cd-8391-18681df46216"), 13, "Description for House 5 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.505", "Available" },
                    { new Guid("b41f35f1-29a1-4586-acea-a1c30865d0a7"), 13, "Description for House 4 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.504", "Available" },
                    { new Guid("b72ff572-4045-44d2-833d-615cc75bb35b"), 13, "Description for House 5 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.405", "Available" },
                    { new Guid("b783e0ae-e2ff-43a4-8885-2f927a51977a"), 13, "Description for House 6 on Floor 5", new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"), "P.506", "Available" },
                    { new Guid("c78aacc4-5d82-4166-abb4-7255defdb1d0"), 13, "Description for House 6 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.106", "Available" },
                    { new Guid("c9754dfc-d664-4a1f-adc1-05cecb14f465"), 13, "Description for House 1 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.301", "Available" },
                    { new Guid("d24e1740-c60c-4968-b7b6-90ce46f5094a"), 13, "Description for House 4 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.104", "Available" },
                    { new Guid("dd4b3693-57e0-4560-ae8d-a68fe296b0a8"), 13, "Description for House 5 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.205", "Available" },
                    { new Guid("e72e16cc-b32b-4d9c-80db-5ea81924d994"), 13, "Description for House 5 on Floor 1", new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"), "P.105", "Available" },
                    { new Guid("e7cd5e73-4556-482c-817e-90b43b0ef8b9"), 13, "Description for House 5 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.505", "Available" },
                    { new Guid("ea28cbed-5fcd-43e4-b0e8-2ab6c90d176a"), 13, "Description for House 2 on Floor 2", new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"), "P.202", "Available" },
                    { new Guid("f0b6d01b-4ad1-4cd2-adb4-9c1b4918a635"), 13, "Description for House 1 on Floor 3", new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"), "P.301", "Available" },
                    { new Guid("f5770a0f-b94e-4169-ab2f-c559a3eaafc2"), 13, "Description for House 1 on Floor 2", new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"), "P.201", "Available" },
                    { new Guid("f734bcf3-16b5-4bd9-9416-8e8469019699"), 13, "Description for House 1 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.401", "Available" },
                    { new Guid("f7907a16-b9bd-4e4f-b0f2-f25676232aca"), 13, "Description for House 4 on Floor 5", new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"), "P.504", "Available" },
                    { new Guid("f83e50cb-63be-4027-8de1-19e96a83c555"), 13, "Description for House 3 on Floor 4", new Guid("4de412be-72cd-4462-83e7-16c44094795c"), "P.403", "Available" },
                    { new Guid("fa87c9a0-ea44-44e2-b41f-44e7055279b4"), 13, "Description for House 6 on Floor 4", new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"), "P.406", "Available" },
                    { new Guid("fcdbcdf1-2715-4eb3-bb95-e29fd1de04bc"), 13, "Description for House 6 on Floor 1", new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"), "P.106", "Available" },
                    { new Guid("ff0892d0-33be-41c8-92b9-1f89aa69a954"), 13, "Description for House 4 on Floor 3", new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"), "P.304", "Available" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HouseId", "Name", "Price", "RoomType", "Status" },
                values: new object[,]
                {
                    { new Guid("00f1c180-a3f7-4e00-96d1-36de5a65858d"), 3, "Room with 3 Beds", new Guid("b783e0ae-e2ff-43a4-8885-2f927a51977a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("055bdd64-e2c8-403c-93d1-928f626f7cb3"), 4, "Room with 4 Beds", new Guid("492f0198-f669-40b9-a58a-750cd46e78e1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("06a6f145-de2a-4868-8b3b-0f5e399ccf4e"), 4, "Room with 4 Beds", new Guid("76c5fbd5-0942-4c35-a00b-ff96f93f3a5a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("06a7ed7b-4bba-41c6-bd89-23e541fa96f9"), 3, "Room with 3 Beds", new Guid("463b4332-b9c8-4aed-a5a3-2a9c07df1b89"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("0c10df2a-e3b7-42a0-8e42-35f803d58c20"), 6, "Room with 6 Beds", new Guid("75b9c2c5-c117-4e87-947a-fa86ba54db21"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0de32493-6b45-4d53-8248-e28c64d830cb"), 4, "Room with 4 Beds", new Guid("21b4551c-5521-4328-a037-73ec15fbe973"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0df5b195-50c0-433f-b1fe-ce77a1f14fa0"), 6, "Room with 6 Beds", new Guid("5225733d-a313-4f36-8f61-f1306c0e7be7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0f4ca4aa-aa1b-4f11-bd0e-51ae534f5d31"), 4, "Room with 4 Beds", new Guid("afa434a2-7ca6-4b03-9a06-64b9fbc38eac"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("1141a76d-03e4-44ef-adb0-0649335e97e1"), 3, "Room with 3 Beds", new Guid("fa87c9a0-ea44-44e2-b41f-44e7055279b4"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("1177b4fe-2129-414e-8943-49ed16929c92"), 6, "Room with 6 Beds", new Guid("b1221cca-1117-46cd-8391-18681df46216"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("11fade43-1228-4ec1-a856-44e3150e6c44"), 4, "Room with 4 Beds", new Guid("754031ae-d3b3-46f1-8bfe-69a8bfce9b5a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("13af4aed-80ac-4add-930b-c4da8e092ef3"), 6, "Room with 6 Beds", new Guid("2ba4c8a6-0b1e-4816-b2cc-1e2d7f1afc1d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("13fd3ba3-84bc-462d-85a8-8657e6e3c08d"), 3, "Room with 3 Beds", new Guid("0e5f59d6-7772-403b-94e9-1defc3b0ee7a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("146d4821-49f5-4047-82b5-424e1118d1a9"), 3, "Room with 3 Beds", new Guid("76c5fbd5-0942-4c35-a00b-ff96f93f3a5a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("15ae8f9a-8e7f-4b98-afd4-992d3894c03f"), 4, "Room with 4 Beds", new Guid("6cdeadc8-cdcf-4430-8c66-505269d29b6d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("16e42c54-4167-4880-83d4-e3d4568eb62c"), 6, "Room with 6 Beds", new Guid("03b767a6-f110-437f-9111-38e95b892a1a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("1885a41b-1577-4a92-b864-f733b9c1eb17"), 3, "Room with 3 Beds", new Guid("a67186ba-00e4-4bbf-b6b5-9db85b24baa3"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("189acb7a-4977-4b49-8f88-060d72bdea48"), 4, "Room with 4 Beds", new Guid("f7907a16-b9bd-4e4f-b0f2-f25676232aca"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("1953891a-18f7-4c84-9c17-9a8307eb6b97"), 6, "Room with 6 Beds", new Guid("4db8b1e1-99a4-4881-8b6b-0173506e4b30"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("1a556cb4-8ec8-4c80-b231-8213aa91a38b"), 6, "Room with 6 Beds", new Guid("0ed5d560-179b-4633-bcbe-0a4c21ea22f7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("1ab55aaf-a77c-4cdb-9973-eda0a251cda9"), 6, "Room with 6 Beds", new Guid("85b4504f-ff0a-4365-8859-75e76edbaa1e"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("1b3be3e4-c62a-45b9-a820-5e776525c780"), 4, "Room with 4 Beds", new Guid("fcdbcdf1-2715-4eb3-bb95-e29fd1de04bc"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("1c1cd8b8-23a4-4acc-b508-ce9fda7a3001"), 6, "Room with 6 Beds", new Guid("60035579-3e2c-4bb1-a690-20fab977236c"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("221247c5-1f2f-4513-9b6d-600f5a00c45e"), 6, "Room with 6 Beds", new Guid("21b4551c-5521-4328-a037-73ec15fbe973"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("23c0c797-8438-44ea-b944-64e31a2f2542"), 3, "Room with 3 Beds", new Guid("4307d667-8a92-4fe7-950f-cd58a13499d8"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("26a42254-5735-4923-86a5-51f6042c9070"), 3, "Room with 3 Beds", new Guid("b1221cca-1117-46cd-8391-18681df46216"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("26c8ad68-d40a-4d71-b371-1a12f53011ed"), 4, "Room with 4 Beds", new Guid("61a015ea-77ab-451f-8c18-781017f5dccd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("28390f45-f495-4770-9cb7-8fd1c010c466"), 4, "Room with 4 Beds", new Guid("2ba4c8a6-0b1e-4816-b2cc-1e2d7f1afc1d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("2913645c-8da8-4f48-88a9-2f925854ac7e"), 4, "Room with 4 Beds", new Guid("8b889632-99cc-48d4-8d59-a245ee347312"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("2d156481-1b87-45fb-ab95-96aba5c73380"), 4, "Room with 4 Beds", new Guid("a7905519-5d41-4019-86f3-f5000fd29757"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("2ece1b6e-7bf7-40ac-97dd-e1883f844d40"), 6, "Room with 6 Beds", new Guid("6cdeadc8-cdcf-4430-8c66-505269d29b6d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("30ce179c-1043-415d-a4cb-f279b8bee0af"), 6, "Room with 6 Beds", new Guid("5a9d1616-5e25-447f-ab8e-0778794b7b97"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3217ad28-7b4c-4c97-84dd-859e16d7b59e"), 3, "Room with 3 Beds", new Guid("fcdbcdf1-2715-4eb3-bb95-e29fd1de04bc"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("325900b6-6ad6-4c17-a746-d45781500bd5"), 6, "Room with 6 Beds", new Guid("f5770a0f-b94e-4169-ab2f-c559a3eaafc2"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("33468dcd-d236-4319-aa34-5ff4f1de6953"), 3, "Room with 3 Beds", new Guid("339fc6e4-c007-4147-81e5-3bbe9c966e8c"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("34e92074-db08-48c4-8f93-b5a71f6e9e9b"), 3, "Room with 3 Beds", new Guid("0ed5d560-179b-4633-bcbe-0a4c21ea22f7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("356b06c6-ff26-489f-886d-2933cd3485b7"), 4, "Room with 4 Beds", new Guid("6dec46fc-42be-484f-b0d6-0d41ebe67597"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("367c702d-4540-4881-b5ff-43ca0f6fc9b2"), 4, "Room with 4 Beds", new Guid("dd4b3693-57e0-4560-ae8d-a68fe296b0a8"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("370dc075-284c-4f32-9891-ea01954d8a74"), 6, "Room with 6 Beds", new Guid("3c0fd929-6fa4-49e6-b7e8-6b1e6c51006c"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("398cb9dd-2d5d-4c45-a56a-f2b6fcaa697a"), 3, "Room with 3 Beds", new Guid("dd4b3693-57e0-4560-ae8d-a68fe296b0a8"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("39ac23d8-c5cd-4212-9d11-dce18ef7fcdf"), 3, "Room with 3 Beds", new Guid("043b1f38-a9e0-4c59-b7b7-bc08868daa05"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("3a9d7ec2-421b-4c52-ae57-aaed876d0a45"), 6, "Room with 6 Beds", new Guid("d24e1740-c60c-4968-b7b6-90ce46f5094a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3eedce0f-0df2-4a84-8798-32994033aebf"), 3, "Room with 3 Beds", new Guid("75b9c2c5-c117-4e87-947a-fa86ba54db21"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("3f6eb971-0f3d-4b1d-9def-a28f9115e371"), 3, "Room with 3 Beds", new Guid("61a015ea-77ab-451f-8c18-781017f5dccd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("42832a0f-ecab-4bb2-a6c7-1d54ee4a9556"), 6, "Room with 6 Beds", new Guid("2d021f69-4517-4a89-becd-3b3c3e7a13a9"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("42893846-0ec3-458f-9888-c4a97c041fb2"), 3, "Room with 3 Beds", new Guid("c78aacc4-5d82-4166-abb4-7255defdb1d0"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("43128de6-2c2e-400f-ac21-682f11e13602"), 3, "Room with 3 Beds", new Guid("f5770a0f-b94e-4169-ab2f-c559a3eaafc2"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4423f5c9-371b-443c-8003-f9b314106704"), 4, "Room with 4 Beds", new Guid("972ccb4d-52f3-4d49-aeab-06e8442c0c19"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("44b150e4-980a-43ff-9fe9-a245273f7da7"), 6, "Room with 6 Beds", new Guid("ff0892d0-33be-41c8-92b9-1f89aa69a954"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("44b275c8-850d-4c18-b729-0a94144151f0"), 4, "Room with 4 Beds", new Guid("02a3479e-afc0-4fc7-8f9c-1099b37ea1c9"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("44f99835-1439-4033-8b01-b3e56ee123ad"), 4, "Room with 4 Beds", new Guid("c78aacc4-5d82-4166-abb4-7255defdb1d0"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("465209ea-0d78-4249-86ac-dd85c0533da9"), 3, "Room with 3 Beds", new Guid("7480e491-3a23-4cb6-a2d4-6470340188d0"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("48a06ec5-ea7c-4f69-a51a-6faa63b55ad1"), 3, "Room with 3 Beds", new Guid("4db8b1e1-99a4-4881-8b6b-0173506e4b30"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("48d1edb7-a937-4721-a839-dd7035ef1db6"), 3, "Room with 3 Beds", new Guid("795a189e-a7be-4c0b-bf80-1f5f203e1ebd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4a08bc80-277c-4283-b149-0e06296a79d1"), 4, "Room with 4 Beds", new Guid("b41f35f1-29a1-4586-acea-a1c30865d0a7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4ae81092-34d6-4e3f-b575-77a49270acc7"), 3, "Room with 3 Beds", new Guid("c9754dfc-d664-4a1f-adc1-05cecb14f465"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4d518a2c-1627-41d2-80d0-b82666a849f1"), 6, "Room with 6 Beds", new Guid("b783e0ae-e2ff-43a4-8885-2f927a51977a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4de9d210-ab30-4cc7-8388-5e618fb7f96c"), 6, "Room with 6 Beds", new Guid("fa87c9a0-ea44-44e2-b41f-44e7055279b4"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4f8bea3d-e1aa-48f6-9106-9342902cd4d8"), 6, "Room with 6 Beds", new Guid("25561ae1-8d63-4e5a-8cf9-432194f8f5db"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("508704a3-c29c-4ce2-b26d-36fb6e2804ac"), 6, "Room with 6 Beds", new Guid("795a189e-a7be-4c0b-bf80-1f5f203e1ebd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("51cebbfa-79fc-4029-b260-8aecab0575c3"), 3, "Room with 3 Beds", new Guid("a7905519-5d41-4019-86f3-f5000fd29757"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("52e05e1b-e2b6-4a36-bfa5-e96c17f39ae0"), 4, "Room with 4 Beds", new Guid("03b767a6-f110-437f-9111-38e95b892a1a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("54e4bc4e-24ae-4142-8cb5-756cef14d952"), 3, "Room with 3 Beds", new Guid("2d021f69-4517-4a89-becd-3b3c3e7a13a9"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("555ac114-18ff-4891-bcc1-0f726e2bb634"), 3, "Room with 3 Beds", new Guid("9ea27d2a-446c-47ca-b7a9-66f6cd24f30d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("56730923-935c-4559-a386-5509f4f7a01a"), 6, "Room with 6 Beds", new Guid("73367045-61d9-4d05-8848-fb78b633d5e2"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("5769d05b-0b38-47f5-a034-6dad477e768e"), 3, "Room with 3 Beds", new Guid("2ba4c8a6-0b1e-4816-b2cc-1e2d7f1afc1d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("58ba8e48-9bb4-4d6c-a541-de2dba5f9b2d"), 6, "Room with 6 Beds", new Guid("f7907a16-b9bd-4e4f-b0f2-f25676232aca"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("5bad2987-94d9-475b-bc9c-52c653506b13"), 6, "Room with 6 Beds", new Guid("e72e16cc-b32b-4d9c-80db-5ea81924d994"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("5c7f9a00-42da-484b-93f8-9846c7e73b75"), 6, "Room with 6 Beds", new Guid("02a3479e-afc0-4fc7-8f9c-1099b37ea1c9"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("60c6daf7-d0f7-4cfa-8b29-1fbea08d28d2"), 3, "Room with 3 Beds", new Guid("28af9ad5-ac6e-4807-9408-1ff9bbf789bd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("612c4410-dd4a-4b85-baef-2e1f1267ad7a"), 3, "Room with 3 Beds", new Guid("9f02dc0f-3064-42e8-bea9-32fbd4b9815f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("64b4c021-0673-47dc-91af-d625015a90cf"), 4, "Room with 4 Beds", new Guid("ff0892d0-33be-41c8-92b9-1f89aa69a954"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("64d28025-d5ae-40bf-bbed-9c3132908110"), 3, "Room with 3 Beds", new Guid("38c3ef8e-f188-4f3f-b6e4-64ec89f48cfd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("64e36ae8-1d33-463b-95af-363d91c83f65"), 4, "Room with 4 Beds", new Guid("4db8b1e1-99a4-4881-8b6b-0173506e4b30"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("66061763-6f14-4868-bd9a-4e6bfd18d78b"), 6, "Room with 6 Beds", new Guid("afa434a2-7ca6-4b03-9a06-64b9fbc38eac"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6a68ce4a-6d7f-4f86-8a27-2ae58036de9d"), 3, "Room with 3 Beds", new Guid("b72ff572-4045-44d2-833d-615cc75bb35b"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("6bf5d820-21b7-4c13-b4ed-3a20fa8d7728"), 6, "Room with 6 Beds", new Guid("5410fbea-30bb-4ab4-be65-7f83aa2d0dff"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6c6e31b3-a7e2-490d-8028-698ba4c11719"), 6, "Room with 6 Beds", new Guid("a67186ba-00e4-4bbf-b6b5-9db85b24baa3"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6d16418d-92ec-425f-943d-41cb3776c77e"), 3, "Room with 3 Beds", new Guid("73367045-61d9-4d05-8848-fb78b633d5e2"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("7397455c-aed7-4c33-a8f8-b333bd9b5390"), 3, "Room with 3 Beds", new Guid("85b4504f-ff0a-4365-8859-75e76edbaa1e"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("745d1e4c-654b-4ba0-9b59-57ab7ce07b5c"), 4, "Room with 4 Beds", new Guid("f83e50cb-63be-4027-8de1-19e96a83c555"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("753969a6-cfe4-4f77-ab06-ca0acb00c0d1"), 4, "Room with 4 Beds", new Guid("f0b6d01b-4ad1-4cd2-adb4-9c1b4918a635"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("77fc207c-5a4b-46a4-8d29-bc9c868adbe7"), 4, "Room with 4 Beds", new Guid("25561ae1-8d63-4e5a-8cf9-432194f8f5db"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("7837b932-043d-41c2-a7e2-49e27cd6b152"), 3, "Room with 3 Beds", new Guid("3c0fd929-6fa4-49e6-b7e8-6b1e6c51006c"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("78c14f99-48e2-485d-90bf-8550fecae18f"), 4, "Room with 4 Beds", new Guid("e72e16cc-b32b-4d9c-80db-5ea81924d994"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("7b23b3c5-481d-4486-9b84-e7f9a66ab1d1"), 6, "Room with 6 Beds", new Guid("043b1f38-a9e0-4c59-b7b7-bc08868daa05"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7d1740ea-4ce9-4829-9a08-d8327fc3a780"), 6, "Room with 6 Beds", new Guid("14c6dabb-b61c-4863-9a00-2666cbb72aaa"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7e32c1c3-9663-4011-9fe5-a013ee18197c"), 4, "Room with 4 Beds", new Guid("5225733d-a313-4f36-8f61-f1306c0e7be7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("7e5a3452-74a5-4c47-adea-3ed0de3a2999"), 3, "Room with 3 Beds", new Guid("5410fbea-30bb-4ab4-be65-7f83aa2d0dff"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("80d73217-dd4d-4f32-a3d2-ae6bd22b42e9"), 4, "Room with 4 Beds", new Guid("f734bcf3-16b5-4bd9-9416-8e8469019699"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("82a24649-4eb4-46d1-aeb3-d30327499984"), 3, "Room with 3 Beds", new Guid("03b767a6-f110-437f-9111-38e95b892a1a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("83afa58f-e3f1-47bc-b0a1-81275b32d290"), 4, "Room with 4 Beds", new Guid("9ea27d2a-446c-47ca-b7a9-66f6cd24f30d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("83ee6895-6d4c-4d85-a056-eacef6a6f717"), 6, "Room with 6 Beds", new Guid("b41f35f1-29a1-4586-acea-a1c30865d0a7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("840e41c3-e8e8-46e5-b35b-5392700666b8"), 4, "Room with 4 Beds", new Guid("795a189e-a7be-4c0b-bf80-1f5f203e1ebd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("87e25bcc-f0c3-4da1-9201-6b5c7921ebdd"), 3, "Room with 3 Beds", new Guid("492f0198-f669-40b9-a58a-750cd46e78e1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("89b35d67-0f8b-4bb7-8e9e-7fb70ab77b65"), 6, "Room with 6 Beds", new Guid("0e5f59d6-7772-403b-94e9-1defc3b0ee7a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("8a8c1953-7255-4107-b403-ca548f137d94"), 6, "Room with 6 Beds", new Guid("339fc6e4-c007-4147-81e5-3bbe9c966e8c"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("8aa5ee8b-a3d8-499f-96c6-981048b3eed0"), 4, "Room with 4 Beds", new Guid("60035579-3e2c-4bb1-a690-20fab977236c"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("8b49019d-36ad-4bd4-bec3-3e0cd558b02e"), 3, "Room with 3 Beds", new Guid("25561ae1-8d63-4e5a-8cf9-432194f8f5db"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8c22ccf5-3326-4203-8cbc-0f1e8bb39875"), 4, "Room with 4 Beds", new Guid("0ed5d560-179b-4633-bcbe-0a4c21ea22f7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("8c4fc4f1-7c13-4aae-909a-63ed59223d1a"), 6, "Room with 6 Beds", new Guid("b72ff572-4045-44d2-833d-615cc75bb35b"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("8ce3ffcc-0c1c-4c19-8971-454e02a976f6"), 3, "Room with 3 Beds", new Guid("f7907a16-b9bd-4e4f-b0f2-f25676232aca"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8d7a7d44-3ee5-4e74-9a9b-2e56d1848641"), 4, "Room with 4 Beds", new Guid("e7cd5e73-4556-482c-817e-90b43b0ef8b9"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("8de07a9d-2cee-46b3-8faa-50edb8e7b9fe"), 6, "Room with 6 Beds", new Guid("f83e50cb-63be-4027-8de1-19e96a83c555"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("90e50396-aec1-4b7a-afd7-45cd2c125e1a"), 4, "Room with 4 Beds", new Guid("0e5f59d6-7772-403b-94e9-1defc3b0ee7a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("91e78741-2636-471c-8ebf-85bde2334be7"), 6, "Room with 6 Beds", new Guid("dd4b3693-57e0-4560-ae8d-a68fe296b0a8"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("93bdb1b1-521f-408b-beac-4422b171d99b"), 6, "Room with 6 Beds", new Guid("f0b6d01b-4ad1-4cd2-adb4-9c1b4918a635"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("946e5350-c396-4055-a6cf-61efe9cfcc07"), 3, "Room with 3 Beds", new Guid("ff0892d0-33be-41c8-92b9-1f89aa69a954"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("96dd3ea2-402f-42b5-be3b-e37b3e7108f5"), 3, "Room with 3 Beds", new Guid("e72e16cc-b32b-4d9c-80db-5ea81924d994"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("97516c58-2b53-4433-9d0a-197393fba6af"), 4, "Room with 4 Beds", new Guid("9f02dc0f-3064-42e8-bea9-32fbd4b9815f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9ab1c067-bee0-4d00-bef2-dff4119041d6"), 4, "Room with 4 Beds", new Guid("b783e0ae-e2ff-43a4-8885-2f927a51977a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9b521b92-0445-4675-9e53-d7416cf02cf1"), 3, "Room with 3 Beds", new Guid("60035579-3e2c-4bb1-a690-20fab977236c"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a2e5ecd7-3c7b-4366-90de-dd13417885ae"), 6, "Room with 6 Beds", new Guid("c78aacc4-5d82-4166-abb4-7255defdb1d0"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a5b9162f-b3e0-407d-a70f-a21346fba3f3"), 3, "Room with 3 Beds", new Guid("5225733d-a313-4f36-8f61-f1306c0e7be7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a5db78b6-a89a-46dd-ac9d-9f70e9165672"), 4, "Room with 4 Beds", new Guid("b72ff572-4045-44d2-833d-615cc75bb35b"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("a802f50d-e86f-458f-aee8-669823a30e72"), 3, "Room with 3 Beds", new Guid("9a2dd8f7-a40a-4a27-bf77-f6bce83d209a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a9b795a6-35b8-42e9-9406-deb21b83ef18"), 6, "Room with 6 Beds", new Guid("463b4332-b9c8-4aed-a5a3-2a9c07df1b89"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ab16e957-d44d-4018-aeeb-bba5094a72e8"), 6, "Room with 6 Beds", new Guid("28af9ad5-ac6e-4807-9408-1ff9bbf789bd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ab8a3817-8e4c-4bae-8bba-a7a77172a680"), 4, "Room with 4 Beds", new Guid("7480e491-3a23-4cb6-a2d4-6470340188d0"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ae7c5e4f-0cd6-4337-98db-db55d97000d5"), 4, "Room with 4 Beds", new Guid("463b4332-b9c8-4aed-a5a3-2a9c07df1b89"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("aeb131eb-4c8e-4c35-bd45-b436d742dbfb"), 3, "Room with 3 Beds", new Guid("6dec46fc-42be-484f-b0d6-0d41ebe67597"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b0f23370-4fa0-4751-9f62-45992291286b"), 6, "Room with 6 Beds", new Guid("972ccb4d-52f3-4d49-aeab-06e8442c0c19"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b2e1debd-5373-4bbb-a0e3-6c66fbe2bf2c"), 3, "Room with 3 Beds", new Guid("f734bcf3-16b5-4bd9-9416-8e8469019699"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b3953c5e-d93e-4fd2-b561-85691f4f7232"), 3, "Room with 3 Beds", new Guid("21b4551c-5521-4328-a037-73ec15fbe973"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b3cad100-830a-4d5d-8be9-bed1f024dd73"), 6, "Room with 6 Beds", new Guid("ea28cbed-5fcd-43e4-b0e8-2ab6c90d176a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b62460b2-4371-4243-8419-1bc6e389a721"), 6, "Room with 6 Beds", new Guid("8b889632-99cc-48d4-8d59-a245ee347312"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b6bded2e-b658-4630-8246-acabd2f9f4d7"), 6, "Room with 6 Beds", new Guid("9ea27d2a-446c-47ca-b7a9-66f6cd24f30d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b7230202-50f0-4b19-884d-175cfa981db2"), 6, "Room with 6 Beds", new Guid("9a2dd8f7-a40a-4a27-bf77-f6bce83d209a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b73c7bca-9466-4a86-8407-8b0cdf21442d"), 4, "Room with 4 Beds", new Guid("d24e1740-c60c-4968-b7b6-90ce46f5094a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b780cc85-5887-4d14-b39a-9061643a97c3"), 4, "Room with 4 Beds", new Guid("73367045-61d9-4d05-8848-fb78b633d5e2"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b80b443b-caa6-4c0e-9d04-6019dd0e41d5"), 4, "Room with 4 Beds", new Guid("75b9c2c5-c117-4e87-947a-fa86ba54db21"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("bd4c70f7-c744-4d3b-a05c-9cb1152d6907"), 6, "Room with 6 Beds", new Guid("fcdbcdf1-2715-4eb3-bb95-e29fd1de04bc"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("bd726bb4-0090-47ea-af4c-c86b06c4e996"), 6, "Room with 6 Beds", new Guid("38c3ef8e-f188-4f3f-b6e4-64ec89f48cfd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c1be7c8d-727b-4b24-b16e-2aa7b0ffa814"), 4, "Room with 4 Beds", new Guid("28af9ad5-ac6e-4807-9408-1ff9bbf789bd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c2e26ef6-7881-4791-aae6-a1c6c214e025"), 4, "Room with 4 Beds", new Guid("ea28cbed-5fcd-43e4-b0e8-2ab6c90d176a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c3c5f169-995d-4775-9610-2a5e6d0df058"), 6, "Room with 6 Beds", new Guid("9f02dc0f-3064-42e8-bea9-32fbd4b9815f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c56e9d12-1bbd-41f5-9b9a-435d3040639d"), 6, "Room with 6 Beds", new Guid("a7905519-5d41-4019-86f3-f5000fd29757"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c5906315-613a-4fae-b570-dfc0a3e47f73"), 3, "Room with 3 Beds", new Guid("02a3479e-afc0-4fc7-8f9c-1099b37ea1c9"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c5ee9e06-62fc-4187-823f-c7eb0aed3411"), 6, "Room with 6 Beds", new Guid("4307d667-8a92-4fe7-950f-cd58a13499d8"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c7827941-0454-41b7-b80f-fca61f317e33"), 3, "Room with 3 Beds", new Guid("e7cd5e73-4556-482c-817e-90b43b0ef8b9"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c8e00d16-b3bc-48b9-a62d-86b4e2e17f84"), 4, "Room with 4 Beds", new Guid("85b4504f-ff0a-4365-8859-75e76edbaa1e"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c91ddd2e-d1d1-4483-a3a2-153855508dee"), 6, "Room with 6 Beds", new Guid("c9754dfc-d664-4a1f-adc1-05cecb14f465"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ca1701b4-483d-4b18-9c96-65f21621e314"), 3, "Room with 3 Beds", new Guid("b41f35f1-29a1-4586-acea-a1c30865d0a7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ca2e0ee6-6116-4cce-883e-c338c1d98a50"), 4, "Room with 4 Beds", new Guid("043b1f38-a9e0-4c59-b7b7-bc08868daa05"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("cb6059a2-9f2b-49de-81a9-3eec220e7322"), 3, "Room with 3 Beds", new Guid("6cdeadc8-cdcf-4430-8c66-505269d29b6d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("cdcf7375-6bef-4cfd-ad15-7824a52dd99d"), 3, "Room with 3 Beds", new Guid("ea28cbed-5fcd-43e4-b0e8-2ab6c90d176a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("cfd1a988-ee3e-47ef-9f87-4585791a9359"), 6, "Room with 6 Beds", new Guid("49be72d8-b79e-4610-974a-a842bbb2a6db"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d14f0a84-6343-44b2-bc05-cb0153af91ba"), 6, "Room with 6 Beds", new Guid("f734bcf3-16b5-4bd9-9416-8e8469019699"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d1b73685-624a-46b3-a283-b96477fbce2a"), 6, "Room with 6 Beds", new Guid("76c5fbd5-0942-4c35-a00b-ff96f93f3a5a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d33cb615-4c82-4f4b-8f93-feceba89bde5"), 4, "Room with 4 Beds", new Guid("fa87c9a0-ea44-44e2-b41f-44e7055279b4"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d36c089b-9d35-4898-ac0c-e21a9ad17d18"), 3, "Room with 3 Beds", new Guid("14c6dabb-b61c-4863-9a00-2666cbb72aaa"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d3ace8c3-5868-4466-8dff-c79140e5dab8"), 3, "Room with 3 Beds", new Guid("f83e50cb-63be-4027-8de1-19e96a83c555"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d40fd129-7f40-428e-a26c-6417972ad995"), 4, "Room with 4 Beds", new Guid("3c0fd929-6fa4-49e6-b7e8-6b1e6c51006c"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d441f904-9231-418a-801c-33b7410c3215"), 4, "Room with 4 Beds", new Guid("f5770a0f-b94e-4169-ab2f-c559a3eaafc2"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d56e453f-0e0c-4715-8b4a-67e5879fba06"), 3, "Room with 3 Beds", new Guid("49be72d8-b79e-4610-974a-a842bbb2a6db"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d7ab646c-f503-4635-9bb5-0997d3ead10e"), 3, "Room with 3 Beds", new Guid("5a9d1616-5e25-447f-ab8e-0778794b7b97"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d8042154-9d96-46a8-bea7-69121124c41d"), 3, "Room with 3 Beds", new Guid("f0b6d01b-4ad1-4cd2-adb4-9c1b4918a635"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("db15979d-fb87-4b3d-846f-bc04f2ebb3ed"), 3, "Room with 3 Beds", new Guid("8b889632-99cc-48d4-8d59-a245ee347312"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("dcc13e92-8356-41f3-8d65-a91229b18f15"), 3, "Room with 3 Beds", new Guid("754031ae-d3b3-46f1-8bfe-69a8bfce9b5a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("dce22562-ba9e-4cde-9181-c7ad771d3c3f"), 4, "Room with 4 Beds", new Guid("339fc6e4-c007-4147-81e5-3bbe9c966e8c"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e00a20d3-4d99-416a-9643-6fb875447b42"), 6, "Room with 6 Beds", new Guid("61a015ea-77ab-451f-8c18-781017f5dccd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e0a54e96-4652-4aa8-b7e0-ac4a945a7337"), 3, "Room with 3 Beds", new Guid("d24e1740-c60c-4968-b7b6-90ce46f5094a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e192fab9-6c06-400e-bea6-233993aa4d42"), 6, "Room with 6 Beds", new Guid("492f0198-f669-40b9-a58a-750cd46e78e1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e252ea48-116e-4ea4-a918-fbdc0b870762"), 6, "Room with 6 Beds", new Guid("754031ae-d3b3-46f1-8bfe-69a8bfce9b5a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e259733f-7a6c-451b-ae26-6b3792bdd906"), 3, "Room with 3 Beds", new Guid("afa434a2-7ca6-4b03-9a06-64b9fbc38eac"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e4743126-41be-4998-84c5-9c6fe6d3ed36"), 6, "Room with 6 Beds", new Guid("7480e491-3a23-4cb6-a2d4-6470340188d0"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e4e34fb4-b036-42d8-9c79-6fcca1528f79"), 4, "Room with 4 Beds", new Guid("49be72d8-b79e-4610-974a-a842bbb2a6db"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e5e9af0a-7a3a-4b89-9d51-5682dbd79c5b"), 4, "Room with 4 Beds", new Guid("38c3ef8e-f188-4f3f-b6e4-64ec89f48cfd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e8aa5bd4-f2ff-4c06-9a14-076be9313919"), 4, "Room with 4 Beds", new Guid("14c6dabb-b61c-4863-9a00-2666cbb72aaa"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e93ca40b-fb49-4d7f-ae00-eb83e3e4b047"), 4, "Room with 4 Beds", new Guid("c9754dfc-d664-4a1f-adc1-05cecb14f465"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("eb517176-2447-42f7-82f1-3f53a0625cda"), 4, "Room with 4 Beds", new Guid("a67186ba-00e4-4bbf-b6b5-9db85b24baa3"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ef688296-e550-409f-ac5a-fab94bead19b"), 4, "Room with 4 Beds", new Guid("b1221cca-1117-46cd-8391-18681df46216"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f132e191-18a1-44a0-a04f-1601f9f1cb2e"), 3, "Room with 3 Beds", new Guid("972ccb4d-52f3-4d49-aeab-06e8442c0c19"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f370105e-fb44-44e0-a8f5-366818e0e694"), 4, "Room with 4 Beds", new Guid("5410fbea-30bb-4ab4-be65-7f83aa2d0dff"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f53bd748-c2d7-45ed-90c2-376533b4643c"), 4, "Room with 4 Beds", new Guid("4307d667-8a92-4fe7-950f-cd58a13499d8"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f7432913-d962-420c-a1a9-92295f84e5d3"), 6, "Room with 6 Beds", new Guid("e7cd5e73-4556-482c-817e-90b43b0ef8b9"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("f817cc51-1798-4770-b8e1-53cfdd74320d"), 4, "Room with 4 Beds", new Guid("2d021f69-4517-4a89-becd-3b3c3e7a13a9"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fbf1b492-6779-415d-865b-fddc1dac80a4"), 6, "Room with 6 Beds", new Guid("6dec46fc-42be-484f-b0d6-0d41ebe67597"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("fd1d9ece-7b22-48b5-8d61-a34936fe0d06"), 4, "Room with 4 Beds", new Guid("5a9d1616-5e25-447f-ab8e-0778794b7b97"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fddb1340-b246-4edf-a6b5-efe6dec60b96"), 4, "Room with 4 Beds", new Guid("9a2dd8f7-a40a-4a27-bf77-f6bce83d209a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppUserId",
                schema: "FPTDMS",
                table: "Services",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                schema: "FPTDMS",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                schema: "FPTDMS",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_BookingId_ServiceId",
                schema: "FPTDMS",
                table: "BookingServices",
                columns: new[] { "BookingId", "ServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_ServiceId",
                schema: "FPTDMS",
                table: "BookingServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "FPTDMS",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_AppUserId",
                schema: "FPTDMS",
                table: "Services",
                column: "AppUserId",
                principalSchema: "FPTDMS",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Rooms_RoomId",
                schema: "FPTDMS",
                table: "Services",
                column: "RoomId",
                principalSchema: "FPTDMS",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_AppUserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Rooms_RoomId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropTable(
                name: "BookingServices",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Bookings",
                schema: "FPTDMS");

            migrationBuilder.DropIndex(
                name: "IX_Services_AppUserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("00f1c180-a3f7-4e00-96d1-36de5a65858d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("055bdd64-e2c8-403c-93d1-928f626f7cb3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("06a6f145-de2a-4868-8b3b-0f5e399ccf4e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("06a7ed7b-4bba-41c6-bd89-23e541fa96f9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0c10df2a-e3b7-42a0-8e42-35f803d58c20"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0de32493-6b45-4d53-8248-e28c64d830cb"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0df5b195-50c0-433f-b1fe-ce77a1f14fa0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0f4ca4aa-aa1b-4f11-bd0e-51ae534f5d31"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1141a76d-03e4-44ef-adb0-0649335e97e1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1177b4fe-2129-414e-8943-49ed16929c92"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("11fade43-1228-4ec1-a856-44e3150e6c44"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("13af4aed-80ac-4add-930b-c4da8e092ef3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("13fd3ba3-84bc-462d-85a8-8657e6e3c08d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("146d4821-49f5-4047-82b5-424e1118d1a9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("15ae8f9a-8e7f-4b98-afd4-992d3894c03f"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("16e42c54-4167-4880-83d4-e3d4568eb62c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1885a41b-1577-4a92-b864-f733b9c1eb17"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("189acb7a-4977-4b49-8f88-060d72bdea48"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1953891a-18f7-4c84-9c17-9a8307eb6b97"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1a556cb4-8ec8-4c80-b231-8213aa91a38b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1ab55aaf-a77c-4cdb-9973-eda0a251cda9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1b3be3e4-c62a-45b9-a820-5e776525c780"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1c1cd8b8-23a4-4acc-b508-ce9fda7a3001"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("221247c5-1f2f-4513-9b6d-600f5a00c45e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("23c0c797-8438-44ea-b944-64e31a2f2542"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("26a42254-5735-4923-86a5-51f6042c9070"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("26c8ad68-d40a-4d71-b371-1a12f53011ed"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("28390f45-f495-4770-9cb7-8fd1c010c466"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2913645c-8da8-4f48-88a9-2f925854ac7e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2d156481-1b87-45fb-ab95-96aba5c73380"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("2ece1b6e-7bf7-40ac-97dd-e1883f844d40"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("30ce179c-1043-415d-a4cb-f279b8bee0af"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3217ad28-7b4c-4c97-84dd-859e16d7b59e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("325900b6-6ad6-4c17-a746-d45781500bd5"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("33468dcd-d236-4319-aa34-5ff4f1de6953"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("34e92074-db08-48c4-8f93-b5a71f6e9e9b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("356b06c6-ff26-489f-886d-2933cd3485b7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("367c702d-4540-4881-b5ff-43ca0f6fc9b2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("370dc075-284c-4f32-9891-ea01954d8a74"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("398cb9dd-2d5d-4c45-a56a-f2b6fcaa697a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("39ac23d8-c5cd-4212-9d11-dce18ef7fcdf"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3a9d7ec2-421b-4c52-ae57-aaed876d0a45"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3eedce0f-0df2-4a84-8798-32994033aebf"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3f6eb971-0f3d-4b1d-9def-a28f9115e371"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("42832a0f-ecab-4bb2-a6c7-1d54ee4a9556"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("42893846-0ec3-458f-9888-c4a97c041fb2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("43128de6-2c2e-400f-ac21-682f11e13602"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4423f5c9-371b-443c-8003-f9b314106704"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("44b150e4-980a-43ff-9fe9-a245273f7da7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("44b275c8-850d-4c18-b729-0a94144151f0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("44f99835-1439-4033-8b01-b3e56ee123ad"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("465209ea-0d78-4249-86ac-dd85c0533da9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("48a06ec5-ea7c-4f69-a51a-6faa63b55ad1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("48d1edb7-a937-4721-a839-dd7035ef1db6"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4a08bc80-277c-4283-b149-0e06296a79d1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4ae81092-34d6-4e3f-b575-77a49270acc7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4d518a2c-1627-41d2-80d0-b82666a849f1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4de9d210-ab30-4cc7-8388-5e618fb7f96c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4f8bea3d-e1aa-48f6-9106-9342902cd4d8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("508704a3-c29c-4ce2-b26d-36fb6e2804ac"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("51cebbfa-79fc-4029-b260-8aecab0575c3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("52e05e1b-e2b6-4a36-bfa5-e96c17f39ae0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("54e4bc4e-24ae-4142-8cb5-756cef14d952"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("555ac114-18ff-4891-bcc1-0f726e2bb634"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("56730923-935c-4559-a386-5509f4f7a01a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5769d05b-0b38-47f5-a034-6dad477e768e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("58ba8e48-9bb4-4d6c-a541-de2dba5f9b2d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5bad2987-94d9-475b-bc9c-52c653506b13"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5c7f9a00-42da-484b-93f8-9846c7e73b75"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("60c6daf7-d0f7-4cfa-8b29-1fbea08d28d2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("612c4410-dd4a-4b85-baef-2e1f1267ad7a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("64b4c021-0673-47dc-91af-d625015a90cf"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("64d28025-d5ae-40bf-bbed-9c3132908110"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("64e36ae8-1d33-463b-95af-363d91c83f65"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("66061763-6f14-4868-bd9a-4e6bfd18d78b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6a68ce4a-6d7f-4f86-8a27-2ae58036de9d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6bf5d820-21b7-4c13-b4ed-3a20fa8d7728"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6c6e31b3-a7e2-490d-8028-698ba4c11719"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6d16418d-92ec-425f-943d-41cb3776c77e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7397455c-aed7-4c33-a8f8-b333bd9b5390"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("745d1e4c-654b-4ba0-9b59-57ab7ce07b5c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("753969a6-cfe4-4f77-ab06-ca0acb00c0d1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77fc207c-5a4b-46a4-8d29-bc9c868adbe7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7837b932-043d-41c2-a7e2-49e27cd6b152"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("78c14f99-48e2-485d-90bf-8550fecae18f"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7b23b3c5-481d-4486-9b84-e7f9a66ab1d1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7d1740ea-4ce9-4829-9a08-d8327fc3a780"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7e32c1c3-9663-4011-9fe5-a013ee18197c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7e5a3452-74a5-4c47-adea-3ed0de3a2999"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("80d73217-dd4d-4f32-a3d2-ae6bd22b42e9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("82a24649-4eb4-46d1-aeb3-d30327499984"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("83afa58f-e3f1-47bc-b0a1-81275b32d290"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("83ee6895-6d4c-4d85-a056-eacef6a6f717"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("840e41c3-e8e8-46e5-b35b-5392700666b8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("87e25bcc-f0c3-4da1-9201-6b5c7921ebdd"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("89b35d67-0f8b-4bb7-8e9e-7fb70ab77b65"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8a8c1953-7255-4107-b403-ca548f137d94"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8aa5ee8b-a3d8-499f-96c6-981048b3eed0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8b49019d-36ad-4bd4-bec3-3e0cd558b02e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8c22ccf5-3326-4203-8cbc-0f1e8bb39875"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8c4fc4f1-7c13-4aae-909a-63ed59223d1a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8ce3ffcc-0c1c-4c19-8971-454e02a976f6"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8d7a7d44-3ee5-4e74-9a9b-2e56d1848641"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8de07a9d-2cee-46b3-8faa-50edb8e7b9fe"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("90e50396-aec1-4b7a-afd7-45cd2c125e1a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("91e78741-2636-471c-8ebf-85bde2334be7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("93bdb1b1-521f-408b-beac-4422b171d99b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("946e5350-c396-4055-a6cf-61efe9cfcc07"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("96dd3ea2-402f-42b5-be3b-e37b3e7108f5"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("97516c58-2b53-4433-9d0a-197393fba6af"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9ab1c067-bee0-4d00-bef2-dff4119041d6"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9b521b92-0445-4675-9e53-d7416cf02cf1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a2e5ecd7-3c7b-4366-90de-dd13417885ae"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a5b9162f-b3e0-407d-a70f-a21346fba3f3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a5db78b6-a89a-46dd-ac9d-9f70e9165672"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a802f50d-e86f-458f-aee8-669823a30e72"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a9b795a6-35b8-42e9-9406-deb21b83ef18"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ab16e957-d44d-4018-aeeb-bba5094a72e8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ab8a3817-8e4c-4bae-8bba-a7a77172a680"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ae7c5e4f-0cd6-4337-98db-db55d97000d5"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("aeb131eb-4c8e-4c35-bd45-b436d742dbfb"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b0f23370-4fa0-4751-9f62-45992291286b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b2e1debd-5373-4bbb-a0e3-6c66fbe2bf2c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b3953c5e-d93e-4fd2-b561-85691f4f7232"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b3cad100-830a-4d5d-8be9-bed1f024dd73"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b62460b2-4371-4243-8419-1bc6e389a721"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b6bded2e-b658-4630-8246-acabd2f9f4d7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b7230202-50f0-4b19-884d-175cfa981db2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b73c7bca-9466-4a86-8407-8b0cdf21442d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b780cc85-5887-4d14-b39a-9061643a97c3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b80b443b-caa6-4c0e-9d04-6019dd0e41d5"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bd4c70f7-c744-4d3b-a05c-9cb1152d6907"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bd726bb4-0090-47ea-af4c-c86b06c4e996"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c1be7c8d-727b-4b24-b16e-2aa7b0ffa814"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c2e26ef6-7881-4791-aae6-a1c6c214e025"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c3c5f169-995d-4775-9610-2a5e6d0df058"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c56e9d12-1bbd-41f5-9b9a-435d3040639d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c5906315-613a-4fae-b570-dfc0a3e47f73"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c5ee9e06-62fc-4187-823f-c7eb0aed3411"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c7827941-0454-41b7-b80f-fca61f317e33"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c8e00d16-b3bc-48b9-a62d-86b4e2e17f84"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c91ddd2e-d1d1-4483-a3a2-153855508dee"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ca1701b4-483d-4b18-9c96-65f21621e314"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ca2e0ee6-6116-4cce-883e-c338c1d98a50"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cb6059a2-9f2b-49de-81a9-3eec220e7322"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cdcf7375-6bef-4cfd-ad15-7824a52dd99d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cfd1a988-ee3e-47ef-9f87-4585791a9359"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d14f0a84-6343-44b2-bc05-cb0153af91ba"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d1b73685-624a-46b3-a283-b96477fbce2a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d33cb615-4c82-4f4b-8f93-feceba89bde5"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d36c089b-9d35-4898-ac0c-e21a9ad17d18"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d3ace8c3-5868-4466-8dff-c79140e5dab8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d40fd129-7f40-428e-a26c-6417972ad995"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d441f904-9231-418a-801c-33b7410c3215"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d56e453f-0e0c-4715-8b4a-67e5879fba06"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d7ab646c-f503-4635-9bb5-0997d3ead10e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d8042154-9d96-46a8-bea7-69121124c41d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("db15979d-fb87-4b3d-846f-bc04f2ebb3ed"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dcc13e92-8356-41f3-8d65-a91229b18f15"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dce22562-ba9e-4cde-9181-c7ad771d3c3f"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e00a20d3-4d99-416a-9643-6fb875447b42"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e0a54e96-4652-4aa8-b7e0-ac4a945a7337"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e192fab9-6c06-400e-bea6-233993aa4d42"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e252ea48-116e-4ea4-a918-fbdc0b870762"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e259733f-7a6c-451b-ae26-6b3792bdd906"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e4743126-41be-4998-84c5-9c6fe6d3ed36"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e4e34fb4-b036-42d8-9c79-6fcca1528f79"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e5e9af0a-7a3a-4b89-9d51-5682dbd79c5b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e8aa5bd4-f2ff-4c06-9a14-076be9313919"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e93ca40b-fb49-4d7f-ae00-eb83e3e4b047"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("eb517176-2447-42f7-82f1-3f53a0625cda"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ef688296-e550-409f-ac5a-fab94bead19b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f132e191-18a1-44a0-a04f-1601f9f1cb2e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f370105e-fb44-44e0-a8f5-366818e0e694"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f53bd748-c2d7-45ed-90c2-376533b4643c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f7432913-d962-420c-a1a9-92295f84e5d3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f817cc51-1798-4770-b8e1-53cfdd74320d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fbf1b492-6779-415d-865b-fddc1dac80a4"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fd1d9ece-7b22-48b5-8d61-a34936fe0d06"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fddb1340-b246-4edf-a6b5-efe6dec60b96"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("02a3479e-afc0-4fc7-8f9c-1099b37ea1c9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("03b767a6-f110-437f-9111-38e95b892a1a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("043b1f38-a9e0-4c59-b7b7-bc08868daa05"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("0e5f59d6-7772-403b-94e9-1defc3b0ee7a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("0ed5d560-179b-4633-bcbe-0a4c21ea22f7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("14c6dabb-b61c-4863-9a00-2666cbb72aaa"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("21b4551c-5521-4328-a037-73ec15fbe973"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("25561ae1-8d63-4e5a-8cf9-432194f8f5db"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("28af9ad5-ac6e-4807-9408-1ff9bbf789bd"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("2ba4c8a6-0b1e-4816-b2cc-1e2d7f1afc1d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("2d021f69-4517-4a89-becd-3b3c3e7a13a9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("339fc6e4-c007-4147-81e5-3bbe9c966e8c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("38c3ef8e-f188-4f3f-b6e4-64ec89f48cfd"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("3c0fd929-6fa4-49e6-b7e8-6b1e6c51006c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4307d667-8a92-4fe7-950f-cd58a13499d8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("463b4332-b9c8-4aed-a5a3-2a9c07df1b89"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("492f0198-f669-40b9-a58a-750cd46e78e1"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("49be72d8-b79e-4610-974a-a842bbb2a6db"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4db8b1e1-99a4-4881-8b6b-0173506e4b30"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("5225733d-a313-4f36-8f61-f1306c0e7be7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("5410fbea-30bb-4ab4-be65-7f83aa2d0dff"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("5a9d1616-5e25-447f-ab8e-0778794b7b97"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("60035579-3e2c-4bb1-a690-20fab977236c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("61a015ea-77ab-451f-8c18-781017f5dccd"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6cdeadc8-cdcf-4430-8c66-505269d29b6d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6dec46fc-42be-484f-b0d6-0d41ebe67597"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("73367045-61d9-4d05-8848-fb78b633d5e2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("7480e491-3a23-4cb6-a2d4-6470340188d0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("754031ae-d3b3-46f1-8bfe-69a8bfce9b5a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("75b9c2c5-c117-4e87-947a-fa86ba54db21"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("76c5fbd5-0942-4c35-a00b-ff96f93f3a5a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("795a189e-a7be-4c0b-bf80-1f5f203e1ebd"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("85b4504f-ff0a-4365-8859-75e76edbaa1e"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("8b889632-99cc-48d4-8d59-a245ee347312"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("972ccb4d-52f3-4d49-aeab-06e8442c0c19"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("9a2dd8f7-a40a-4a27-bf77-f6bce83d209a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("9ea27d2a-446c-47ca-b7a9-66f6cd24f30d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("9f02dc0f-3064-42e8-bea9-32fbd4b9815f"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("a67186ba-00e4-4bbf-b6b5-9db85b24baa3"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("a7905519-5d41-4019-86f3-f5000fd29757"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("afa434a2-7ca6-4b03-9a06-64b9fbc38eac"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b1221cca-1117-46cd-8391-18681df46216"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b41f35f1-29a1-4586-acea-a1c30865d0a7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b72ff572-4045-44d2-833d-615cc75bb35b"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b783e0ae-e2ff-43a4-8885-2f927a51977a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("c78aacc4-5d82-4166-abb4-7255defdb1d0"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("c9754dfc-d664-4a1f-adc1-05cecb14f465"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("d24e1740-c60c-4968-b7b6-90ce46f5094a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("dd4b3693-57e0-4560-ae8d-a68fe296b0a8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("e72e16cc-b32b-4d9c-80db-5ea81924d994"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("e7cd5e73-4556-482c-817e-90b43b0ef8b9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("ea28cbed-5fcd-43e4-b0e8-2ab6c90d176a"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f0b6d01b-4ad1-4cd2-adb4-9c1b4918a635"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f5770a0f-b94e-4169-ab2f-c559a3eaafc2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f734bcf3-16b5-4bd9-9416-8e8469019699"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f7907a16-b9bd-4e4f-b0f2-f25676232aca"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f83e50cb-63be-4027-8de1-19e96a83c555"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("fa87c9a0-ea44-44e2-b41f-44e7055279b4"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("fcdbcdf1-2715-4eb3-bb95-e29fd1de04bc"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("ff0892d0-33be-41c8-92b9-1f89aa69a954"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("4de412be-72cd-4462-83e7-16c44094795c"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("5deb5efc-5a54-4000-b576-b084b75911d2"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("6c81875f-3a4b-4c94-b0cc-fd4338dbc537"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("718b2e03-9ae8-48d6-815f-94fa11699ee6"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("850368e2-3fc8-40f5-b520-4747e737d78d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("990cd5aa-9722-4e31-85a1-5ab6032933e8"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("b6dfd8e7-7f2e-43c0-9437-91a4cb29efe7"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("c6702663-bc23-440b-826d-e55083fe7d2d"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("ddf0a6c8-2139-49c1-8c34-d0960b34f369"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Floors",
                keyColumn: "Id",
                keyValue: new Guid("fc0725b0-141c-4192-8dde-2baa64564baf"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Dorms",
                keyColumn: "Id",
                keyValue: new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"));

            migrationBuilder.DeleteData(
                schema: "FPTDMS",
                table: "Dorms",
                keyColumn: "Id",
                keyValue: new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"));

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "FPTDMS",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "FPTDMS",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "FPTDMS",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomType",
                schema: "FPTDMS",
                table: "Rooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                schema: "FPTDMS",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "FPTDMS",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                schema: "FPTDMS",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "FPTDMS",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "FPTDMS",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "FPTDMS",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "FPTDMS",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "FPTDMS",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "c1f13ae2-63d3-42ef-a1e4-d9711d03e775", "client@fpt.vn", "CLIENT@FPT.VN", "AQAAAAIAAYagAAAAELka5jWrmPxTxOd4Jd4sRbtvyjc2xdJm6OveAT9rmDJaLEjc4vj6YERS8hkFTscg9w==" });

            migrationBuilder.UpdateData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "f5d185f4-35cc-48f8-8425-19e101dff714", "admin@fpt.vn", "ADMIN@FPT.VN", "AQAAAAIAAYagAAAAENol6H1fPkzJfXBH2RS+7xWQgFDNlM4vfYioayKQ6eBIeGYi5FToPgjzISytQSukmw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                schema: "FPTDMS",
                table: "Services",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                schema: "FPTDMS",
                table: "Services",
                column: "UserId",
                principalSchema: "FPTDMS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Rooms_RoomId",
                schema: "FPTDMS",
                table: "Services",
                column: "RoomId",
                principalSchema: "FPTDMS",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
