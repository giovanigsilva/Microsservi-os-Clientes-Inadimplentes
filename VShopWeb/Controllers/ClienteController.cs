using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Services.Contratos;

namespace VShop.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ITituloService _tituloService;
        

        public ClienteController(IClienteService clienteService, 
            ITituloService tituloService)
        {
            _clienteService = clienteService;
            _tituloService = tituloService;
        }

        [HttpGet("{tipo}")]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Index(string tipo)
        {
            var result = new object();

            switch (tipo)
            {
                 case "ClienteObn": 
                    result = await _clienteService.GetAllClientsOrderByName();
                    break;
                case "ClienteObv": 
                    result = await _clienteService.GetAllClientsOrderByValor();
                    break;
                case "ClienteObd":
                    result = await _clienteService.GetAllClientsOrderByDesde();
                    break;
                case "ClienteObt":
                    result = await _clienteService.GetAllClientsOrderByTitulo();
                    break;
                case "Cliente":
                    result = await _clienteService.GetAllClients();
                    break;
                default: 
                    break;
            }
            
                
            
              
            

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }    

        [HttpGet]
        public async Task<ActionResult> CreateCliente()
        {
            ViewBag.TituloId = new SelectList(await _tituloService.GetAllTitulos(), "TituloId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _clienteService.CreateCliente(clienteVM);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.TituloId = new SelectList(await _tituloService.GetAllTitulos(), "TituloId", "Name");
            }
            return View(clienteVM);
        }
    }
}

