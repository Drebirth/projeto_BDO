using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Entities.item;
using projetoBDO.Entities.spot;
using projetoBDO.Entities.personagem;

namespace projetoBDO.Entities.grind
{
    public class Grind
    {
        public long Id { get; set; }    
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public Spot? Spot { get; set; }

        public List<Spot>? Spots { get; set; }
        
        [Required]
        public List<Item>? Itens { get; set; } = new List<Item>();

        [Required]
        public string PersonagemNome {get;set;}
        
        public Personagem? Personagem { get; set; }
        
        [Required]
        public string? User { get; set; }
        public int? Quantidade { get; set; }

        public decimal? ValorTotal { get; set; }
      
    }
}