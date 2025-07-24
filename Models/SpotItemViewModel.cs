using projetoBDO.Entities;
using System.Collections.Generic;

namespace projetoBDO.Models
{
    public class MapaItemViewModel
    {
        public Mapa Mapa { get; set; }
        public IEnumerable<Item> Itens { get; set; }
    }
}
