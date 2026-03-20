using API4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API4.Controllers
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
        public async Task<ActionResult<IEnumerable<Costumerse>>> TraerCustomers()
        {
            var costumer = await _context.Costumerses.ToListAsync();
            return Ok(costumer);
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult> BuscarClientes(long id)
        {
            var exitesClientes = await _context.Costumerses.FindAsync(id);

            if(exitesClientes == null)
            {
                return NotFound();
            }

            return Ok(exitesClientes);
        }

        [HttpPost("customers/{id}")]
        public async Task<ActionResult<Costumerse>> InsertarCostumerse(long id,Costumerse cst)
        {
            var clientes = new Costumerse
            {
                FirstName = cst.FirstName,
                LastName = cst.LastName,
                Age = cst.Age,
                Gender = cst.Gender,
                PostalCode = cst.PostalCode,
                Email = cst.Email,
                PhoneNumber = cst.PhoneNumber,
                MembershipStatus = cst.MembershipStatus,
                JoinDate = cst.JoinDate,
                LastPurchaseDate = cst.LastPurchaseDate,
                TotalSpending = cst.TotalSpending,
                AverageOrderValue = cst.AverageOrderValue,
                Frequency = cst.Frequency,
                PreferredCategory = cst.PreferredCategory,
                Churned = cst.Churned,
            };

            _context.Costumerses.Add(clientes);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, clientes);
        }

        [HttpPut("customers/{id}")]
        public async Task<ActionResult<Costumerse>> ActualizarCostumers(long id,Costumerse cst)
        {
            var Actualizar = await _context.Costumerses.FindAsync(id);

            if(Actualizar == null)
            {
                return NotFound();
            }

            Actualizar.FirstName = cst.FirstName;
            Actualizar.LastName = cst.LastName;
            Actualizar.Age = cst.Age;
            Actualizar.Gender = cst.Gender;
            Actualizar.PostalCode = cst.PostalCode;
            Actualizar.Email = cst.Email;
            Actualizar.PhoneNumber = cst.PhoneNumber;
            Actualizar.MembershipStatus = cst.MembershipStatus;
            Actualizar.JoinDate = cst.JoinDate;
            Actualizar.LastPurchaseDate = cst.LastPurchaseDate;
            Actualizar.TotalSpending = cst.TotalSpending;
            Actualizar.AverageOrderValue = cst.AverageOrderValue;
            Actualizar.Frequency = cst.Frequency;
            Actualizar.PreferredCategory = cst.PreferredCategory;
            Actualizar.Churned = cst.Churned;

            await _context.SaveChangesAsync();
            return Ok(Actualizar);
        }
    }
}
