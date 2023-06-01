using FluentAssertions;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestingPrueba.Context;
using TestingPrueba.Controllers;
using TestingPrueba.Interfaces.Repository;
using TestingPrueba.Interfaces.Services;
using TestingPrueba.Mapper;
using TestingPrueba.Models;
using TestingPrueba.Models.Input;
using TestingPrueba.Models.Output;
using TestingPrueba.Repository;
using TestingPrueba.Services;
using Xunit;

namespace TestingProyect.PersonasTest
{
	public class PersonaControllerTest
	{
		[Fact]
		public async Task TestPostMethod()
		{
			// Arrange
			var mockRepository = new Mock<IPersonaService>(); // Crea un mock del repositorio necesario para el método POST
			var controller = new PersonaController(mockRepository.Object); // Inyecta el mock en el controlador

			var model = new PersonaInput
			{
				Id = 1,
				LastName = "Ball",
				Name = "Lonzo"
			};

			// Act
			await controller.CreatePersonaAsync(model);

			// Assert
			mockRepository.Verify(r => r.CreatePersonaAsync(model), Times.Once); // Verifica que el método CreatePersonaAsync del repositorio se llamó una vez con el modelo de entrada
		}
	}
}
