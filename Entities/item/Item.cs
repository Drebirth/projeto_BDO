using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Entities.local;

namespace projetoBDO.Entities.item
{
    public class Item
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public long SpotId { get; set; }
    
        public Local? Spot { get; set; }

       /* public Item( string nome, double preco, Local spot)
        {
            Nome = nome;
            Preco = preco;
            Spot = spot;
        }*/
    }
}