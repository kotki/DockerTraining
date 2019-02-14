using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuesController(/*IHttpClientFactory httpClientFactory*/)
        {
            //_httpClientFactory = httpClientFactory;
            //_httpClientFactory = new HttpClientFactory();
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            //var client = HttpClientFactory.Create()

            return string.Empty;
        }
    }
}
