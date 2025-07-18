using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using projetoBDO.Entities;

namespace projetoBDO.Entities;


public class Spot
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Nivel Recomendado não pode ser vazio!")]
    public int? NivelRecomendado { get; set; }
    [Required(ErrorMessage = "O campo Ataque Recomendado não pode ser vazio!")]
    public int? AtaqueRecomendado { get; set; }
    [Required(ErrorMessage = "O campo Defesa Recomendada não pode ser vazio!")]
    public int? DefesaRecomendada { get; set; }

    public ICollection<Item>? Itens { get; set; }

    public string? ImagemUrl { get; set; }
    
    

    

  
    
    
}