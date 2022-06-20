using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contratos;

namespace VShop.Web.Services
{
    public class TituloService : ITituloService
    {
        private readonly IHttpClientFactory _clientfactory;
        private readonly JsonSerializerOptions _options;
        private const string apiEndPoint = "/api/titulos/";

        public TituloService(IHttpClientFactory clientfactory)
        {
            _clientfactory = clientfactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; ;
        }

        public async Task<IEnumerable<TituloViewModel>> GetAllTitulos()
        {
            var client = _clientfactory.CreateClient("ClienteApi");

            IEnumerable<TituloViewModel> titulos;

            using (var response = await client.GetAsync(apiEndPoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    titulos = await JsonSerializer
                        .DeserializeAsync<IEnumerable<TituloViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return titulos;
            }
        }
    }
}
