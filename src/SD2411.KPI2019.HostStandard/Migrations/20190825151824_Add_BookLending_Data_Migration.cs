using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SD2411.KPI2019.HostStandard.Migrations
{
    public partial class Add_BookLending_Data_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_book_lending",
                columns: new[] { "ID", "BookId", "BORROW_DATE", "RETURN_DATE", "UserId" },
                values: new object[] { 1, 1, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "69016cd7-609d-4539-a786-af8475f8c624" });

            migrationBuilder.InsertData(
                table: "tbl_book_lending",
                columns: new[] { "ID", "BookId", "BORROW_DATE", "RETURN_DATE", "UserId" },
                values: new object[] { 2, 2, new DateTime(2019, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "69016cd7-609d-4539-a786-af8475f8c624" });

            migrationBuilder.InsertData(
                table: "tbl_book_lending",
                columns: new[] { "ID", "BookId", "BORROW_DATE", "RETURN_DATE", "UserId" },
                values: new object[] { 3, 3, new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "69016cd7-609d-4539-a786-af8475f8c624" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_book_lending",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_book_lending",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_book_lending",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
