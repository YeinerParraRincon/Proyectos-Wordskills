using API7.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        private BelleCroissantLyonnaisContext _context;

        public CostumersController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("costumers")]
        public async Task<ActionResult<IEnumerable<Costumerse>>> Costumers()
        {
            var costumers = await _context.Costumerses.ToListAsync();

            return Ok(costumers);
        }

        [HttpGet("costumers/{id}")]
        public async Task<ActionResult<Costumerse>> CostumersID (long id)
        {
            var costumers = await _context.Costumerses.FindAsync(id);

            return Ok(costumers);
        }
        [HttpPost("costumers")]
        public async Task<ActionResult<Costumerse>> Insertar(CostumersDTO cto)
        {
            var nuevo = new Costumerse
            {
                FirstName = cto.FirstName,
                LastName = cto.LastName,
                Age = cto.Age,
                Gender = cto.Gender,
                PostalCode = cto.PostalCode,
                Email = cto.Email,
                PhoneNumber = cto.PhoneNumber,
                MembershipStatus = cto.MembershipStatus,
                JoinDate = cto.JoinDate,
                LastPurchaseDate = cto.LastPurchaseDate,
                TotalSpending = cto.TotalSpending,
                AverageOrderValue = cto.AverageOrderValue,
                Frequency = cto.Frequency,
                PreferredCategory = cto.PreferredCategory,
                Churned = cto.Churned
            };

            _context.Costumerses.Add(nuevo);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, nuevo);
        }

        [HttpPut("costumers/{id}")]
        public async Task<ActionResult<Costumerse>> Actualizar(long id,CostumersDTO cts)
        {
            var actualizado = await _context.Costumerses.FindAsync(id);

            if(actualizado == null)
            {
                return NotFound();
            }

            actualizado.FirstName = cts.FirstName;
            actualizado.LastName = cts.LastName;
            actualizado.Age = cts.Age;
            actualizado.Gender = cts.Gender;
            actualizado.PostalCode = cts.PostalCode;
            actualizado.Email = cts.Email;
            actualizado.PhoneNumber = cts.PhoneNumber;
            actualizado.MembershipStatus = cts.MembershipStatus;
            actualizado.JoinDate = cts.JoinDate;
            actualizado.LastPurchaseDate = cts.LastPurchaseDate;
            actualizado.TotalSpending = cts.TotalSpending;
            actualizado.AverageOrderValue = cts.AverageOrderValue;
            actualizado.Frequency = cts.Frequency;
            actualizado.PreferredCategory = cts.PreferredCategory;
            actualizado.Churned = cts.Churned;

            await _context.SaveChangesAsync();
            return Ok(actualizado);
        }


    }
}
