using Microsoft.EntityFrameworkCore;
using Shared.Models;
namespace RegistrosAplicada.Api.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }
		public DbSet<Prioridades> Prioridades { get; set; }
		public DbSet<Clientes> Clientes { get; set; }
		public DbSet<Tickets> Tickets { get; set; }
		public DbSet<Sistemas> Sistemas { get; set; }
		
	}
}
