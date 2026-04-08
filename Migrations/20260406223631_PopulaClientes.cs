using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHamburgueria.Migrations
{
    /// <inheritdoc />
    public partial class PopulaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Clientes (Nome, Email, NumeroTelefone)" +
                                 "Values ('Jeferson', 'jeferson@gmail.com', '1699999999')"
                                 );

            migrationBuilder.Sql("Insert Into Clientes (Nome, Email, NumeroTelefone)" +
                                 "Values ('Ana Beatriz', 'aninhabia@gmail.com', '1699999998')"
                                 );

            migrationBuilder.Sql("Insert Into Clientes (Nome, Email, NumeroTelefone)" +
                                 "Values ('James Carl', 'james@gmail.com', '1699999997')"
                                 );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Clientes");

        }
    }
}
