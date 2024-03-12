using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;
using Shared.Models;

namespace RegistrosAplicada.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SistemasController : ControllerBase
	{
		private readonly Contexto _context;

		public SistemasController(Contexto context)
		{
			_context = context;
		}

		// GET: api/Sistemas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Sistemas>>> GetSistemas()
		{
			return await _context.Sistemas.ToListAsync();
		}

		// GET: api/Sistemas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Sistemas>> GetSistemas(int id)
		{
			if (_context.Sistemas == null)
			{
				return NotFound();
			}

			var sistemas = await _context.Sistemas.Where(s => s.ID == id).FirstOrDefaultAsync();

			if (sistemas == null)
			{
				return NotFound();
			}

			return sistemas;
		}

		// PUT: api/Sistemas/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutSistemas(int id, Sistemas sistemas)
		{
			if (id != sistemas.ID)
			{
				return BadRequest();
			}

			_context.Entry(sistemas).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SistemasExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Sistemas
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Sistemas>> PostSistemas(Sistemas sistemas)
		{
			if (!SistemasExists(sistemas.ID))
				_context.Sistemas.Add(sistemas);
			else
				_context.Sistemas.Update(sistemas);

			await _context.SaveChangesAsync();

			return Ok(sistemas);
		}

		// DELETE: api/Sistemas/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSistemas(int id)
		{
			var sistemas = await _context.Sistemas.FindAsync(id);
			if (sistemas == null)
			{
				return NotFound();
			}

			_context.Sistemas.Remove(sistemas);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool SistemasExists(int id)
		{
			return _context.Sistemas.Any(e => e.ID == id);
		}
	}
}
