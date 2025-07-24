using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Entities;

namespace projetoBDO.Entities;

public class Item
{
    [Key]
    public int IdItem { get; set; }
    
    [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo Preco não pode ser vazio!")]
    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public int? SpotId { get; set; }
    
    public ICollection<Mapa>? Spots { get; set; }

    public string? ImagemUrl { get; set; }



}