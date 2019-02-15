using System.Linq;
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
        private readonly DockerTestContext _context;

        private readonly string _redisKey = "SomeRandomRedisKey";

        public ValuesController(IConfiguration config,
                                DockerTestContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var rcstring = _config.GetValue<string>("REDIS_URL");
            //var rcstring = "localhost:6379";

            string result = string.Empty;

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(rcstring);
            IDatabase db = redis.GetDatabase();

            var cache = db.StringGet(_redisKey);

            if (cache.IsNullOrEmpty)
            {
                //change to aggregate
                var dbstrings = _context.DockerTestTable.Select(dtt => dtt.ToString());
                foreach (var s in dbstrings)
                {
                    result += s;
                }

                db.StringSet(_redisKey, result);
            }
            else
            {
                result = cache.ToString() + " from redis!"; ;
            }

            return result;
        }
    }
}
