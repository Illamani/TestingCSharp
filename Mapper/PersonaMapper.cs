using Riok.Mapperly.Abstractions;
using System.Collections.Generic;
using TestingPrueba.Models;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Mapper
{
	[Mapper]
	public partial class PersonaMapper
	{
		public partial PersonasDto PersonaToPersonaDto(Persona persona);
		public partial List<PersonasDto> ListPersonaToPersonaDto(List<Persona> persona);
		public partial Persona PersonaInputToPersona(PersonaInput personaInput);
		public partial List<PersonaInput> ListPersonaInputToPersona(List<Persona> persona);
	}
}
