using Microsoft.EntityFrameworkCore;
using TestingPrueba.Models;

namespace TestingPrueba.Context
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options) { }
		
		public DbSet<Persona> Persona { get; set; }
		public DbSet<Domicilio> Domicilio { get; set; }
		public DbSet<InstitucionEducativa> InstitucionEducativa { get; set; }
	}
}
