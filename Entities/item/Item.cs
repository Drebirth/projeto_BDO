using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Entities.local;

namespace projetoBDO.Entities.item
{
    public class Item
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "O campo Nome não pode ser vazio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Preco não pode ser vazio!")]
        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public long SpotId { get; set; }
    
        public Local? Spot { get; set; }

    }
}