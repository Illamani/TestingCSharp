using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Context;
using TestingPrueba.Interfaces.Repository;
using TestingPrueba.Models;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Repository
{
	public class PersonaRepository : IPersonaRepository
	{
		private readonly AppDbContext _context;
		public PersonaRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<Persona>> GetListPersonasAsync()
		{
			var personas = await _context.Persona.ToListAsync();
			return personas;
		}
		public async Task CreatePersonaAsync(Persona persona)
		{
			await _context.Persona.AddAsync(persona);
			await _context.SaveChangesAsync();
		}
	}
}
