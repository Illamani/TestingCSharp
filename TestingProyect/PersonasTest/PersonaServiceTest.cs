using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestingPrueba.Context;
using TestingPrueba.Interfaces.Repository;
using TestingPrueba.Mapper;
using TestingPrueba.Models;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;
using TestingPrueba.Repository;
using TestingPrueba.Services;
using Xunit;

namespace TestingProyect.PersonasTest
{
	public class PersonaServiceTest
	{
		//private readonly PersonaService _personaService;
		//private readonly IPersonaRepository _personaRepository;
        public PersonaServiceTest()
        {
			//Sut
			//_personaRepository = Mock.Of<IPersonaRepository>();
			//_personaService = new PersonaService(_personaRepository);
        }
        [Fact]
		public async Task GetListPersonasAsync_ShouldReturnPersonasDto()
		{// Arrange
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
		[Fact]
		public async Task CreatePersonaAsync_Should_Create_Persona()
		{
			// Arrange
			var personaInput = new PersonaInput
			{
				Id = 1,
				LastName = "Ball",
				Name = "Lonzo"
			};
			var personas = new Persona()
			{
				Id = 1,
				Name = "Juan",
				LastName = "Perez"
			};

			var personaRepositoryMock = new Mock<IPersonaRepository>();
			personaRepositoryMock.Setup(repo => repo.CreatePersonaAsync(It.IsAny<Persona>())).Verifiable();

			var sut = new PersonaService(personaRepositoryMock.Object);

			// Act
			await sut.CreatePersonaAsync(It.IsAny<PersonaInput>());
			
			// Assert
			personaRepositoryMock.Verify(repo => repo.CreatePersonaAsync(It.IsAny<Persona>()), Times.Once);
		}
	}
}
