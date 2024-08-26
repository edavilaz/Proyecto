using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Custom;
using WebApi.Models;
using WebApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;


namespace WebApi.Controllers
{ 
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly BilikifoodContext _bilikifoodContext;
        private readonly Utilidades _utilidades;

        public AccesoController(BilikifoodContext bilikifood, Utilidades utilidades)
        {
            _bilikifoodContext = bilikifood;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult>Registrarse(UsuarioDTO objeto)
        {
            var modeloUsuario = new Usuario
            {
                Nombre = objeto.Nombre,
                Email = objeto.Email,
                Password = _utilidades.encriptarSHA256(objeto.Password)
            };

            await _bilikifoodContext.Usuarios.AddAsync(modeloUsuario);
            await _bilikifoodContext.SaveChangesAsync();

            if (modeloUsuario.IdUsuario != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
                        
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult>Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _bilikifoodContext.Usuarios
                .Where(u => 
                u.Email == objeto.Email &&
                u.Password == _utilidades.encriptarSHA256(objeto.Password)
                ).FirstOrDefaultAsync();

            if(usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = false, token=""});
            else
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true, token=_utilidades.generarJWT(usuarioEncontrado)});
        }
    }
}
