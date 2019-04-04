using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIS_API.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GIS_API.Controllers
{
    [Microsoft.AspNetCore.Mvc.RouteAttribute("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GISController : ControllerBase
    {
        private readonly GISContext _context;

        public GISController(GISContext context)
        {
            _context = context;

            if (_context.GISItems.Count() == 0)
            {
                // Create a new GISItem if collection is empty,
                // which means you can't delete all GISItems.
                _context.GISItems.Add(new GISItem { Category = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/GIS
        [Microsoft.AspNetCore.Mvc.HttpGetAttribute]
        public async Task<ActionResult<IEnumerable<GISItem>>> GetGISItems()
        {
            return await _context.GISItems.ToListAsync();
        }

        // GET: api/GIS/5
        [Microsoft.AspNetCore.Mvc.HttpGetAttribute("{id}")]
        public async Task<ActionResult<GISItem>> GetGISItem(long id)
        {
            var GISItem = await _context.GISItems.FindAsync(id);

            if (GISItem == null)
            {
                return NotFound();
            }

            return GISItem;
        }
        // POST: api/GIS
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<ActionResult<GISItem>> PostGISItem(GISItem item)
        {
            _context.GISItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGISItem), new { id = item.Id }, item);
        }
    }
}