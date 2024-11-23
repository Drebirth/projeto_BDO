using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using projetoBDO.Entities.item;

namespace projetoBDO.Entities.local
{
    public class Local
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
        [DataType(DataType.Text,ErrorMessage ="O campo deve conter apenas letras")]
        public string Nome { get; set; }

        public List<Item>? Itens { get; set; }

        

      
        
        
    }
}