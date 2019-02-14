using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;
        //private readonly DockerTestContext _context;
        private readonly IHttpClientFactory _clientFactory;

        private readonly string _redisKey = "SomeRandomRedisKey";

        public ValuesController(IConfiguration config,
                                //DockerTestContext context,
                                IHttpClientFactory clientFactory)
        {
            _config = config;
            //_context = context;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            string result = null;

            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
                "http://localhost:51442/api/values");

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

            //var rcString = _config.GetValue<string>("REDIS_URL");
            ////var rcString = "localhost:6379";

            //string result = string.Empty;

            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(rcString);
            //IDatabase db = redis.GetDatabase();

            //var cache = db.StringGet(_redisKey);

            //if (cache.IsNullOrEmpty)
            //{
            //    //change to aggregate
            //    var dbStrings = _context.DockerTestTable.Select(dtt => dtt.ToString());
            //    foreach(var s in dbStrings)
            //    {
            //        result += s;
            //    }

            //    db.StringSet(_redisKey, result);
            //}
            //else
            //{
            //    result = cache.ToString() + " from REDIS!";;
            //}

            //return result;
        }
    }
}
