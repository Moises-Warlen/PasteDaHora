using Pastelaria.Api.Infra.Configuration;
using System.Web.Http;

namespace Pastelaria.Api.Controllers
{
    public class PingController : AuthApiController
    {
        public IHttpActionResult Get() => Ok();
    }
}
