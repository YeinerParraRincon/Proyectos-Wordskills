using API5.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Net.NetworkInformation;

namespace API5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderseseController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public OrderseseController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Ordersese>>> TraerOrderse()
        {
            var order = await _context.Orderseses.ToListAsync();

            return Ok(order);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<Ordersese>> BuscarOrderse(long id)
        {
            var existeBusqueda = await _context.Orderseses.FindAsync(id);

            if(existeBusqueda == null)
            {
                return NotFound();
            }

            return Ok(existeBusqueda);
        }

        [HttpPost("orders")]
        public async Task<ActionResult<Ordersese>> InsertarOrderse(OrderseseDTO ord)
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
        public async Task<ActionResult> ActivarComplte(long id)
        {
            var exieteActivacion = await _context.Orderseses.FindAsync(id);

            if(exieteActivacion == null)
            {
                return NotFound();
            }

            exieteActivacion.Status = "complete";

            return Ok(exieteActivacion);
        }

        [HttpPut("orders/{id}/cancel")]
        public async Task<ActionResult> DesactivarCancelar(long id)
        {
            var existeCancelado = await _context.Orderseses.FindAsync(id);

            if(existeCancelado == null)
            {
                return NotFound();
            }
            existeCancelado.Status = "cancel";

            return Ok(existeCancelado);
        }
    }
}
