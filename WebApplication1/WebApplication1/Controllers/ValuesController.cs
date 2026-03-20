using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BelleCroissantLyonnaisContext _context;

        public ValuesController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Producto>>> Traer()
        {
            var traer = await _context.Productos.ToListAsync();

            return Ok(traer);
        }


        [HttpGet("products/{id}")]
        public async Task<ActionResult<Producto>> BuscarProducto(long id)
        {
            var buscar = await _context.Productos.FindAsync(id);

            return Ok(buscar);
        }
    }
}
