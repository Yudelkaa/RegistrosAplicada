using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace RegistrosAplicada.Api.Services
{
	public class TicketsService
	{
		private readonly Contexto _contexto;
		public TicketsService(Contexto contexto)
		{
			_contexto = contexto;
		}

		public async Task<bool> Guardar(Tickets ticket)
		{

            if (ticket.TicketId == 0)
                return await Insertar(ticket);
            else
                return await Modificar(ticket);
        }

		private async Task<bool> Insertar(Tickets ticket)
		{
			_contexto.Tickets.Add(ticket);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Tickets ticket)
		{
            if (ticket.TicketId != 0)
            {
                _contexto.Update(ticket);
                var modifico = await _contexto.SaveChangesAsync() > 0;
                return modifico;
            }
            else
            {

                return false;
            }
        }

		public bool Validar(Tickets ticket)
		{
			var encontrado = _contexto.Tickets.Any(p => p.Descripcion!.ToLower()
		   == ticket.Descripcion!.ToLower());

			return encontrado;
		}

		public async Task<bool> Eliminar(Tickets ticket)
		{
			var cantidad = await _contexto.Tickets
				.Where(p => p.TicketId == ticket.TicketId)
				.ExecuteDeleteAsync();

			return cantidad > 0;
		}
       
        public async Task<Tickets?> Buscar(int ticketId)
		{
			return await _contexto.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.TicketId == ticketId);
		}

		public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
		{
			return await _contexto.Tickets.AsNoTracking().Where(criterio).ToListAsync();
		}

		public async Task<bool> Existe(int ticketId)
		{
			return await _contexto.Tickets
				.AnyAsync(p => p.TicketId == ticketId);

		}

		public List<Tickets> GetTickets()
		{ 
			var tickets = _contexto.Tickets.ToList();
			return tickets;
		}

		public async Task<Tickets?> FindAsync(int id)
		{
			return await _contexto.Tickets.FindAsync(id);
		}
	}
}

