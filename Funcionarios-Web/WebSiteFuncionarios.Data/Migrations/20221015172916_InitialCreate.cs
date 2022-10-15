using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSiteFuncionarios.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    FuncaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Salario = table.Column<double>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.FuncaoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: true),
                    Dependentes = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    FuncaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "FuncaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Descricao" },
                values: new object[] { 1, "Infraestrutura" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Descricao" },
                values: new object[] { 2, "Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Descricao" },
                values: new object[] { 3, "Segurança" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "FuncaoId", "Descricao", "Salario" },
                values: new object[] { 1, "Técnico de TI", 1200.0 });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "FuncaoId", "Descricao", "Salario" },
                values: new object[] { 2, "Técnico de Segurança", 3000.0 });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "FuncaoId", "Descricao", "Salario" },
                values: new object[] { 3, "Desenvolvedor", 2200.0 });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "FuncaoId", "Descricao", "Salario" },
                values: new object[] { 4, "Analista de Dados", 2200.0 });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "FuncaoId", "Descricao", "Salario" },
                values: new object[] { 5, "QA Tester", 2200.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FuncaoId",
                table: "Funcionarios",
                column: "FuncaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcoes");
        }
    }
}
