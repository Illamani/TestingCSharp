using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Context;
using TestingPrueba.Interfaces.Repository;
using TestingPrueba.Interfaces.Services;
using TestingPrueba.Mapper;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Services
{
	public class PersonaService : IPersonaService
	{
		private readonly AppDbContext _context;
		private readonly IPersonaRepository _personaRepository;
		public PersonaService(AppDbContext context, IPersonaRepository personaRepository)
        {
            _context = context;
			_personaRepository = personaRepository;
        }
        public async Task<List<PersonasDto>> GetListPersonasAsync()
		{
			PersonaMapper mapper = new();
			var personas = await _personaRepository.GetListPersonasAsync();
			var personasDto = mapper.ListPersonaToPersonaDto(personas);
			return personasDto;
		}
		public async Task CreatePersonaAsync(PersonaInput personaInput)
		{
			PersonaMapper mapper = new();
			var persona = mapper.PersonaInputToPersona(personaInput);
			await _personaRepository.CreatePersonaAsync(persona);
		}
	}
}
