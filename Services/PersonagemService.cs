using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Paginacao;
using projetoBDO.Repository.Personagens;
using System.Security.Claims;

namespace projetoBDO.Services
{
    public class PersonagemService
    {
        private readonly IPersonagemRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public PersonagemService(IPersonagemRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<Personagem>> GetAllPersonagemAsync()
        {
            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var personagens = _repository.GetAllAsync().Result.Where(personagens => personagens.NomeDeFamilia == userName).ToList();
            return await _repository.GetAllAsync(userName);

        }

        public async Task<PaginatedList<Personagem>> GetPersonagemPagina( int pageIndex =1, int pageSize=10)
        {
            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var personagensQuery = _repository.GetPersonagemPagina(userName);
            return await PaginatedList<Personagem>.CreateAsync(personagensQuery, pageIndex, pageSize);
        }

        public async Task<Personagem> GetPersonagemByIdAsync(int id)
        {
            var personagem = await _repository.GetAsync(id);
            if (personagem == null)
            {
                throw new KeyNotFoundException($"Personagem with ID {id} not found.");
            }
            return personagem;
        }

        public async Task CreatePersonagemAsync(PersonagemViewModel personagem)
        {       
          var novoPersonagem = new Personagem
            {
                Nome = personagem.Nome,
                Classe = personagem.Classe,
                Level = personagem.Level,
                NomeDeFamilia = personagem.NomeDeFamilia,
                PA = personagem.PA,
                DP = personagem.DP,
                


          };

            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
                personagem.NomeDeFamilia = userName;
                await _repository.CreateAsync(novoPersonagem);
            
           
        }

        public async Task<ServiceResult> ValidacaoPersonagem(PersonagemViewModel personagem)
        {
            var result = new ServiceResult();
            var NomePersonagemExiste = await _repository.GetPersonagemForName(personagem.Nome);

            if (NomePersonagemExiste != null)
            {
                result.Errors.Add($"Personagem com nome {personagem.Nome} já existe.");
                
            }
            result.Success = result.Errors.Count == 0;
            return result;
        }

        public async Task UpdatePersonagemAsync(Personagem personagem)
        {
            
            await _repository.UpdateAsync(personagem);
        }

        public async Task DeletePersonagemAsync(int id)
        {
            var personagem = await _repository.GetAsync(id);
            if (personagem == null)
            {
                throw new KeyNotFoundException($"Personagem with ID {id} not found.");
            }
            await _repository.DeleteAsync(personagem);
        }

        public async Task<Personagem> NomeDeFamilia(string NomeFamilia)
        {
            
            var nome =  _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            Personagem NovoPersonagem = new Personagem { NomeDeFamilia = nome };
            return NovoPersonagem;



        }
    }
}
