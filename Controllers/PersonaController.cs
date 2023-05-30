using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Interfaces.Services;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonaController : ControllerBase, IPersonaService
	{
		private readonly IPersonaService _personaService;

		public PersonaController(IPersonaService personaService)
        {
			_personaService = personaService;
		}
		[HttpPost]
		[Route("CreatePersonaAsync")]
		public async Task CreatePersonaAsync(PersonaInput personaInput)
		{
			await _personaService.CreatePersonaAsync(personaInput);
		}

		[HttpGet]
		[Route("GetListPersonasAsync")]
		public Task<List<PersonasDto>> GetListPersonasAsync()
		{
			return _personaService.GetListPersonasAsync();
		}
	}
}
