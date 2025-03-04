using projetoBDO.Entities;

namespace projetoBDO.Models
{
    public class SpotItemViewModel
    {
        public Spot? spot { get; set; }

        public List<Spot>? spots { get; set; }
        
        public long? SpotId { get; set; }

        public List<Item>? itens { get; set; }

        public Item item { get; set; }
    }
}
