using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHamburgueria.Migrations
{
    /// <inheritdoc />
    public partial class PopulaPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Pedidos (DataPedido, ValorTotal, Status, ClienteId)" +
                                 "Values (GETDATE(), 67.50, 'Preparando', 1)"
           );

            migrationBuilder.Sql("Insert Into Pedidos (DataPedido, ValorTotal, Status, ClienteId)" +
                                 "Values (GETDATE(), 95.80, 'Pronto', 2)"
                                 );

            migrationBuilder.Sql("Insert Into Pedidos (DataPedido, ValorTotal, Status, ClienteId)" +
                                 "Values (GETDATE(), 45.50, 'Saiu pra entrega', 3)"
                                 );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Pedidos");
        }
    }
}
