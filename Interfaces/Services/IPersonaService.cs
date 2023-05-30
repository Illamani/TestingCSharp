using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Interfaces.Services
{
	public interface IPersonaService
	{
		Task CreatePersonaAsync(PersonaInput personaInput);
		Task<List<PersonasDto>> GetListPersonasAsync();
	}
}
