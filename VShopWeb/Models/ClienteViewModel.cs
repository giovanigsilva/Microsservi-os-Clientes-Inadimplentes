using System.ComponentModel.DataAnnotations;

namespace VShop.Web.Models;

public class ClienteViewModel
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Desde { get; set; }

    //[HiddenInput(DisplayValue = false)]

    public String? TituloName { get; set; }

    [Display(Name="Categorias")]
    public int TituloId { get; set; }
}
