using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace RegistrosAplicada.Api.Services
{
	public class PrioridadesService
    {
        private readonly Contexto _contexto;

        public PrioridadesService(Contexto contexto)
        {
            _contexto = contexto;
        }

		public async Task<bool> Guardar(Prioridades prioridad)
		{
			if (prioridad.PrioridadesId == 0)
				return await Insertar(prioridad);
			else
				return await Modificar(prioridad);
		}

		private async Task<bool> Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }


		public async Task<bool> Modificar(Prioridades prioridad)
		{
			
			if (prioridad.PrioridadesId != 0)
			{
				_contexto.Update(prioridad);
				var modifico = await _contexto.SaveChangesAsync() > 0;
				return modifico;
			}
			else
			{
				
				return false;
			}
		}
		public Task<bool> Validar(Prioridades prioridad)
        {
            var encontrado = (_contexto.Prioridades.Any(p => p.Descripcion!.ToLower()
           == prioridad.Descripcion!.ToLower()));

            return Task.FromResult(encontrado);
        }

        public async Task<bool> Eliminar(Prioridades prioridad)
        {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadesId == prioridad.PrioridadesId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<Prioridades?> Buscar(int prioridadesId)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadesId == prioridadesId);
        }


        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _contexto.Prioridades.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Existe(int prioridadesId)
        {
            return await _contexto.Prioridades
                .AnyAsync(p => p.PrioridadesId == prioridadesId);
        }

        public List<Prioridades> GetPrioridades()
        {
            var prioridad = _contexto.Prioridades.ToList();
            return prioridad;
        }
        public async Task<Prioridades?> FindAsync(int id)
        {
            return await _contexto.Prioridades.FindAsync(id);
        }
    }
}
