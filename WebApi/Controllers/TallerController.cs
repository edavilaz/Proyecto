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
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly BilikifoodContext _bilikifoodContext;
        public TallerController(BilikifoodContext bilikifoodContext)
        {
            _bilikifoodContext = bilikifoodContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult>Lista()
        {
            var lista = await _bilikifoodContext.Tallers.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new {value = lista});
        }
    }
}
