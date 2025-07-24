using System.ComponentModel.DataAnnotations;

namespace projetoBDO.Entities
{
    public class ItensGrind
    {
        [Key]
        public int Id { get; set; }

        public int GrindId { get; set; }
        public ICollection<Grind>? grinds { get; set; }

        public List<Item>? Itens { get; set; }

        public string? ItemNome { get; set; }

        public int? Quantidade { get; set; }

        public decimal? SubTotal { get; set; }

        //public decimal Subtotal => Itens.Sum(i => i.Preco * Quantidade);
    }
}
