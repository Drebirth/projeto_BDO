using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Entities.local;
using projetoBDO.Entities.item;

namespace projetoBDO.Context
{
    public class BdoContext : DbContext
    {
        public BdoContext(DbContextOptions<BdoContext> options) : base(options){ }


        public DbSet<Local> Spots { get; set; }

        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
            .Property(x => x.SpotId)
            .ValueGeneratedNever();

        
        }
        

    }
}