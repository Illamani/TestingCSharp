using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Interfaces.Services
{
	public interface IPersonaService
	{
		Task<List<PersonasDto>> GetListPersonasAsync();
	}
}
