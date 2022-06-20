namespace VShop.ProductApi.Models;

public class Cliente
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Valor { get; set; }
    public DateTime Desde { get; set; }  
    public Titulo? Titulo { get; set; }
    public int TituloId { get; set; }

}
