using Entity_Movil_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Movil_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private Sessao2Context _context;

        public UsuarioController(Sessao2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> TraerUsuarios()
        {
            var usuario = await _context.Usuarios.ToListAsync();

            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> TraerUsuarioId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/Bloquear")]
        public  async Task<ActionResult<Usuario>> BloquearUsuario(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if(usuarios == null)
            {
                return NotFound();
            }

            usuarios.Bloqueado = true;
            await _context.SaveChangesAsync();
            return Ok(usuarios);
        }

        [HttpPut("{id}/Desbloquear")]
        public async Task<ActionResult<Usuario>> DesactivarUsuario(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if(usuarios == null)
            {
                return NotFound();
            }

            usuarios.Bloqueado = false;
            await _context.SaveChangesAsync();
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> insertarUsuario(Usuario dto)
        {
            var nuevoUsuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Apelido = dto.Apelido,
                Senha = dto.Senha,
                Perfil = dto.Perfil,
                Bloqueado = dto.Bloqueado
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, nuevoUsuario);
        }

    }
}
