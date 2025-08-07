using projetoBDO.Entities;
using projetoBDO.Paginacao;
using projetoBDO.Repository.Mapas;

namespace projetoBDO.Services
{
    public class MapaService
    {
        private readonly IMapaRepository _mapaRepository;
        private readonly ItemService _itemService;

        public MapaService(IMapaRepository mapaRepository, ItemService itemService)
        {
            _mapaRepository = mapaRepository;
            _itemService = itemService;
        }

        public async Task<IEnumerable<Mapa>> GetAllMapasAsync()
        {
            return await _mapaRepository.GetAllAsync();
        }

        public async Task<PaginatedList<Mapa>> GetMapasPagina(int pageIndex = 1, int pageSize = 15)
        {
            // Utilizo o metodo CreateAsync para criar a lista paginada
            // lista já transformada em Asqueryable
            var mapas = _mapaRepository.GetAllAsyncPaginacao();
            return await PaginatedList<Mapa>.CreateAsync(mapas, pageIndex, pageSize);
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
            var itemMapa = await _itemService.GetItensBySpot(id);
            
            var mapaCompleto = new Mapa
            {
                Id = mapa.Id,
                Nome = mapa.Nome,
                NivelRecomendado = mapa.NivelRecomendado,
                AtaqueRecomendado = mapa.AtaqueRecomendado,
                DefesaRecomendada = mapa.DefesaRecomendada,
                ImagemUrl = mapa.ImagemUrl,
                Itens = itemMapa.ToList()
            };
            return mapaCompleto;
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
