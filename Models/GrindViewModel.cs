using projetoBDO.Entities;
using System.ComponentModel.DataAnnotations;

namespace projetoBDO.Models
{
    public class GrindViewModel
    {
       public int MapaId { get; set; }
       public string MapaNome { get; set; }
        [Required(ErrorMessage="O Personagem é obrigatório!")]
        public int? PersonagemId { get; set; }
        public string? PersonagemNome { get; set; }
        public List<Personagem>? Personagens { get; set; }
       public List<Item>? Itens { get; set; }
        //public ICollection<ItensGrind>? Itensgrind { get; set; }
       
        public int? Quantidade { get; set; }
       public decimal? ValorTotal { get; set; }


    }
}
