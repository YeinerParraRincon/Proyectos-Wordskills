using API3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public ProductosController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }
        [HttpGet("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>> VerProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Producto>> GuardarProductps(ProductoDTO dto)
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
                Date =  dto.Date,
                Descripcion = dto.Descripcion,
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult> Actualizar(long id,ProductoDTO producto)
        {
            var actualizarProductos = await _context.Productos.FindAsync(id);

            if(actualizarProductos == null)
            {
                return NotFound();
            }

            actualizarProductos.Name = producto.Name;
            actualizarProductos.Category = producto.Category;
            actualizarProductos.Ingredients = producto.Ingredients;
            actualizarProductos.Price = producto.Price;
            actualizarProductos.Cost = producto.Cost;
            actualizarProductos.Seasonal = producto.Seasonal;
            actualizarProductos.Active = producto.Active;
            actualizarProductos.Date = producto.Date;
            actualizarProductos.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(actualizarProductos);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarProducto(long id)
        {
            var eliminarProducto = await _context.Productos.FindAsync(id);

            if(eliminarProducto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(eliminarProducto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult> Busqueda(long id)
        {
            var busquedas = await _context.Productos.FindAsync(id);

            if(busquedas == null)
            {
                return NotFound();
            }

            return Ok(busquedas);
        }
    }
}
