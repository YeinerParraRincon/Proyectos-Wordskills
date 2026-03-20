using Entity_Movil_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Movil_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelesaoController : ControllerBase
    {
        private readonly Sessao2Context _context;

        public SelesaoController(Sessao2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Selecao>>> traerSeleciones()
        {
            var selesao = await _context.Selecaos.ToListAsync();

            return Ok(selesao);
        }
    }
}
