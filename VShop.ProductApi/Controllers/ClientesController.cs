using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private object ClientesDto;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
           
            ClientesDto = await _clienteService.GetClientes();


            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpGet("OrderByName")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesOrderByName()
        {

            ClientesDto = await _clienteService.GetClientesOrderByName();


            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpGet("OrderByValor")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesOrderByValor()
        {

            ClientesDto = await _clienteService.GetClientesOrderByValor();


            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpGet("OrderByDesde")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesOrderByDesde()
        {

            ClientesDto = await _clienteService.GetClientesOrderByDesde();


            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpGet("OrderByTitulo")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesOrderByTitulo()
        {

            ClientesDto = await _clienteService.GetClientesOrderByTitulo();


            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpGet("{id:int}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var ClientesDto = await _clienteService.GetClienteByID(id);
            if (ClientesDto == null)
                return NotFound("Titulo nao encontrado");
            return Ok(ClientesDto);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Dados invalidos");

            await _clienteService.AddCliente(clienteDto);

            return new CreatedAtRouteResult("GetCliente", new { id = clienteDto.Id }, clienteDto);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.Id)
                return BadRequest("Dados invalidos");
            if (clienteDto == null)
                return BadRequest("Dados invalidos nulo");

            await _clienteService.UpdateCliente(clienteDto);

            return Ok(clienteDto);

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteDto = await _clienteService.GetClienteByID(id);

            if (clienteDto == null)
                return BadRequest("Dados invalidos nulo");

            await _clienteService.RemoveCliente(id);

            return Ok(clienteDto);

        }
    }
}
