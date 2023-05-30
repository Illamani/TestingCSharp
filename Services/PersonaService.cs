using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Context;
using TestingPrueba.Interfaces.Services;
using TestingPrueba.Mapper;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Services
{
	public class PersonaService : IPersonaService
	{
		private readonly AppDbContext _context;
		public PersonaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<PersonasDto>> GetListPersonasAsync()
		{
			PersonaMapper mapper = new PersonaMapper();
			var personas = await _context.Persona.ToListAsync();
			var personasDto = mapper.ListPersonaToPersonaDto(personas);
			return personasDto;
		}
	}
}
