using projetoBDO.Entities;
using projetoBDO.Repository.Grinds;
using System.Security.Cryptography;

namespace projetoBDO.Services
{
    public class GrindService
    {
        private readonly IGrindRepository _IGrindRepository;

        public GrindService(IGrindRepository grindRepository)
        {
            _IGrindRepository = grindRepository;
        }
        public async Task<IEnumerable<Grind>> GetAllAsync()
        {
            return await _IGrindRepository.GetAllAsync();
        }
        public async Task<Grind> GetByIdAsync(int id)
        {
            return await _IGrindRepository.GetAsync(id);
        }
        public async Task CreateAsync(Grind grind)
        {
            await _IGrindRepository.CreateAsync(grind);
        }
        public async Task UpdateAsync(Grind grind)
        {
            await _IGrindRepository.UpdateAsync(grind);
        }
        public async Task DeleteAsync(int id)
        {
            var grind = await _IGrindRepository.GetAsync(id);
            await _IGrindRepository.DeleteAsync(grind);
        }
    }
}
