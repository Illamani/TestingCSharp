using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Models;

namespace TestingPrueba.Interfaces.Repository
{
	public interface IPersonaRepository
	{
		Task CreatePersonaAsync(Persona persona);
		Task<List<Persona>> GetListPersonasAsync();
	}
}
