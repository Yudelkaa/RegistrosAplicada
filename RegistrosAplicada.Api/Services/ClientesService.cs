using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;
using System.Linq.Expressions;


namespace RegistrosAplicada.Api.Services
{
	public class ClientesService
    {
        private readonly Contexto _contexto;

        public ClientesService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!Validar(cliente))
            {
                if (!await Existe(cliente.ClientesId))
                    return await Insertar(cliente);
                else
                    return await Modificar(cliente);
            }
            return false;
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            _contexto.Update(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

		public bool Validar(Clientes cliente)
		{
			var encontrado = (_contexto.Clientes.Any(p => p.Nombres!.ToLower()
		   == cliente.Nombres!.ToLower()));

			return encontrado;
		}

		public async Task<bool> Eliminar(Clientes cliente)
        {
            var cantidad = await _contexto.Clientes
                .Where(p => p.ClientesId == cliente.ClientesId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Clientes?> Buscar(int clientesId)
        {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ClientesId == clientesId);
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            return await _contexto.Clientes.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Existe(int clientesId)
        {
            return await _contexto.Clientes
                .AnyAsync(p => p.ClientesId == clientesId);

        }

        public List<Clientes> GetClientes()
        {
            var clientes = _contexto.Clientes.ToList();
            return clientes;
        }

		public async Task<Clientes?> FindAsync(int id)
		{
			return await _contexto.Clientes.FindAsync(id);
		}
    }
}
