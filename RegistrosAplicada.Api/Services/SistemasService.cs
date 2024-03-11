using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;
using Shared.Models;
using System.Linq.Expressions;

namespace RegistrosAplicada.Api.Services;

public class SistemasService
{
    private readonly Contexto _contexto;

    public SistemasService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Guardar(Sistemas sistema)
    {
        if (!await Existe(sistema.ID))
            return await Insertar(sistema);
        else
            return await Modificar(sistema);
    }

    public async Task<bool> Insertar(Sistemas sistema)
    {
        _contexto.Sistemas.Add(sistema);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Sistemas sistema)
    {
        _contexto.Update(sistema);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(sistema).State = EntityState.Detached;
        return modifico;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Sistemas.AnyAsync(s => s.ID == id);
    }

    public async Task<bool> Eliminar(Sistemas sistema)
    {

		var cantidad = await _contexto.Sistemas
			.Where(p => p.ID == sistema.ID)
			.ExecuteDeleteAsync();
		return cantidad > 0;
	}

    public async Task<Sistemas?> BuscarId(int Id)
    {
        return await _contexto.Sistemas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ID == Id);
    }

    public async Task<Sistemas?> BuscarSistema(string nombre)
    {
        return await _contexto.Sistemas
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Nombre == nombre);
    }

    public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
    {
        return await _contexto.Sistemas.AsNoTracking().Where(criterio).ToListAsync();
    }
}