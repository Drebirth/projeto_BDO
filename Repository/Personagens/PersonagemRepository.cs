using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;

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
    }
}
