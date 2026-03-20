using API5.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        private readonly BelleCroissantLyonnaisContext _context;

        public CostumersController(BelleCroissantLyonnaisContext context)
        {
            _context = context;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<List<Costumerse>>>> TraerCustomerse()
        {
            var clientes = await _context.Costumerses.ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Costumerse>> BuscarCustomerse(long id)
        {
            var busqueda = await _context.Costumerses.FindAsync(id);

            if(busqueda == null)
            {
                return NotFound();
            }

            return Ok(busqueda);
        }

        [HttpPost("customers")]
        public async Task<ActionResult<Costumerse>> InsertarCustomerse(CostumerseDTO ct)
        {
            var costu = new Costumerse
            {
                FirstName = ct.FirstName,
                LastName = ct.LastName,
                Age = ct.Age,
                Gender = ct.Gender,
                PostalCode = ct.PostalCode,
                Email = ct.Email,
                PhoneNumber = ct.PhoneNumber,
                MembershipStatus = ct.MembershipStatus,
                JoinDate = ct.JoinDate,
                LastPurchaseDate = ct.LastPurchaseDate,
                TotalSpending = ct.TotalSpending,
                AverageOrderValue = ct.AverageOrderValue,
                Frequency = ct.Frequency,
                PreferredCategory = ct.PreferredCategory,
                Churned = ct.Churned,
            };

            _context.Costumerses.Add(costu);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, costu);
        }

        [HttpPut("customers/{id}")]
        public async Task<ActionResult<Costumerse>> ActualizarCosutomerse(long id,CostumerseDTO ct)
        {
            var existe = await _context.Costumerses.FindAsync(id);

            if(existe == null)
            {
                return NotFound();
            }

            existe.FirstName = ct.FirstName;
            existe.LastName = ct.LastName;
            existe.Age = ct.Age;
            existe.Gender = ct.Gender;
            existe.PostalCode = ct.PostalCode;
            existe.Email = ct.Email;
            existe.PhoneNumber = ct.PhoneNumber;
            existe.MembershipStatus = ct.MembershipStatus;
            existe.JoinDate = ct.JoinDate;
            existe.LastPurchaseDate = ct.LastPurchaseDate;
            existe.TotalSpending = ct.TotalSpending;
            existe.AverageOrderValue = ct.AverageOrderValue;
            existe.Frequency = ct.Frequency;
            existe.PreferredCategory = ct.PreferredCategory;
            existe.Churned = ct.Churned;

            await _context.SaveChangesAsync();
            return Ok(existe);
        }
    }
}
