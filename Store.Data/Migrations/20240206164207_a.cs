using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountOfSalers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookBranch",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    Branchesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBranch", x => new { x.BooksId, x.Branchesid });
                    table.ForeignKey(
                        name: "FK_BookBranch_BookList_BooksId",
                        column: x => x.BooksId,
                        principalTable: "BookList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBranch_BranchList_Branchesid",
                        column: x => x.Branchesid,
                        principalTable: "BranchList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalerList_BranchList_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBranch_Branchesid",
                table: "BookBranch",
                column: "Branchesid");

            migrationBuilder.CreateIndex(
                name: "IX_SalerList_BranchId",
                table: "SalerList",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBranch");

            migrationBuilder.DropTable(
                name: "SalerList");

            migrationBuilder.DropTable(
                name: "BookList");

            migrationBuilder.DropTable(
                name: "BranchList");
        }
    }
}
