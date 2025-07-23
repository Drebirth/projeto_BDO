using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Models;

namespace projetoBDO.Entities;

public class Personagem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string NomeDeFamilia { get; set; }
    public string? Nome { get; set; }
    public string? Classe { get; set; }
    public int? PA {get; set; }
    public int? DP { get; set; }  
    public int? Level { get; set; }
    
}