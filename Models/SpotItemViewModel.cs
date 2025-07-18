using projetoBDO.Entities;
using System.ComponentModel.DataAnnotations;

namespace projetoBDO.Models
{
    public class SpotItemViewModel
    {
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo Preco não pode ser vazio!")]
        public decimal Preco { get; set; }

        public int? SpotId { get; set; }

        public Spot? Spot { get; set; }

        public string? ImagemUrl { get; set; }
    }
}
