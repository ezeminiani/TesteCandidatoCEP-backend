using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCandidatoCEP.Repository.Migrations
{
    public partial class correcao_campos_unidade_ibge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "unidade",
                table: "CEP",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ibge",
                table: "CEP",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "unidade",
                table: "CEP",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ibge",
                table: "CEP",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
