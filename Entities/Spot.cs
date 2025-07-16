using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using projetoBDO.Entities;

namespace projetoBDO.Entities;


public class Spot
{

    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
    public string Nome { get; set; }

    public int? NivelRecomendado { get; set; }

    public int? AtaqueRecomendado { get; set; }

    public int? DefesaRecomendada { get; set; }

    public string? ImagemUrl { get; set; }
    
    public List<Item>? Itens { get; set; }

    

  
    
    
}