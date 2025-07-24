using projetoBDO.Context;
using projetoBDO.Entities;
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

        public async Task<Personagem> GetPersonagemByIdAsync(int id)
        {
            var personagem = await _repository.GetAsync(id);
            if (personagem == null)
            {
                throw new KeyNotFoundException($"Personagem with ID {id} not found.");
            }
            return personagem;
        }

        public async Task CreatePersonagemAsync(Personagem personagem)
        {
            if (personagem == null)
            {
                throw new ArgumentNullException(nameof(personagem), "Personagem cannot be null.");
            }
            var userName = _httpContext.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            personagem.NomeDeFamilia = userName;
            await _repository.CreateAsync(personagem);
        }

        public async Task UpdatePersonagemAsync(Personagem personagem)
        {
            if (personagem == null)
            {
                throw new ArgumentNullException(nameof(personagem), "Personagem cannot be null.");
            }
            var existingPersonagem = await _repository.GetAsync(personagem.Id);
            if (existingPersonagem == null)
            {
                throw new KeyNotFoundException($"Personagem with ID {personagem.Id} not found.");
            }
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
