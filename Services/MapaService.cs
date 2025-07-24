using projetoBDO.Entities;
using projetoBDO.Repository.Mapas;

namespace projetoBDO.Services
{
    public class MapaService
    {
        private readonly IMapaRepository _mapaRepository;

        public MapaService(IMapaRepository mapaRepository)
        {
            _mapaRepository = mapaRepository;
        }

        public async Task<IEnumerable<Mapa>> GetAllMapasAsync()
        {
            return await _mapaRepository.GetAllAsync();
        }

        public async Task<Mapa> CreateMapaAsync(Mapa mapa)
        {
            var existingMapa = await _mapaRepository.GetAsync(mapa.Id);
            if (existingMapa != null)
            {
                throw new InvalidOperationException($"Mapa com ID {mapa.Id} já existe.");
            }

            await _mapaRepository.CreateAsync(mapa);
            return mapa;
        }

        public async Task<Mapa> GetMapaPorId(int id)
        {
            var mapa = await _mapaRepository.GetAsync(id);
            if (mapa == null)
            {
                throw new KeyNotFoundException($"Mapa com  ID {id} não encontrado!.");
            }
            return mapa;
        }

        public async Task<Mapa> UpdateMapaAsync(Mapa mapa)
        {                        
            await _mapaRepository.UpdateAsync(mapa);
            return mapa;
        }

        public async Task DeleteMapaAsync(int id)
        {
            var mapa = await _mapaRepository.GetAsync(id);
            if (mapa == null)
            {
                throw new KeyNotFoundException($"Mapa com ID {id} não encontrado.");
            }
            await _mapaRepository.DeleteAsync(mapa);
        }
    }
}
