using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SobreNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDbSet", x => x.Id);
                });
                migrationBuilder.Sql(
                   "INSERT INTO UsuarioDbSet VALUES " +
                   "('renan', 'voilar','2014-10-29','Masculino','11839750073','11-11111-1212','renan@hotmail.com')," +
                   "('lorena', 'Simpson','1990-10-06','Feminino','87812312312','48-99838-2131','Lorena@hotmail.com')," +
                   "('joao', 'kadu','1993-04-20','Masculino','89891231231','11-98893-1212','joao@hotmail.com')," +
                   "('Joana', 'silva','1999-11-03','Feminino','09090123121','11-99183-1232','joana@hotmail.com')," +
                   "('Vitor', 'hugo','1980-05-02','Masculino','76878712311','47-12312-1212','vitor@hotmail.com')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDbSet");
        }
    }
}
