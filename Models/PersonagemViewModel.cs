using projetoBDO.Entities;
using System.ComponentModel.DataAnnotations;

namespace projetoBDO.Models
{
    public class PersonagemViewModel
    {
       
        public string NomeDeFamilia { get; set; }
        public string? Nome { get; set; }
        public ClassesBDO Classes { get; set; }
        public string? Classe { get; set; }
        public int? PA { get; set; }
        public int? DP { get; set; }
        public int? Level { get; set; }
    }
}
