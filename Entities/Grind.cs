using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Entities;

namespace projetoBDO.Entities;

public class Grind
{
    [Key]
    public int Id { get; set; }

    public int SpotId { get; set; }

    public int PersonagemId { get; set; }

   // public string? NomePersonagem { get; set; }

    public string Mapa { get; set; }

    // public Spot spot { get; set; }

    //public ICollection<ItensGrind> Itens { get; set; }

    public decimal? ValorTotal { get; set; } 



    //public long Id { get; set; }    

    //[DataType(DataType.Date)]
    //public DateTime DateTime { get; set; }

    //public Spot? Spot { get; set; }

    //public List<Spot>? Spots { get; set; }

    //[Required]
    //public List<Item>? Itens { get; set; } = new List<Item>();

    //[Required]
    //public string PersonagemNome {get;set;}

    //public Personagem? Personagem { get; set; }

    //public List<Personagem>? Personagens { get; set; }

    //[Required]
    //public string? User { get; set; }
    //public int? Quantidade { get; set; }

    //public decimal? ValorTotal { get; set; }

}