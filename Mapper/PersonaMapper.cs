using Riok.Mapperly.Abstractions;
using System.Collections.Generic;
using TestingPrueba.Models;
using TestingPrueba.Models.Output;

namespace TestingPrueba.Mapper
{
	[Mapper]
	public partial class PersonaMapper
	{
		public partial PersonasDto PersonaToPersonaDto(Persona persona);
		public partial List<PersonasDto> ListPersonaToPersonaDto(List<Persona> persona);
	}
}
