using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCandidatoCEP.Repository.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cep = table.Column<string>(type: "char(9)", nullable: true),
                    logradouro = table.Column<string>(maxLength: 500, nullable: true),
                    complemento = table.Column<string>(maxLength: 500, nullable: true),
                    bairro = table.Column<string>(maxLength: 500, nullable: true),
                    localidade = table.Column<string>(maxLength: 500, nullable: true),
                    uf = table.Column<string>(type: "char(9)", maxLength: 2, nullable: true),
                    unidade = table.Column<long>(nullable: false),
                    ibge = table.Column<int>(nullable: false),
                    gia = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEP");
        }
    }
}
