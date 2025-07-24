using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Repository.Grinds;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace projetoBDO.Services
{
    public class GrindService
    {
        private readonly IGrindRepository _IGrindRepository;
        private readonly IGrindItensRepository _IGrindItensRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MapaService _spotService;
        private readonly ItemService _itemService;
        private readonly PersonagemService _personagemService;

        public GrindService(IGrindRepository grindRepository, IHttpContextAccessor httpContextAccessor,
            MapaService spotService, ItemService itemService, PersonagemService personagemService, IGrindItensRepository iGrindItensRepository)
        {
            _IGrindRepository = grindRepository;
            _httpContextAccessor = httpContextAccessor;
            _spotService = spotService;
            _itemService = itemService;
            _personagemService = personagemService;
            _IGrindItensRepository = iGrindItensRepository;
        }
        public async Task<IEnumerable<Grind>> GetAllAsync()
        {
            return await _IGrindRepository.GetAllAsync();
        }
        public async Task<Grind> GetByIdAsync(int id)
        {
            return await _IGrindRepository.GetAsync(id);
        }
        public async Task CreateAsync(Grind grind, List<Item> itens)
        {
            var personagem = await _personagemService.GetPersonagemByIdAsync(grind.PersonagemId);
            grind.NomePersonagem   = personagem.Nome;            
            await _IGrindRepository.CreateAsync(grind);
           
            for (int i = 0; i < itens.Count; i++)
            {
                
                var itensGrind = new ItensGrind
                {
                    GrindId = grind.Id,
                    ItemNome = itens[i].Nome,
                    Quantidade = itens[i].Quantidade,
                    SubTotal = itens[i].Quantidade * itens[i].Preco ,
                   
                };
                await _IGrindItensRepository.CreateAsync(itensGrind);
                
            }

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

        // Calcula o subtotal de acordo com a quantidade e o preço de cada item
        public decimal CalcularSubTotal(List<Item> itens)
        {
            if (itens == null || itens.Count == 0)
            {
                throw new ArgumentException("A lista de itens não pode ser nula ou vazia.", nameof(itens));
            }
           
            decimal subtotal = 0;
            foreach (var item in itens)
            {
                subtotal += item.Preco * item.Quantidade;
            }
            return subtotal;
        }

        public async Task<GrindViewModel> MontarGrindViewModelAsync(int spotId, string nomeDeFamilia)
        {
            var spot = await _spotService.GetMapaPorId(spotId);
            var itens = (await _itemService.GetAllItemsAsync()).Where(i => i.SpotId == spotId).ToList();
            var personagens = await _personagemService.GetAllPersonagemAsync();
            var personagensFiltrados = personagens.Where(p => p.NomeDeFamilia == nomeDeFamilia).ToList();

            return new GrindViewModel
            {
                MapaId = spotId,
                MapaNome = spot.Nome,
                Itens = itens,
                Personagens = personagensFiltrados
            };
        }
    }
}
