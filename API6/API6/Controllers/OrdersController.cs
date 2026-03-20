using API6.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

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
        public async Task<ActionResult<Ordersese>> BuscarProductos(long id)
        {
            var buscado = await _context.Orderseses.FindAsync(id);

            if(buscado == null)
            {
                return NotFound();
            }

            return Ok(buscado);
        }


        [HttpPost("orders")]
        public async Task<ActionResult<Ordersese>> InsertarProducto(OrderseseDTO ord)
        {
            var order = new Ordersese
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

            _context.Orderseses.Add(order);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, order);
        }

        [HttpPut("orders/{id}/complete")]
        public async Task<ActionResult<Ordersese>> ActualizarOrderse(long id)
        {
            var order = await _context.Orderseses.FindAsync(id);

            if(order == null)
            {
                return NotFound(); 
            }

            order.Status = "complete";

            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut("orders/{id}/cancel")]
        public async Task<ActionResult<Ordersese>> ActualizarCancel(long id)
        {
            var ords = await _context.Orderseses.FindAsync(id);

            if(ords == null)
            {
                return NotFound();
            }

            ords.Status = "cancel";

            await _context.SaveChangesAsync();
            return Ok(ords);
        }
    }
}
