using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHamburgueria.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEnderecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Enderecos (Bairro, Rua, NumeroCasa, ClienteId)" +
                                "Values ('Doflamingo', 'Av Donquixote', 333, 3)"
           );

            migrationBuilder.Sql("Insert Into Enderecos (Bairro, Rua, NumeroCasa, ClienteId)" +
                                 "Values ('Jeflove', 'jefbalas', 10, 2)"
                                 );

            migrationBuilder.Sql("Insert Into Enderecos (Bairro, Rua, NumeroCasa, ClienteId)" +
                                 "Values ('hot', 'pimenta', 100, 1)"
                                 );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Enderecos");
        }
    }
}
