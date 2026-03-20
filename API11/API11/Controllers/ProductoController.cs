using API11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private BelleCroissantLyonnaisContext _context;

        public ProductoController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Producto>>> TraerProducto()
        {
            var datos = await _context.Productos.ToListAsync();

            return Ok(datos);
        }
    }
}
