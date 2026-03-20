using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UsuariosController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = new List<object>();

            
            string connectionString = _config.GetConnectionString("Default");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Email FROM Users", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new
                    {
                        Id = reader["Id"],
                        Nombre = reader["Nombre"],
                        Email = reader["Email"]
                    });
                }
            }

            return Ok(usuarios);
        }
    }
}
