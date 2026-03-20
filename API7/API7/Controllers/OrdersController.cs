using API7.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private BelleCroissantLyonnaisContext _context;

        public OrdersController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }


        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Ordersese>>> TraerOrders()
        {
            var orders = await _context.Orderseses.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<Ordersese>> BuscarOrders(long id)
        {
            var busquedad = await _context.Orderseses.FindAsync(id);

            return Ok(busquedad);
        }

        [HttpPost("orders")]
        public async Task<ActionResult<Ordersese>> InsertarOrderses(OrdersDTO ord)
        {
            var insertar = new Ordersese
            {
                CustomerId = ord.CustomerId,
                PaymentMethod = ord.PaymentMethod,
                Channel = ord.Channel,
                StoreId =ord.StoreId,
                PromotionId =ord.PromotionId,
                DiscountAmount =ord.DiscountAmount,
                Total =ord.Total,
                Status =ord.Status,
                OrderItems =ord.OrderItems
            };

            _context.Orderseses.Add(insertar);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, insertar);
        }

        [HttpPut("orders/{id}/complete")]
        public async Task<ActionResult<Ordersese>> ActivarComplete(long id)
        {
            var existe = await _context.Orderseses.FindAsync(id);

            if(existe == null)
            {
                return NotFound();
            }

            existe.Status = "Complete";
            await _context.SaveChangesAsync();
            return Ok(existe);
        }

        [HttpPut("orders/{id}/cancel")]
        public async Task<ActionResult<Ordersese>> ActivarCancelar(long id)
        {
            var existe = await _context.Orderseses.FindAsync(id);

            if(existe == null)
            {
                return NotFound();
            }

            existe.Status = "Cancel";
            await _context.SaveChangesAsync();
            return Ok(existe);
        }
    }
}
