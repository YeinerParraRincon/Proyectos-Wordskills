using API7.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API7.Controllers
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
        public async Task<ActionResult<IEnumerable<Producto>>> TrearDatos()
        {
            var traer = await _context.Productos.ToListAsync();

            return Ok(traer);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Producto>> BuscarProducto(long id)
        {
            var busqueda = await _context.Productos.FindAsync(id);

            return Ok(busqueda);
        }

        [HttpPost("products")]
        public async Task<ActionResult<Producto>> InsertarProducto(ProductoDTO dto)
        {
            var insertado = new Producto
            {
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

            _context.Productos.Add(insertado);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, insertado);
        }

        [HttpPut("products/{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(long id, ProductoDTO dto)
        {
            var exites = await _context.Productos.FindAsync(id);

            if (exites == null)
            {
                return NotFound();
            }

            exites.Name = dto.Name;
            exites.Category = dto.Category;
            exites.Ingredients = dto.Ingredients;
            exites.Price = dto.Price;
            exites.Cost = dto.Cost;
            exites.Seasonal = dto.Seasonal;
            exites.Active = dto.Active;
            exites.Date = dto.Date;
            exites.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();
            return Ok(exites);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult<Producto>> EliminarProducto(long id)
        {
            var eliminar = await _context.Productos.FindAsync(id);

            if(eliminar == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(eliminar);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
