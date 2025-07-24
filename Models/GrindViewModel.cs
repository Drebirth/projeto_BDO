using projetoBDO.Entities;

namespace projetoBDO.Models
{
    public class GrindViewModel
    {
       public int MapaId { get; set; }
       public string MapaNome { get; set; }
       public int PersonagemId { get; set; }
        public string? PersonagemNome { get; set; }
        public List<Personagem>? Personagens { get; set; }
       public List<Item>? Itens { get; set; }
       //public ICollection<ItensGrind>? Itensgrind { get; set; }
        public int Quantidade { get; set; }
       
    }
}
