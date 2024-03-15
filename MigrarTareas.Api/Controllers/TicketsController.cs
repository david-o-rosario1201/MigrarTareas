using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using MigrarTareas.Api.DAL;

namespace MigrarTareas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly Contexto _context;

        public TicketsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            return await _context.Tickets.Include(t => t.TicketsDetalle).ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets>> GetTickets(int id)
        {
            if(_context.Tickets ==  null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(d => d.TicketsDetalle)
                .Where(t => t.TicketId == id)
                .FirstOrDefaultAsync();

            if(tickets == null)
            {
                return NotFound();
            }

            return tickets;
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets>> PostTickets(Tickets tickets)
        {
            if (TicketsExists(tickets.TicketId))
                _context.Tickets.Add(tickets);
            else
                _context.Tickets.Update(tickets);

            await _context.SaveChangesAsync();

            return Ok(tickets);
        }

		// PUT: api/Tickets/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTickets(int id, Tickets tickets)
		{
			if (TicketsExists(id))
				_context.Tickets.Update(tickets);

			await _context.SaveChangesAsync();

			return Ok(tickets);
		}

		// DELETE: api/Tickets/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

		[HttpDelete("{ticketId}/Detalle/{detalleId}")]
		public async Task<IActionResult> DeleteTicketsDetalle(int ticketId, int detalleId)
		{
            var tickets = await _context.Tickets
                .Include(d => d.TicketsDetalle)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

			if (tickets == null)
			{
				return NotFound();
			}

            var detalles = tickets.TicketsDetalle.Where(d => d.Id == detalleId).FirstOrDefault();

            if(detalles == null)
            {
                return NotFound();
            }

			tickets.TicketsDetalle.Remove(detalles);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
