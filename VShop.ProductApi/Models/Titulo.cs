namespace VShop.ProductApi.Models;

public class Titulo
{
    public int TituloId { get; set; }
    public String? Name { get; set; }
    public ICollection<Cliente>? Clientes { get; set; }
    
}
