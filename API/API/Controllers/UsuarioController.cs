using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public UsuarioController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListaProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }
        [HttpPost("guardar")]
        public async Task<ActionResult<Producto>> GuardarUsuario(ProductoDTO dto)
        {
            var producto = new Producto
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Category = dto.Category,
                Ingredients = dto.Ingredients,
                Price = dto.Price,
                Cost = dto.Cost,
                Seasonal = dto.Seasonal,
                Active = dto.Active,
                Date = dto.Date,
                Descripcion = dto.Descripcion
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult> ActualizarUsuario(long id, ProductoDTO producto)
        {
            var ProductoActualizado = await _context.Productos.FindAsync(id);

            if (ProductoActualizado == null)
            {
                return NotFound();
            }

            ProductoActualizado.Name = producto.Name;
            ProductoActualizado.Category = producto.Category;
            ProductoActualizado.Ingredients = producto.Ingredients;
            ProductoActualizado.Price = producto.Price;
            ProductoActualizado.Cost = producto.Cost;
            ProductoActualizado.Seasonal = producto.Seasonal;
            ProductoActualizado.Active = producto.Active;
            ProductoActualizado.Date = producto.Date;
            ProductoActualizado.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();

            return Ok(ProductoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<Producto>> EliminarUsuario(long id)
        {
            var ProductoEscojido = await _context.Productos.FindAsync(id);

            if (ProductoEscojido == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(ProductoEscojido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult> BuscarUsuario(long id)
        {
            var busquedaProductos = await _context.Productos.FindAsync(id);

            if (busquedaProductos == null)
            {
                return NotFound();
            }

            return Ok(busquedaProductos);
        }
    }
}
