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

    // [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
  //  [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode =true)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    [Required(ErrorMessage = "O campo Preco não pode ser vazio!")]
    
    public decimal? Preco { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Apenas números inteiros posítivos.")]
    public int? Quantidade { get; set; }

    public int? SpotId { get; set; }
    
    public ICollection<Mapa>? Spots { get; set; }

    public bool? ItemMercado { get; set; }

    public string? ImagemUrl { get; set; }



}