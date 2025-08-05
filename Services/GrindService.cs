using PagedList;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Paginacao;
using projetoBDO.Repository.Grinds;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<PaginatedList<Grind>> GetGrindsPagina(int pageIndex = 1, int pageSize = 15)
        {
           // // Solicito todos os grinds
           //var grinds = await _IGrindRepository.GetAllAsync();
           // // Conto a quantidade de grinds
           // var count = grinds.Count();
           // // Ordeno o grind  pelo ID pageIndex= Posicao 1 - 1 * Tamanho da pagina
           // var items = grinds
           //     .OrderBy(c => c.Id)
           //     .Skip((pageIndex - 1) * pageSize)
           //     .Take(pageSize)
           //     .ToList();
           // // Retorno a lista paginada
           // return new PaginatedList<Grind>(items, count, pageIndex, pageSize);

            // Utilizo o metodo CreateAsync para criar a lista paginada
            // lista já transformada em Asqueryable
            var grinds =  _IGrindRepository.GetAllAsyncPaginacao();
            return await PaginatedList<Grind>.CreateAsync(grinds, pageIndex, pageSize);

        }
        public async Task<Grind> GetByIdAsync(int id)
        {
            return await _IGrindRepository.GetAsync(id);
        }
     
        public async Task CreateAsync(Grind grind, List<Item> itens)
        {
            var personagem = await _personagemService.GetPersonagemByIdAsync(grind.PersonagemId);
            grind.NomePersonagem = personagem.Nome;
            grind.ValorTotal = CalcularSubTotal(itens); // Corrige o valor total para centavos
            await _IGrindRepository.CreateAsync(grind);
            decimal subTotal = 0;
            for (int i = 0; i < itens.Count; i++)
            {
                if (itens[i].Quantidade > 0)
                {
                    string valorString = itens[i].Preco.ToString(); // Se Preco for nulo, atribui 0 
                    decimal valorCorrigido;
                    if(!valorString.EndsWith("0"))
                    {
                        valorCorrigido = (decimal)(itens[i].Preco / 100m);
                        
                        var itensGrind = new ItensGrind
                        {
                            GrindId = grind.Id,
                            ItemNome = itens[i].Nome,
                            Quantidade = itens[i].Quantidade,
                            PrecoUnitario = valorCorrigido,
                            Total = Math.Round((decimal)(itens[i].Quantidade * valorCorrigido), 2, MidpointRounding.AwayFromZero),
                        };
                        await _IGrindItensRepository.CreateAsync(itensGrind);
                    }
                    else
                    {
                        var itensGrind = new ItensGrind
                        {
                            GrindId = grind.Id,
                            ItemNome = itens[i].Nome,
                            Quantidade = itens[i].Quantidade,
                            PrecoUnitario = Math.Round(itens[i].Preco ?? 0m, 2, MidpointRounding.AwayFromZero),
                            Total = Math.Round((decimal)(itens[i].Quantidade * itens[i].Preco), 2, MidpointRounding.AwayFromZero),
                        };
                        await _IGrindItensRepository.CreateAsync(itensGrind);
                    }
                }

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
           var itensGrind =  await _IGrindItensRepository.GetFindGrindForId(id);
            foreach (var item in itensGrind)
            {
                await _IGrindItensRepository.DeleteAsync(item);
            }
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
               var valorString = item.Preco.ToString();
                if (item.Quantidade >= 1 && !valorString.EndsWith("0"))
                {
                    //decimal precoCorrigido = (item.Preco.HasValue ? item.Preco.Value : 0m)/100m; // Corrige o preço para centavos
                    decimal precoCorrigido = (decimal)(item.Preco / 100m);
                    subtotal += (decimal)(precoCorrigido * item.Quantidade);
                }
                else
                {
                    subtotal += (item.Preco * item.Quantidade) ?? 0m; // Se Preco for nulo, atribui 0
                }
            }
            return subtotal;
        }

        public async Task<GrindViewModel> MontarGrindViewModelAsync(int spotId, string nomeDeFamilia)
        {
            var spot = await _spotService.GetMapaPorId(spotId);
            var itens = (await _itemService.GetAllItemsAsync()).Where(i => i.SpotId == spotId).OrderByDescending(i => i.ItemMercado == true ).ToList();
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
