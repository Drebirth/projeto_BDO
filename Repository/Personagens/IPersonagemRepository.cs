using projetoBDO.Entities;

namespace projetoBDO.Repository.Personagens
{
    public interface IPersonagemRepository : IRepository<Personagem>
    {

        Task<IEnumerable<Personagem>> GetAllAsync(string userName);
        // You can add any specific methods for Personagem here if needed
        // For example, methods to find characters by specific criteria, etc.
    }
}
