using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contratos;

namespace VShop.Web.Services;

public class ClienteService : IClienteService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "/api/Clientes/";
    private const string apiEndpointObn = "/api/Clientes/OrderByName/";
    private const string apiEndpointObv = "/api/Clientes/OrderByValor/";
    private const string apiEndpointObd = "/api/Clientes/OrderByDesde/";
    private const string apiEndpointObt = "/api/Clientes/OrderByTiTulo/";
    private readonly JsonSerializerOptions _options;
    private ClienteViewModel clienteVM;
    private IEnumerable<ClienteViewModel> clientesVM;

    public ClienteService(IHttpClientFactory clientFactory)
        

    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClients()
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse  = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clientesVM;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByName()
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpointObn))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clientesVM;
    }

    public async Task<ClienteViewModel> FindClienteByID(int id)
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clienteVM = await JsonSerializer
                    .DeserializeAsync<ClienteViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clienteVM;
    }

    public async Task<ClienteViewModel> CreateCliente(ClienteViewModel clienteVM)
    {
        var client = _clientFactory.CreateClient("ClienteApi");
        StringContent content = new StringContent(JsonSerializer.Serialize(clienteVM),
                                Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clienteVM;

    }

    public async Task<ClienteViewModel> UpdateCliente(ClienteViewModel clienteVM)
    {
        var client = _clientFactory.CreateClient("ClienteApi");
        ClienteViewModel clienteUpdated = new ClienteViewModel();

        using (var response = await client.PutAsJsonAsync(apiEndpoint, clienteVM))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clienteVM = await JsonSerializer
                    .DeserializeAsync<ClienteViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clienteUpdated;
    }

    public async Task<bool> DeleteClienteById(int id)
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

        }
        return false;
        
    }
    public async Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByValor()
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpointObv))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clientesVM;
    }
    public async Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByDesde()
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpointObd))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clientesVM;
    }
    public async Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByTitulo()
    {
        var client = _clientFactory.CreateClient("ClienteApi");

        using (var response = await client.GetAsync(apiEndpointObt))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                clientesVM = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ClienteViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return clientesVM;
    }
} 

