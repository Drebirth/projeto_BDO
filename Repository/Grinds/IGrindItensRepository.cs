using projetoBDO.Entities;

namespace projetoBDO.Repository.Grinds
{
    public interface IGrindItensRepository : IRepository<ItensGrind>
    {
        Task<IEnumerable<ItensGrind?>> GetFindGrindForId(int id);
    }
}
