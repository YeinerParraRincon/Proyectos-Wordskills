using API4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public PedidoController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Ordersese>>> TraerOrders()
        {
            var Traer = await _context.Orderseses.ToListAsync();
            return Ok(Traer);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult> TraerOrders(long id)
        {
            var busquedad = await _context.Orderseses.FindAsync(id);

            if(busquedad == null)
            {
                return NotFound();
            }

            return Ok(busquedad);
        }

        [HttpPost("orders")]
        public async Task<ActionResult<Ordersese>> InsertarOrders(Ordersese ord)
        {
            var orders = new Ordersese
            {
               CustomerId = ord.CustomerId,
               PaymentMethod = ord.PaymentMethod,
               Channel = ord.Channel,
               StoreId = ord.StoreId,
               PromotionId = ord.PromotionId,
               DiscountAmount = ord.DiscountAmount,
               Total = ord.Total,
               Status = ord.Status,
               OrderItems = ord.OrderItems,
            };

            _context.Orderseses.Add(orders);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, orders);
        }


        [HttpPut("orders/{id}/complete")]
        public async Task<ActionResult> ActivarComplete(long id)
        {
            var complete = await _context.Orderseses.FindAsync(id);

            if(complete == null)
            {
                return NotFound();
            }

            complete.Status = "complete";
            await _context.SaveChangesAsync();

            return Ok(complete);
        }

        [HttpPut("orders/{id}/cancel")]
        public async Task<ActionResult> CancelarComplete(long id)
        {
            var cancel = await _context.Orderseses.FindAsync(id);

            if(cancel == null)
            {
                return NotFound();
            }

            cancel.Status = "cancel";
            await _context.SaveChangesAsync();

            return Ok(cancel);
        }
    }
}
