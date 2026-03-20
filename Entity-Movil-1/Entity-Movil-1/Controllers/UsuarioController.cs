using Entity_Movil_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Movil_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private Sesion4Context _context;


        public UsuarioController(Sesion4Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> TraerUsuarios()
        {
            var usuarios = await _context.Users.ToListAsync();

            return Ok(usuarios);    
        }
    }
}
