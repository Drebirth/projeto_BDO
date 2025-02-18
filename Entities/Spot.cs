using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using projetoBDO.Entities.item;

namespace projetoBDO.Entities.spot

{
    public class Spot
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
        public string Nome { get; set; }

        public List<Item>? Itens { get; set; }

        

      
        
        
    }
}