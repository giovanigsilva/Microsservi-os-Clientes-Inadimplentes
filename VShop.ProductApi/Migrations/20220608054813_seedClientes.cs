using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class seedClientes : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into clientes(Name, Valor, Desde, tituloId) " +
                "values ('Giovani', 45.50, '2021-12-04', 1) ");
            mb.Sql("insert into clientes(Name, Valor, Desde, tituloId) " +
                "values ('Marcos', 335.50, '2021-12-23', 2) ");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from clientes");
        }
    }
}
