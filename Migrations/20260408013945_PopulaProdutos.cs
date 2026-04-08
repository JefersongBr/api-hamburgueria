using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHamburgueria.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Produtos (Nome, Valor)" +
           "Values ('Grill Burguer', 21.50)"
           );

            migrationBuilder.Sql("Insert Into Produtos (Nome, Valor)" +
                                 "Values ('Grill Costela', 24.00)"
                                 );

            migrationBuilder.Sql("Insert Into Produtos (Nome, Valor)" +
                                 "Values ('Grill Picanha', 29.50)"
                                 );

            migrationBuilder.Sql("Insert Into Produtos (Nome, Valor)" +
                                 "Values ('Grill Fraldinha', 27.50)"
                                 );

            migrationBuilder.Sql("Insert Into Produtos (Nome, Valor)" +
                                 "Values ('Double Burguer', 32.50)"
                                 );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
