using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Producto>>> buscar()
        {
            var producrs = await _context.Productos.ToListAsync();

            return Ok(producrs);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Producto>> Buscar(long id)
        {
            var producto = await _context.Productos.FindAsync(id);

            return Ok(producto);
        }

        [HttpPost("products")]
        public async Task<ActionResult<Producto>> Insertar(ProductoDTO dto)
        {
            var insertar = new Producto
            {
                Name = dto.Name,
                Category = dto.Category,
                Ingredients = dto.Ingredients,
                Price = dto.Price,
                Cost = dto.Cost,
                Seasonal = dto.Seasonal,
                Active = dto.Active,
                Date = dto.Date,
                Descripcion = dto.Descripcion,
            };

            _context.Productos.Add(insertar);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, insertar);
        }


        [HttpPut("products/{id}")]
        public async Task<ActionResult<Producto>> Actualizar(long id,ProductoDTO dto)
        {
            var existe = await _context.Productos.FindAsync(id);

            if(existe == null)
            {
                return NotFound();
            }

            existe.Name  = dto.Name;
            existe.Category = dto.Category;
            existe.Ingredients = dto.Ingredients;
            existe.Price = dto.Price;
            existe.Cost = dto.Cost;
            existe.Seasonal = dto.Seasonal;
            existe.Active = dto.Active;
            existe.Date = dto.Date;
            existe.Descripcion = dto.Descripcion;
                
            await _context.SaveChangesAsync();
            return Ok(existe);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult> Eliminar(long id)
        {
            var existe = await _context.Productos.FindAsync(id);

            if(existe == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(existe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
