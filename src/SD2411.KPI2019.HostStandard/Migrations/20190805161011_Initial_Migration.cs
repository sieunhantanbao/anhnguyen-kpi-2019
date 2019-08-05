using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SD2411.KPI2019.HostStandard.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_book_category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_book_lending",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_ID = table.Column<int>(nullable: false),
                    BOOK_ID = table.Column<int>(nullable: false),
                    BORROW_DATE = table.Column<DateTime>(nullable: false),
                    RETURN_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book_lending", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tlb_user",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_NAME = table.Column<string>(nullable: true),
                    FULL_NAME = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tlb_user", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_book",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    PUBLISHED_DATE = table.Column<DateTime>(nullable: false),
                    AUTHOR = table.Column<string>(nullable: true),
                    IS_AVAILABLE_TO_LEND = table.Column<bool>(nullable: false),
                    BookCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_CATEGORY",
                        column: x => x.BookCategoryId,
                        principalTable: "tbl_book_category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_BookCategoryId",
                table: "tbl_book",
                column: "BookCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_book");

            migrationBuilder.DropTable(
                name: "tbl_book_lending");

            migrationBuilder.DropTable(
                name: "tlb_user");

            migrationBuilder.DropTable(
                name: "tbl_book_category");
        }
    }
}
