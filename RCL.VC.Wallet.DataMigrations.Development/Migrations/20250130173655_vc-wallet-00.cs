using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCL.VC.Wallet.DataMigrations.Development.Migrations
{
    /// <inheritdoc />
    public partial class vcwallet00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rcl_learn_vc_wallet_holder_did",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    holderId = table.Column<int>(type: "int", nullable: false),
                    did = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rcl_learn_vc_wallet_holder_did", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rcl_vc_wallet_holder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    countryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    region = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rcl_vc_wallet_holder", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rcl_learn_vc_wallet_holder_did");

            migrationBuilder.DropTable(
                name: "rcl_vc_wallet_holder");
        }
    }
}
