using projetoBDO.Entities;
using projetoBDO.Repository.Spots;

namespace projetoBDO.Services
{
    public class SpotService
    {
        private readonly ISpotRepository _spotRepository;

        public SpotService(ISpotRepository spotRepository)
        {
            _spotRepository = spotRepository;
        }

        public async Task<IEnumerable<Spot>> GetAllSpotsAsync()
        {
            return await _spotRepository.GetAllAsync();
        }

        public async Task<Spot> CreateSpotAsync(Spot spot)
        {
            var existingSpot = await _spotRepository.GetAsync(spot.Id);
            if (existingSpot != null)
            {
                throw new InvalidOperationException($"Spot com ID {spot.Id} já existe.");
            }

            await _spotRepository.CreateAsync(spot);
            return spot;
        }

        public async Task<Spot> GetSpotPorId(int id)
        {
            var spot = await _spotRepository.GetAsync(id);
            if (spot == null)
            {
                throw new KeyNotFoundException($"Spot com  ID {id} não encontrado!.");
            }
            return spot;
        }

        public async Task<Spot> UpdateSpotAsync(Spot spot)
        {                        
            await _spotRepository.UpdateAsync(spot);
            return spot;
        }

        public async Task DeleteSpotAsync(int id)
        {
            var spot = await _spotRepository.GetAsync(id);
            if (spot == null)
            {
                throw new KeyNotFoundException($"Spot com ID {id} não encontrado.");
            }
            await _spotRepository.DeleteAsync(spot);
        }
    }
}
