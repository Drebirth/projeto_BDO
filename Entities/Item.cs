using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Entities;

namespace projetoBDO.Entities;

public class Item
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo Preco não pode ser vazio!")]
    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public long SpotId { get; set; }

    public Spot? Spot { get; set; }

}