using API6.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerseController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public CostumerseController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Costumerse>>> TraerCostumerse()
        {
            var costu = await _context.Costumerses.ToListAsync();

            return Ok(costu);
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Costumerse>> Buscar(long id)
        {
            var oder = await _context.Costumerses.FindAsync(id);

            if(oder == null)
            {
                return NotFound();
            }

            return Ok(oder);
        }

        [HttpPost("customers")]
        public async Task<ActionResult<Costumerse>> InsertarCostumers(CostumerseDTO cto)
        {
            var costu = new Costumerse
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

            _context.Costumerses.Add(costu);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, costu);
        }

        [HttpPut("customers/{id}")]
        public async Task<ActionResult<Costumerse>> ActualizarCostumerse(long id, CostumerseDTO cto)
        {
            var cos = await _context.Costumerses.FindAsync(id);

            if(cos == null)
            {
                return NotFound();
            }

            cos.FirstName = cto.FirstName;
            cos.LastName = cto.LastName;
            cos.Age = cto.Age;
            cos.Gender = cto.Gender;
            cos.PostalCode = cto.PostalCode;
            cos.Email = cto.Email;
            cos.PhoneNumber = cto.PhoneNumber;
            cos.MembershipStatus = cto.MembershipStatus;
            cos.JoinDate = cto.JoinDate;
            cos.LastPurchaseDate  = cto.LastPurchaseDate;
            cos.TotalSpending = cto.TotalSpending;
            cos.AverageOrderValue = cto.AverageOrderValue;
            cos.Frequency = cto.Frequency;
            cos.PreferredCategory = cto.PreferredCategory;
            cos.Churned = cto.Churned;

            await _context.SaveChangesAsync();
            return Ok(cos);
        }

    }
}
