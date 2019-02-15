using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;

        public ValuesController(IConfiguration config,
                                IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get(string url)
        {
            string result = null;

            var client = _clientFactory.CreateClient();
            string web1_url = null;
            if(string.IsNullOrEmpty(url)){
                web1_url = _config.GetValue<string>("WEB1_URL");
                web1_url += "/api/values";
            }
            else{
                web1_url = url;
            }
            
            var request = new HttpRequestMessage(HttpMethod.Get,
                web1_url);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                result = "Something vent wrong with response!";
            }

            return result;
        }
    }
}
