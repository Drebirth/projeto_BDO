

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Entities;
namespace projetoBDO.Context
{
    public class BdoContext : IdentityDbContext
    {
        public BdoContext(DbContextOptions<BdoContext> options) : base(options){ }


        public DbSet<Mapa> Mapas { get; set; }

        public DbSet<Item> Itens { get; set; }

        public DbSet<Personagem> Personagens { get; set; }

        public DbSet<Grind> Grinds { get; set; }

        public DbSet<ItensGrind> ItensGrinds { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Item>()
             .Property(x => x.SpotId)
             .ValueGeneratedNever();


         }*/

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(login => new { login.LoginProvider, login.ProviderKey });

        //    modelBuilder.Entity<Item>()
        //    .Property(x => x.SpotId)
        //    .ValueGeneratedNever();
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
            
        

    }
}