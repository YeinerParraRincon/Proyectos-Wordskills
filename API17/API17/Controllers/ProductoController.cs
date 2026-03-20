using API17.DTO;
using API17.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace API17.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> traerProductos()
        {
            var product = await _context.Productos.ToListAsync();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> InsertarProdcuto(ProductoDTO dto)
        {
            var nuevo = new Producto
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

            _context.Productos.Add(nuevo);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, nuevo);
        }
    }
}
