using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;
using System.Threading.Tasks;

namespace projetoBDO.Repository.Personagens
{
    public class PersonagemRepository : Repository<Personagem>, IPersonagemRepository
    {
        public PersonagemRepository(BdoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Personagem>> GetAllAsync(string userName)
        {
            return await _context.Personagens
                .Where(p => p.NomeDeFamilia == userName)
                .ToListAsync();
        }

       

        // You can add any specific methods for Personagem here if needed
        // For example, methods to find characters by specific criteria, etc.

        public IQueryable<Personagem> GetPersonagemPagina(string NomeDeFamilia)
        {
            //return  _context.Personagens
            //    .AsNoTracking()
            //    .OrderBy(p => p.NomeDeFamilia)
            //    .AsQueryable()
            //    .ToListAsync()
            //    .ContinueWith(t => t.Result.AsQueryable());

            var personagens = _context.Personagens
                .Where(p => p.NomeDeFamilia == NomeDeFamilia)
                .AsQueryable();
            return personagens;
        }

        public async Task<Personagem> GetPersonagemForName(string Nome)
        {
            return await _context.Personagens
                .FirstOrDefaultAsync(p => p.Nome == Nome);
        }
    }
}
