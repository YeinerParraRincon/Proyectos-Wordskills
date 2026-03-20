using Apis2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apis2.Controllers
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
        public async Task<ActionResult<Producto>> GuardarUsuario(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                ProductId = productoDTO.ProductId,
                Name = productoDTO.Name,
                Category = productoDTO.Category,
                Ingredients = productoDTO.Ingredients,
                Price = productoDTO.Price,
                Cost = productoDTO.Cost,
                Seasonal = productoDTO.Seasonal,
                Active = productoDTO.Active,
                Date = productoDTO.Date,
                Descripcion = productoDTO.Descripcion,
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult> ActualizarUsuario(long id,ProductoDTO producto)
        {
            var productoActualizado = await _context.Productos.FindAsync(id);

            if(productoActualizado == null)
            {
                return NotFound();
            }

            productoActualizado.Name = producto.Name;
            productoActualizado.Category = producto.Category;
            productoActualizado.Ingredients = producto.Ingredients;
            productoActualizado.Price = producto.Price;
            productoActualizado.Cost = producto.Cost;
            productoActualizado.Seasonal = producto.Seasonal;
            productoActualizado.Active = producto.Active;
            productoActualizado.Date = producto.Date;
            productoActualizado.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();

            return Ok(productoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarUsuario(long id)
        {
            var productoEscojido = await _context.Productos.FindAsync(id);

            if(productoEscojido == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productoEscojido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("busqueda/{id}")]
        public async Task<ActionResult> BusquedaUsuario(long id)
        {
            var BusquedaProductos = await _context.Productos.FindAsync(id);

            if(BusquedaProductos == null)
            {
                return NotFound();
            }

            return Ok(BusquedaProductos);
        }
    }
}
