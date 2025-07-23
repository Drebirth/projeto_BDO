namespace projetoBDO.Entities
{
    public class ItensGrind
    {
        public ICollection<Item> Itens { get; set; }

        public int Quantidade { get; set; }

        //public decimal Subtotal => Itens.Sum(i => i.Preco * Quantidade);
    }
}
