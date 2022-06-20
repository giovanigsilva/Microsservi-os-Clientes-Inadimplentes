using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(3)]
        [MaxLength(100)]    
        public string? Name { get; set; }

        [Required(ErrorMessage = "Valor requerido")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data requerido")]
        [DisplayFormat(DataFormatString = "yyyy/mm/dd")]
        public DateTime Desde { get; set; }

        public string? TituloName { get; set; }

        [JsonIgnore]
        public Titulo? Titulo { get; set; }
        public int TituloId { get; set; }
    }
}
