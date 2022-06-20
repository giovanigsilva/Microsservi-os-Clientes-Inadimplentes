using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.Services;
using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitulosController : ControllerBase
    {
        private readonly ITituloService _titulosService;

        public TitulosController(ITituloService titulosService)
        {
            _titulosService = titulosService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TituloDTO>>> Get()
        {
            var titulosDto = await  _titulosService.GetTitulos();
            if (titulosDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(titulosDto);

        }
        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<TituloDTO>>> GetTitulosClientes()
        {
            var titulosDto = await _titulosService.GetTitulosClientes();
            if (titulosDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(titulosDto);

        }


        [HttpGet("{id:int}",  Name = "GetTitulo")]
        public async Task<ActionResult<TituloDTO>> Get(int id)
        {
            var titulosDto = await _titulosService.GetTituloByID(id);
            if (titulosDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(titulosDto);

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TituloDTO tituloDto)
        {
            if (tituloDto == null)
                return BadRequest("Dados invalidos");

            await _titulosService.AddTitulo(tituloDto);

            return new CreatedAtRouteResult("GetTitulo", new { id = tituloDto.TituloId }, tituloDto);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TituloDTO tituloDto)
        {
            if (id  != tituloDto.TituloId)
                return BadRequest("Dados invalidos");
            if (tituloDto == null)
                return BadRequest("Dados invalidos nulo");

            await _titulosService.UpdateTitulo(tituloDto);

            return Ok(tituloDto);

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tituloDto = await _titulosService.GetTituloByID(id);
         
            if (tituloDto == null)
                return BadRequest("Dados invalidos nulo");

            await _titulosService.RemoveTitulo(id);

            return Ok(tituloDto);

        }
    }
}
