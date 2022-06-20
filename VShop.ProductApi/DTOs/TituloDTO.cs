using System.ComponentModel.DataAnnotations;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class TituloDTO
    {
        public int TituloId { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(3)]
        [MaxLength(20)]
        public String? Name { get; set; }
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
