using API5.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API5.Controllers
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

        public async Task<ActionResult<Producto>> BuscarProducto(long id)
        {
            var existenciaBuscado = await _context.Productos.FindAsync(id);

            if(existenciaBuscado == null)
            {
                return NotFound();
            }

            return Ok(existenciaBuscado);
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
        public async Task<ActionResult<ProductoDTO>> ActualizarProductos(long id,ProductoDTO dto)
        {
            var existeActualizar = await _context.Productos.FindAsync(id);

            if( existeActualizar == null)
            {
                return NotFound();
            }

            existeActualizar.Name = dto.Name;
            existeActualizar.Category = dto.Category;
            existeActualizar.Ingredients = dto.Ingredients;
            existeActualizar.Price = dto.Price;
            existeActualizar.Cost = dto.Cost;
            existeActualizar.Seasonal = dto.Seasonal;
            existeActualizar.Active = dto.Active;
            existeActualizar.Date = dto.Date;
            existeActualizar.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(existeActualizar);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult<Producto>> EliminarProducto(long id)
        {
            var existeEliminar = await _context.Productos.FindAsync(id);

            if(existeEliminar == null)
            {
                return NotFound();
            }

            _context.Remove(existeEliminar);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
