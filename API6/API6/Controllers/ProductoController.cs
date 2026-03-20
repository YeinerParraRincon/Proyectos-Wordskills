using API6.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public ProductoController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Producto>>> TraerProductos()
        {
            var products = await _context.Productos.ToListAsync();

            return Ok(products);
        }


        [HttpGet("products/{id}")]
        public async Task<ActionResult<Producto>> Buscarproducto(long id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost("products")]
        public async Task<ActionResult<Producto>> InsertarProducto(ProductoDTO dto)
        {
            var producto = new Producto
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

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("products/{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(long id,ProductoDTO dto)
        {
            var actualizar = await _context.Productos.FindAsync(id);

            if(actualizar == null)
            {
                return NotFound();
            }

            actualizar.Name = dto.Name;
            actualizar.Category = dto.Category;
            actualizar.Ingredients = dto.Ingredients;
            actualizar.Price = dto.Price;
            actualizar.Cost = dto.Cost;
            actualizar.Seasonal = dto.Seasonal;
            actualizar.Active = dto.Active;
            actualizar.Date = dto.Date;
            actualizar.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(actualizar);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult<Producto>> EliminarProducto(long id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
