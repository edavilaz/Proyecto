using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Custom;
using WebApi.Models;
using WebApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly BilikifoodContext _bilikifoodContext;

        public ServicioController(BilikifoodContext bilikifoodContext)
        {
            _bilikifoodContext = bilikifoodContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _bilikifoodContext.Servicios.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }

    }
}
