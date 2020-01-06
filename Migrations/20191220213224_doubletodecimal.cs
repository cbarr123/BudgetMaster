using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetMaster.Migrations
{
    public partial class doubletodecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProjectedIncomes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProjectedExpenses",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ActualIncomes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ActualExpenses",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c1c3450-f809-47c1-a4aa-cd043cc52662", "AQAAAAEAACcQAAAAEMgbRF6DuBXmGyAoTtMZQYD1fkPk9hnXn1qiKmfFpzHJPknz6qX5AmralJHIbBbfhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "452ff5c9-5c97-4492-83f7-4493d366f6bf", "AQAAAAEAACcQAAAAEFVpQZMXSvhRkPFgxVn2C6osLSMMsBd9Pmy1bXm2j/vxpy+iRpG70IqQwZXT8/SHtQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProjectedIncomes",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProjectedExpenses",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ActualIncomes",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ActualExpenses",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a610716b-9626-4d73-88e2-029d539450ae", "AQAAAAEAACcQAAAAEFgY4G91igy5N7CasBDhocxW1/t5ruHrdbimWywgCv3JaHPdgQaX8E5C2xdWBR7hYA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fde0be76-9a75-413f-93e2-b9ed44d94764", "AQAAAAEAACcQAAAAEKDXi7BTHw7dctoxK92ToYXT7iNEXKR3dkH/ooDWns2JWGxnN2Im4SgoPsm2Alt30Q==" });
        }
    }
}
