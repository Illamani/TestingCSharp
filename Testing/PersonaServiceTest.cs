using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingPrueba.Interfaces.Repository;
using TestingPrueba.Models.Output;
using TestingPrueba.Models;
using TestingPrueba.Services;
using Xunit;
using TestingPrueba.Mapper;
using FluentAssertions;

namespace TestingPrueba.Testing
{
	public class PersonaServiceTest
	{
		[Fact]
		public async Task GetListPersonasAsync_ShouldReturnPersonasDto()
		{
			// Arrange
			var mockMapper = new PersonaMapper();
			var mockRepository = new Mock<IPersonaRepository>();
			var service = new PersonaService(mockRepository.Object);

			var personas = new List<Persona>
			{
				new Persona { Id = 1, Name = "Juan", LastName = "Perez" },
				new Persona { Id = 2, Name = "Ana", LastName = "Perez" }
			};

			var personasDto = new List<PersonasDto>
			{
				new PersonasDto { Id = 1, Name = "Juan", LastName = "Perez" },
				new PersonasDto { Id = 2, Name = "Ana", LastName = "Perez" }
			};

			mockRepository.Setup(r => r.GetListPersonasAsync()).ReturnsAsync(personas);

			// Act
			var result = await service.GetListPersonasAsync();

			// Assert
			result.Should().BeEquivalentTo(personasDto);
		}
	}
}
