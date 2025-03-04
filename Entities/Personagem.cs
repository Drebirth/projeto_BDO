using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoBDO.Models;

namespace projetoBDO.Entities;

public class Personagem
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Classe { get; set; }
    public int PA {get; set; }
    public int DP { get; set; }  
    public int Level { get; set; }

    public string User { get; set; }
}