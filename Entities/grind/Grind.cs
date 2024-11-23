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
        
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public Local? Spot { get; set; }

        public List<Local>? Spots { get; set; }
        
        [Required]
        public List<Item>? Itens { get; set; } = new List<Item>();

        [Required]
        public string PersonagemNome {get;set;}
        
        
        //[Required(ErrorMessage = "Personagem é requirido")]
        public Personagem? Personagem { get; set; }
        /*
        [Required(ErrorMessage = "Personagem é requirido")]
        public List<Personagem>? Personagens { get; set; }
        */
        [Required]
        public string? User { get; set; }
        public int? Quantidade { get; set; }

        public decimal? ValorTotal { get; set; }
      
    }
}