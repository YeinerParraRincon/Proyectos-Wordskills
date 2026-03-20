using API4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API4.Controllers
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
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult> BucarProducto(long id) 
        {
            var busqueda = await _context.Productos.FindAsync(id);

            if(busqueda == null)
            {
               return NotFound();
            }

            return Ok(busqueda);
        }

        [HttpPost("products")]
        public async Task<ActionResult<Producto>> InsertarProductos(ProductsDTO dto)
        {
            var producto = new Producto
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Category   =    dto.Category,
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
        public async Task<ActionResult> ActualizarProducto(long id,ProductsDTO dto)
        {
            var existeProducto = await _context.Productos.FindAsync(id);

            if(existeProducto == null)
            {
                return NotFound();
            }

            existeProducto.Name = dto.Name;
            existeProducto.Category = dto.Category;
            existeProducto.Ingredients = dto.Ingredients;
            existeProducto.Price = dto.Price;
            existeProducto.Cost = dto.Cost;
            existeProducto.Seasonal = dto.Seasonal;
            existeProducto.Active = dto.Active;
            existeProducto.Date = dto.Date;
            existeProducto.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(existeProducto);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult> EliminarProducto(long id)
        {
            var EliminacionProductos = await _context.Productos.FindAsync(id);

            if(EliminacionProductos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(EliminacionProductos);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
