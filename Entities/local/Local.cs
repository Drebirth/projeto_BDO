using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Entities.item;

namespace projetoBDO.Entities.local
{
    public class Local
    {

        
        public long Id { get; set; }
        public string Nome { get; set; }

        public List<Item>? itens { get; set; }
        
        
    }
}