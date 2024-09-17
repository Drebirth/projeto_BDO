using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Entities.item;
using projetoBDO.Entities.local;
using projetoBDO.Entities.personagem;

namespace projetoBDO.Entities.grind
{
    public class Grind
    {
        public long Id { get; set; }    
        public Local? Spot { get; set; }
        
        public List<Item> Itens { get; set; }
        public Personagem Personagem { get; set; }

        public List<Personagem>? Personagens { get; set; }
        
        public string User { get; set; }
        public int Quantidade { get; set; }

        public List<int> Quantidades { get; set; }
        public double ValorTotal { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}