using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarcasApi.Data;
using MarcasApi.Models;

namespace MarcasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasAutosController : Controller
    {
        private readonly AppDbContext _db;
        public MarcasAutosController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.MarcasAutos.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _db.MarcasAutos.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarcaAuto marca)
        {
            _db.MarcasAutos.Add(marca);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = marca.Id }, marca);
        }
    }
}
